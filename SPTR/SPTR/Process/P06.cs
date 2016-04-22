using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class P06 : SPTR.Process
    {
        #region Fields
        private static P06 instance;
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

        public static P06 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new P06();
                    instance.init();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private P06()
        {
            processName = "Envoie de bilan";
            processID = 6;
            executionTime = 3;
            priority = 0;
            period = 0;
            sporadic = true;
            endConstraint = 30;
            currentState = ProcessState.PROCESS_RUNNING;
        }

        private void init()
        {
            /*Adding needed ressources to the list*/
            _neededRessources = new List<object>();
            _neededRessources.Add(Res.R06.Instance);
            _neededRessources.Add(Res.R08.Instance);
            _executionSequence = new List<object>();
            _executionSequence.Add(C10.Instance);
            _executionSequence.Add(C05.Instance);
            _executionSequence.Add(R08.Instance);
            _executionSequence.Add(R06.Instance);
            _executionSequence.Add(new Execution(1));

        }
        #endregion
    }
}
