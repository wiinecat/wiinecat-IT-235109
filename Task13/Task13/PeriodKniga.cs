using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum PeriodType 
    {
        Journal,
        Newspaper
    }
    public class PeriodKniga : Edition
    {
        public string PeriodVyhoda { get; set; } 
        public PeriodType VidPeriodiki { get; set; }

        public PeriodKniga(string name, List<string> avtors, int year, string izdatel, string nomer, string periodVyhoda, PeriodType vidPeriodiki)
            : base(name, avtors, year, izdatel, nomer)
        {
            PeriodVyhoda = periodVyhoda;
            VidPeriodiki = vidPeriodiki;
        }
        public override string[] GetInfo()
        {
            var info = new string[3];
            var baseInfo = base.GetInfo();
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"периодическая литература. период выхода: {PeriodVyhoda}, вид: {VidPeriodiki}";
            return info;
        }
    }
}
