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
        public double Tc { get; }

        public double Te { get; }

        public static List<double> TcList = new List<double>();

        public double WaitTime { get; set; }

        public double ExectTime { get; set; }

        public Proces (int ID, double Tc, double Te)
        {
            if (Tc < 0 || Te <= 0 || TcList.Contains(Tc))
            {
                throw new Exception($"public Proces (int {ID}, double {Tc}, double {Te}) -> "+ArgumentError);
            }
            this.ID = ID;
            this.Tc = Tc+1;
            TcList.Add(Tc);
            this.Te = Te;
        }        
    }

    public class ProcComarer: IComparer<Proces>
    {
        public int Compare (Proces x, Proces y)
        {
            return x.Tc > y.Tc ? 1 : x.Tc < y.Tc ? -1 : 0;
        }
    }
}
