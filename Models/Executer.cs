using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCFS.Models;
namespace FCFS.Models
{
    class Executer
    {
        public List<Proces> proceses = new List<Proces>();
        public double AvgWaitTime
        {
            get
            {
                double AvgWait = 0;
                foreach (Proces proc in proceses)
                {
                    AvgWait += proc.WaitTime;
                }
                return AvgWait / proceses.Count;
            }
        }
        public double AvgExectTime
        {
            get
            {
                double AvgExect = 0;
                foreach (Proces proc in proceses)
                {
                    AvgExect += proc.Te + proc.WaitTime;
                }
                return AvgExect / proceses.Count;
            }
        }
        public double TimeExect { get; set; } = 0;
        private double CurrentTime = 0;
        enum Status
        {
            Ready,
            Executing
        }
        Status status
        {
            get
            {
                return TimeExect <= CurrentTime ? Status.Ready : Status.Executing;
            }
        }


        #region Executing
        public Executer (List<Proces> proceses)
        {
            this.proceses = proceses;
            proceses.Sort(new ProcComarer());
        }

        public void Execute ()
        {
            int completeProceses = 0;
            while (completeProceses != proceses.Count)
            {
                if (status == Status.Ready && CurrentTime >= proceses[completeProceses].Tc)
                {
                    ExecuteProces(proceses[completeProceses]);
                    completeProceses++;
                }
                else
                    CurrentTime++;
            }
        }

        private void ExecuteProces (Proces proces)
        {
            proces.WaitTime = CurrentTime - proces.Tc;
            proces.ExectTime = CurrentTime;
            TimeExect = CurrentTime + proces.Te;
        }
        #endregion
    }
}