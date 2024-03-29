﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class P12 : SPTR.Process
    {
        #region Fields
        private static P12 instance;
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

        public static P12 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new P12();
                    instance.init();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private P12()
        {
            currentSequenceIndex = 0;
            processName = "Suivi du chemin";
            processID = 12;
            executionTime = 4;
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
            _neededRessources.Add(Res.R03.Instance);
            _neededRessources.Add(Res.R04.Instance);
            _neededRessources.Add(Res.R06.Instance);
            _executionSequence = new List<object>();
            _executionSequence.Add(C03.Instance);
            _executionSequence.Add(R03.Instance);
            _executionSequence.Add(C12.Instance);
            _executionSequence.Add(C09.Instance);
            _executionSequence.Add(R01.Instance);
            _executionSequence.Add(R04.Instance);
            _executionSequence.Add(C11.Instance);
            _executionSequence.Add(R06.Instance);
            _executionSequence.Add(C10.Instance);

        }
        #endregion
    }
}
