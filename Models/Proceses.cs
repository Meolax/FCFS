using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFS.Models
{
    public class Proces
    {
        private readonly static string ArgumentError = "Argument error!";

        public int ID { get; }
        public int Tc { get; }
        public int Te { get; }
        public static List<int> TcList = new List<int>();
        public int EndTime { get; set; }
        public int LeftTime { get; set; } 
        public int WaitTime { get; set; }
        public int ExectTime { get; set; }

        public Proces (int ID, int Tc, int Te)
        {
            if (Tc < 0 || Te <= 0 || TcList.Contains(Tc))
            {
                throw new Exception($"public Proces (int {ID}, int {Tc}, int {Te}) -> "+ArgumentError);
            }
            this.ID = ID;
            this.Tc = Tc+1;
            TcList.Add(Tc);
            this.Te = Te;
            LeftTime = Te;
        }        
    }

    public class ProcComparerByTc: IComparer<Proces>
    {
        public int Compare (Proces x, Proces y)
        {
            return x.Tc > y.Tc ? 1 : x.Tc < y.Tc ? -1 : 0;
        }
    }

    public class ProcComparerByLeftTime : IComparer<Proces>
    {
        public int Compare(Proces x, Proces y)
        {
            return x.LeftTime > y.LeftTime ? 1 : x.LeftTime < y.LeftTime ? -1 : 0;
        }
    }


}
