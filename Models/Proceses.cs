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
        public int PP { get; }
        public static List<int> TcList = new List<int>();
        public int LeftTime { get; set; }
        public int EndTime { get; set; }
        public int WaitTime { get {return EndTime - Tc - Te; } }
        public int ExectTime { get { return EndTime - Tc; } }
        public List<int> History = new List<int>();
        public bool EndExecuting
        {
            get
            {
                return LeftTime > 0 ? false : true;
            }
        }

        public Proces (int ID, int Tc, int Te, int PP)
        {
            if (Tc < 0 || Te <= 0 || TcList.Contains(Tc))
            {
                throw new Exception($"public Proces (int {ID}, int {Tc}, int {Te}) -> "+ArgumentError);
            }
            this.ID = ID;
            this.Tc = Tc+1;
            this.PP = PP;
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

    public class ProcComparerByPP : IComparer<Proces>
    {
        public int Compare(Proces x, Proces y)
        {
            return x.PP > y.PP ? 1 : x.PP < y.PP ? -1 : 0;
        }
    }
}
