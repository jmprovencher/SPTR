using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Proc;

namespace SPTR
{
    public abstract class Process
    {

        abstract public ProcessState currentState
        {
            get;
            set;
        }

        abstract public uint priority
        {
            get;
            set;
        }

        abstract public uint endConstraint
        {
            get;
            protected set;
        }

        abstract public uint period
        {
            get;
            protected set;
        }

        abstract public uint executionTime
        {
            get;
            protected set;
        }

        abstract public uint processID
        {
            get;
            protected set;
        }

        abstract public string processName
        {
            get;
            protected set;
        }

        abstract public bool sporadic
        {
            get;
            protected set;
        }
    }
}
