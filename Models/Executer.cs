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
        public List <Proces> proceses = new List<Proces> ();
        private double TimeExect = 0;
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
        
        public Executer (List <Proces> proceses)
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
                } else 
                CurrentTime++;
            }
        }

        private void ExecuteProces (Proces proces)
        {
            proces.WaitTime = CurrentTime - proces.Tc;
            proces.ExectTime = CurrentTime;
            TimeExect = CurrentTime + proces.Te;
        }

        private bool disposed = false;

        // реализация интерфейса IDisposable.
        public void Dispose ()
        {
            Dispose(true);
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose (bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                }
                // освобождаем неуправляемые объекты
                disposed = true;
            }
        }

        // Деструктор
        ~Executer ()
        {
            Dispose(false);
        }

    }
}
