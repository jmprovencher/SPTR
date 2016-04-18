using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Proc;


namespace SPTR
{
    public class Ordonnanceur
    {
        public Ordonnanceur()
        {
            processesList = new List<SPTR.Process.Process>();
            processesList.Add(P01.Instance);
            processesList.Add(P02.Instance);
            processesList.Add(P03.Instance);
            processesList.Add(P04.Instance);
            processesList.Add(P05.Instance);
            processesList.Add(P06.Instance);
            processesList.Add(P07.Instance);
            processesList.Add(P08.Instance);
            processesList.Add(P09.Instance);
            processesList.Add(P10.Instance);
            processesList.Add(P11.Instance);
            processesList.Add(P12.Instance);
            processesList.Add(P13.Instance);
        }

        public Process.Process getNextOrderedProcess()
        {
            setProcessesPriorities();
            uint hello = processesList[0].priority;
            SPTR.Process.Process highestPriorityProcess = getProcessWithHighestPriority();
            return highestPriorityProcess;
        }

        private Process.Process getProcessWithHighestPriority()
        {
            Process.Process max = processesList[0];
            foreach (Process.Process process in processesList)
            {
                if (process.priority >= max.priority)
                {
                    max = process;
                }
            }
            return max;
        }

        private void setProcessesPriorities()
        {

        }

        private List<SPTR.Process.Process> processesList;

    }
}
