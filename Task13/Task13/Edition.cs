using System;
using System.Collections.Generic;
using Library;

namespace Library
{
    public class Edition
    {
        public string Name { get; set; }
        public List<string> Avtors { get; set; }
        public int Year { get; set; }
        public string Izdatel { get; set; }
        public decimal Cena { get; set; }
        public Status Status { get; set; }
        public readonly string Nomer;

        public Edition(string name, List<string> avtors, int year, string izdatel, string nomer)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("название не может быть пустым");
            if (avtors == null || avtors.Count == 0)
                throw new ArgumentException("авторы не могут быть пустыми");
            if (string.IsNullOrEmpty(izdatel))
                throw new ArgumentException("издательство не может быть пустым");
            if (string.IsNullOrEmpty(nomer))
                throw new ArgumentException("номер не может быть пустым");

            Name = name;
            Avtors = avtors;
            Year = year;
            Izdatel = izdatel;
            Nomer = nomer;
            Cena = 0;
            Status = Status.NaSklade;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[2];
            info[0] = $"{Name} (авторы: {string.Join(", ", Avtors)})";
            string statusText;
            switch (Status)
            {
                case Status.NaSklade:
                    statusText = "на складе";
                    break;
                case Status.VChitalnom:
                    statusText = "в читальном зале";
                    break;
                case Status.Vydana:
                    statusText = "выдана на дом";
                    break;
                default:
                    statusText = "статус неизвестен";
                    break;
            }
            info[1] = $"год: {Year}, издательство: {Izdatel}, номер: {Nomer}, статус: {statusText}, цена: {Cena} руб.";
            return info;
        }
    }
}