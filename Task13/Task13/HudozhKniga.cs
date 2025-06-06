using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum VidProizvedeniya
    {
        Proza, 
        Stihi  
    }

    public class HudozhKniga : Edition
    {
        public string Zhanr { get; set; } 
        public string Yazyk { get; set; } 
        public VidProizvedeniya Vid { get; set; } 

        public HudozhKniga(string name, List<string> avtors, int year, string izdatel, string nomer, string zhanr, string yazyk, VidProizvedeniya vid)
            : base(name, avtors, year, izdatel, nomer)
        {
            Zhanr = zhanr;
            Yazyk = yazyk;
            Vid = vid;
        }
        public override string[] GetInfo()
        {
            var info = new string[3];
            var baseInfo = base.GetInfo();
            info[0] = baseInfo[0];
            info[1] = baseInfo[1];
            info[2] = $"художественная книга. жанр: {Zhanr}, язык: {Yazyk}, вид: {Vid}";
            return info;
        }
    }
}
