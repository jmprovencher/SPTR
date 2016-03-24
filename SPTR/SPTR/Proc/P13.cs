﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class P13
    {
        #region Fields
        private static P13 instance;
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
        }

        public uint period
        {
            get;
        }
        public uint executionTime
        {
            get;
        }

        public uint processID
        {
            get;
        }

        public string processName
        {
            get;
        }

        public bool sporadic
        {
            get;
        }
        
        public static P13 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new P13();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private P13()
        {
            processName = "Systèmes Électriques";
            processID = 13;
            executionTime = 4;
            priority = 0;
            sporadic = true;
            endConstraint = 7;
            currentState = ProcessState.PROCESS_RUNNING;
            /*Adding needed ressources to the list*/
            _neededRessources = new List<object>();
            _neededRessources.Add(Res.R04.Instance);
            _neededRessources.Add(Res.R05.Instance);
            _neededRessources.Add(Res.R11.Instance);
            _executionSequence = new List<object>();
            _executionSequence.Add(C07.Instance);
            _executionSequence.Add(R05.Instance);
            _executionSequence.Add(R11.Instance);
            _executionSequence.Add(new Execution(1));
            _executionSequence.Add(R04.Instance);

        }
        #endregion
    }
}
