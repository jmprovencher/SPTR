using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class P03 : SPTR.Process.Process
    {
        #region Fields
        private static P03 instance;
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
            protected set;
        }
        override
        public uint priority
        {
            get;
            protected set;
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

        public static P03 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new P03();
                    instance.init();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private P03()
        {
            processName = "Changement de vitesse";
            processID = 3;
            executionTime = 4;
            priority = 0;
            sporadic = true;
            period = 0;
            endConstraint = 10; /**/
            currentState = ProcessState.PROCESS_RUNNING;
        }

        private void init()
        {
            /*Adding needed ressources to the list*/
            _neededRessources = new List<object>();
            _neededRessources.Add(Res.R03.Instance);
            _neededRessources.Add(Res.R10.Instance);
            _executionSequence = new List<object>();
            // R03 C6 C1 C9 R10* C04
            _executionSequence.Add(R03.Instance);
            _executionSequence.Add(C06.Instance);
            _executionSequence.Add(C01.Instance);
            _executionSequence.Add(C09.Instance);
            _executionSequence.Add(R10.Instance);
            _executionSequence.Add(C04.Instance);

        }
        #endregion
    }
}
