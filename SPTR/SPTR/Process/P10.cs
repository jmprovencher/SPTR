using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class P10
    {
        #region Fields
        private static P10 instance;
        #endregion

        #region Properties

        private List<Object> _neededRessources;
        private List<Object> _executionSequence;
        private int currentSequenceIndex
        {
            get;
            set;
        }
        public Object getNextSequence()
        {
            Object NextSequence = _executionSequence[currentSequenceIndex];
            if (currentSequenceIndex++ == _executionSequence.Count())
            {
                currentSequenceIndex = 0;
            }
            return NextSequence;
        }
        public string formatedProcessState
        {
            get
            {
                switch (currentState)
                {
                    case ProcessState.PROCESS_ASLEEP:
                        return "Asleep";
                    case ProcessState.PROCESS_BLOCKED:
                        return "Blocked";
                    case ProcessState.PROCESS_RUNNING:
                        return "Running";
                    case ProcessState.PROCESS_SUSPENDED:
                        return "Suspended";
                    default:
                        return "Invalid";
                }
            }
        }

        public ProcessState currentState
        {
            get;
            set;
        }

        public uint priority
        {
            get;
            set;
        }

        public uint endConstraint
        {
            get;
            private set;
        }

        public uint period
        {
            get;
            private set;
        }
        public uint executionTime
        {
            get;
            private set;
        }

        public uint processID
        {
            get;
            private set;
        }

        public string processName
        {
            get;
            private set;
        }

        public bool sporadic
        {
            get;
            private set;
        }
        
        public static P10 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new P10();
                    instance.init();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private P10()
        {
            processName = "Securité A";
            processID = 10;
            executionTime = 5;
            priority = 0;
            sporadic = false;
            period = 0;
            endConstraint = period;
            currentState = ProcessState.PROCESS_RUNNING;

        }

        private void init()
        {
            /*Adding needed ressources to the list*/
            _neededRessources = new List<object>();
            _neededRessources.Add(Res.R01.Instance);
            _neededRessources.Add(Res.R02.Instance);
            _neededRessources.Add(Res.R04.Instance);
            _executionSequence = new List<object>();
            _executionSequence.Add(R01.Instance);
            _executionSequence.Add(R02.Instance);
            _executionSequence.Add(R01.Instance);
            _executionSequence.Add(C11.Instance);
            _executionSequence.Add(R04.Instance);
            _executionSequence.Add(new Execution(1));
            _executionSequence.Add(C07.Instance);

        }
        #endregion
    }
}
