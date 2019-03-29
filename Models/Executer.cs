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
        public List<Proces> CompleteProceses = new List<Proces>();
        public List<Proces> proceses = new List<Proces>();
        public double AvgWaitTime
        {
            get
            {
                double AvgWait = 0;
                foreach (Proces proc in CompleteProceses)
                {
                    AvgWait += proc.WaitTime;
                }
                return AvgWait / CompleteProceses.Count;
            }
        }
        public double AvgExectTime
        {
            get
            {
                double AvgExect = 0;
                foreach (Proces proc in CompleteProceses)
                {
                    AvgExect += proc.ExectTime;
                }
                return AvgExect / CompleteProceses.Count;
            }
        }
        private int NonCompleteProceses = 0;
        private int CurrentTime = 0;
        public int EndTime
        {
            get
            {
                return CurrentTime;
            }
        }
        


        #region Executing
        public Executer (List<Proces> proceses)
        {
            this.proceses = proceses;
            NonCompleteProceses = proceses.Count;
            proceses.Sort(new ProcComparerByTc());
        }

        public void Execute ()
        {
            List<Proces> pullProceses = new List<Proces>();
            while (NonCompleteProceses != 0)
            {
                GetPull(ref pullProceses);
                ExecuteProces(ref pullProceses);
                CurrentTime++;
            }
        }

        private void GetPull (ref List<Proces> pullProceses)
        {
            for (int i=0; i< proceses.Count; i++)
            {
                while (proceses[i].Tc == CurrentTime && !proceses[i].EndExecuting)
                {
                    pullProceses.Add(proceses[i]);
                    proceses.RemoveAt(i);
                    if (proceses.Count == 0)
                    {
                        return;
                    }
                }
            }
        }

        private void ExecuteProces (ref List<Proces> proceses)
        {
            
            if (proceses.Count > 1)
            {
                for (int i = 1; i < proceses.Count; i++)
                {
                    proceses[i].History.Add(0);
                }
            }
            if (proceses.Count > 0)
            {
                
                proceses[0].LeftTime -= 1;
                proceses[0].History.Add(1);
                if (proceses[0].EndExecuting)
                {
                    proceses[0].EndTime = CurrentTime+1;
                    NonCompleteProceses -= 1;
                    CompleteProceses.Add(proceses[0]);
                    proceses.RemoveAt(0);
                    proceses.Sort(new ProcComparerByPP());
                }   
            }
            
        }
        #endregion
    }
}