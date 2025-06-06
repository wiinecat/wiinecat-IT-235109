using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class EditionComparer : IComparer<Edition>
    {
        public int Compare(Edition x, Edition y)
        {
            return x.Nomer.CompareTo(y.Nomer); 
        }
    }
}
