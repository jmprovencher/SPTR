using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class P07 : SPTR.Process
    {
        #region Fields
        private static P07 instance;
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
        override
        public ProcessState currentState
        {
            get;
            set;
        }
        override
        public uint priority
        {
            get;
            set;
        }
        override
        public uint endConstraint
        {
            get;
            protected set;
        }
        override
        public uint period
        {
            get;
            protected set;
        }
        override
        public uint executionTime
        {
            get;
            protected set;
        }
        override
        public uint processID
        {
            get;
            protected set;
        }
        override
        public string processName
        {
            get;
            protected set;
        }
        override
        public bool sporadic
        {
            get;
            protected set;
        }

        public static P07 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new P07();
                    instance.init();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private P07()
        {
            processName = "Évitement de collision";
            processID = 7;
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
            _neededRessources.Add(Res.R03.Instance);
            _neededRessources.Add(Res.R05.Instance);
            _neededRessources.Add(Res.R07.Instance);
            _neededRessources.Add(Res.R09.Instance);
            _executionSequence = new List<object>();
            _executionSequence.Add(R03.Instance);
            _executionSequence.Add(R09.Instance);
            _executionSequence.Add(R07.Instance);
            _executionSequence.Add(R05.Instance);
            _executionSequence.Add(new Execution(1));
            _executionSequence.Add(C06.Instance);
            _executionSequence.Add(C02.Instance);

        }
        #endregion
    }
}
