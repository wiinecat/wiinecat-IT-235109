using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TextFileViewer
{
    public partial class MainForm : Form
    {
        private FolderBrowserDialog folderDialog;
        private Label pathLabel;
        private ListBox fileListBox;
        private TextBox textBox;
        private RadioButton utf8RadioButton;
        private RadioButton cp1251RadioButton;
        private RadioButton koi8RadioButton;
        private Button selectFolderButton;
        private Button exitButton;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Настройка основной формы
            this.Text = "Просмотр текстовых файлов";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Инициализация диалога выбора папки
            folderDialog = new FolderBrowserDialog();
            folderDialog.Description = "Выберите каталог для просмотра текстовых файлов";

            // Метка для отображения пути к каталогу
            pathLabel = new Label();
            pathLabel.Text = "Каталог не выбран";
            pathLabel.Location = new System.Drawing.Point(12, 12);
            pathLabel.Size = new System.Drawing.Size(760, 23);
            pathLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(pathLabel);

            // Список файлов
            fileListBox = new ListBox();
            fileListBox.Location = new System.Drawing.Point(12, 45);
            fileListBox.Size = new System.Drawing.Size(200, 400);
            fileListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            fileListBox.SelectedIndexChanged += FileListBox_SelectedIndexChanged;
            this.Controls.Add(fileListBox);

            // Текстовое поле для отображения содержимого файла
            textBox = new TextBox();
            textBox.Location = new System.Drawing.Point(230, 45);
            textBox.Size = new System.Drawing.Size(542, 400);
            textBox.Multiline = true;
            textBox.ScrollBars = ScrollBars.Both;
            textBox.ReadOnly = true;
            textBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(textBox);

            // Группа переключателей для выбора кодировки
            GroupBox encodingGroupBox = new GroupBox();
            encodingGroupBox.Text = "Кодировка";
            encodingGroupBox.Location = new System.Drawing.Point(12, 460);
            encodingGroupBox.Size = new System.Drawing.Size(300, 80);
            encodingGroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            utf8RadioButton = new RadioButton();
            utf8RadioButton.Text = "UTF-8";
            utf8RadioButton.Location = new System.Drawing.Point(10, 20);
            utf8RadioButton.Checked = true;
            utf8RadioButton.CheckedChanged += EncodingRadioButton_CheckedChanged;
            encodingGroupBox.Controls.Add(utf8RadioButton);

            cp1251RadioButton = new RadioButton();
            cp1251RadioButton.Text = "Windows-1251 (Кириллица)";
            cp1251RadioButton.Location = new System.Drawing.Point(10, 40);
            cp1251RadioButton.CheckedChanged += EncodingRadioButton_CheckedChanged;
            encodingGroupBox.Controls.Add(cp1251RadioButton);

            koi8RadioButton = new RadioButton();
            koi8RadioButton.Text = "KOI8-R (Западноевропейская и Юникод)";
            koi8RadioButton.Location = new System.Drawing.Point(10, 60);
            koi8RadioButton.CheckedChanged += EncodingRadioButton_CheckedChanged;
            encodingGroupBox.Controls.Add(koi8RadioButton);

            this.Controls.Add(encodingGroupBox);

            // Кнопка выбора каталога
            selectFolderButton = new Button();
            selectFolderButton.Text = "Выбрать каталог";
            selectFolderButton.Location = new System.Drawing.Point(330, 480);
            selectFolderButton.Size = new System.Drawing.Size(120, 30);
            selectFolderButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            selectFolderButton.Click += SelectFolderButton_Click;
            this.Controls.Add(selectFolderButton);

            // Кнопка выхода
            exitButton = new Button();
            exitButton.Text = "Выход";
            exitButton.Location = new System.Drawing.Point(460, 480);
            exitButton.Size = new System.Drawing.Size(80, 30);
            exitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            exitButton.Click += ExitButton_Click;
            this.Controls.Add(exitButton);
        }

        // Обработчик нажатия кнопки выбора каталога
        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = folderDialog.SelectedPath;
                pathLabel.Text = "Выбранный каталог: " + selectedPath;
                LoadTextFiles(selectedPath);
            }
        }

        // Загрузка списка текстовых файлов из выбранного каталога
        private void LoadTextFiles(string folderPath)
        {
            try
            {
                fileListBox.Items.Clear();
                textBox.Clear();

                // Получаем все файлы с расширением .txt
                string[] txtFiles = Directory.GetFiles(folderPath, "*.txt");

                foreach (string file in txtFiles)
                {
                    string fileName = Path.GetFileName(file);
                    fileListBox.Items.Add(fileName);
                }

                if (txtFiles.Length == 0)
                {
                    MessageBox.Show("В выбранном каталоге не найдено текстовых файлов (.txt)",
                                  "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке файлов: " + ex.Message,
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик выбора файла в списке
        private void FileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileListBox.SelectedItem != null)
            {
                string selectedFileName = fileListBox.SelectedItem.ToString();
                string folderPath = folderDialog.SelectedPath;
                string fullPath = Path.Combine(folderPath, selectedFileName);
                LoadFileContent(fullPath);
            }
        }

        // Загрузка содержимого выбранного файла
        private void LoadFileContent(string filePath)
        {
            try
            {
                Encoding encoding = GetSelectedEncoding();
                string content = File.ReadAllText(filePath, encoding);
                textBox.Text = content;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при чтении файла: " + ex.Message,
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Получение выбранной кодировки
        private Encoding GetSelectedEncoding()
        {
            if (cp1251RadioButton.Checked)
            {
                return Encoding.GetEncoding("windows-1251");
            }
            else if (koi8RadioButton.Checked)
            {
                return Encoding.GetEncoding("koi8-r");
            }
            else
            {
                return Encoding.UTF8; // По умолчанию UTF-8
            }
        }

        // Обработчик изменения кодировки
        private void EncodingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Если файл уже выбран, перезагружаем его с новой кодировкой
            if (fileListBox.SelectedItem != null && folderDialog.SelectedPath != null)
            {
                string selectedFileName = fileListBox.SelectedItem.ToString();
                string fullPath = Path.Combine(folderDialog.SelectedPath, selectedFileName);
                LoadFileContent(fullPath);
            }
        }

        // Обработчик кнопки выхода
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Главный класс программы
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
