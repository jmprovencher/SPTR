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
            processesList = new List<SPTR.Process>();
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
            RRprocessRunning = 1;
            count = 3;
            setProcessesPriorities();
        }

        public Process getProcessWithHighestPriority()
        {
            Process max = processesList[0];
            foreach (Process process in processesList)
            {
                if (process.priority > max.priority && process.currentState != ProcessState.PROCESS_BLOCKED)
                {
                    max = process;
                }
            }
            return max;
        }

        private void setProcessesPriorities()
        {
            Random rnd = new Random();
            for (int i = 0; i < processesList.Count; i++)
            {
                processesList[i].priority = (uint)rnd.Next(1, 9999);
                processesList[i].currentState = ProcessState.PROCESS_ASLEEP;
            }

        }

        public List<SPTR.Process> processesList;

        public int count { get; set; }
        public void priority()
        {
            SPTR.Process runningProcess = getProcessWithHighestPriority();
            Console.WriteLine(runningProcess.processName+" - "+count);
            if (count == 0)
            {
                Random rnd = new Random();
                count = rnd.Next(5, 10); // creates a priority
                runningProcess.currentState = ProcessState.PROCESS_BLOCKED;
            }
            else
            {
                foreach (Process process in processesList)
                {
                    if (process.currentState != ProcessState.PROCESS_BLOCKED) { 
                        process.currentState = ProcessState.PROCESS_SUSPENDED;
                    }
                }
                runningProcess.currentState = ProcessState.PROCESS_RUNNING;

            }
            count--;
        }

        int RRprocessRunning { get; set; }
        public void roundRobin()
        {
            
            for (int i = 0; i <processesList.Count ; i++)
            {
                if (i == RRprocessRunning-1)
                {
                    processesList[i].currentState = ProcessState.PROCESS_RUNNING;
                }
                else
                {
                    processesList[i].currentState = ProcessState.PROCESS_SUSPENDED;
                }
            }
            RRprocessRunning++;
            if ((RRprocessRunning-1) > 13)
            {
                RRprocessRunning = 1;
            }
        }

    }
}
