using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class Department : IEnumerable<Edition>
    {
        public string Name { get; set; }
        private List<Edition> editions;

        public int Count => editions.Count;

        public Department(string name, IEnumerable<Edition> editions)
        {
            Name = name;
            this.editions = new List<Edition>(editions);
        }

        public IEnumerator<Edition> GetEnumerator() => editions.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
