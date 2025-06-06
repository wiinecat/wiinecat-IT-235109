using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class NaukaKniga : Edition
    {
        public string OblastNauki { get; set; } 
        public string Annotaciya { get; set; } 
        public NaukaKniga(string name, List<string> avtors, int year, string izdatel, string nomer, string oblastNauki, string annotaciya)
            : base(name, avtors, year, izdatel, nomer)
        {
            OblastNauki = oblastNauki;
            Annotaciya = annotaciya;
        }

        public override string[] GetInfo()
        {
            var info = new string[3];
            var baseInfo = base.GetInfo();
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"научная книга. область: {OblastNauki}, аннотация: {Annotaciya}";
            return info;
        }
    }
}
