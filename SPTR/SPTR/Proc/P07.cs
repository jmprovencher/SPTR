﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class P07
    {
        #region Fields
        private static P07 instance;
        #endregion

        #region Properties

        private List<Object> _neededRessources;

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
        
        public static P07 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new P07();
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
            /*Adding needed ressources to the list*/
            _neededRessources = new List<object>();
            _neededRessources.Add(Res.R03.Instance);
            _neededRessources.Add(Res.R05.Instance);
            _neededRessources.Add(Res.R07.Instance);
            _neededRessources.Add(Res.R09.Instance);

        }
        #endregion
    }
}