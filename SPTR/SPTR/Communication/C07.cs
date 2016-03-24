using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class C07
    {
        #region Fields
        private static C07 instance;
        #endregion

        #region Properties

        public Object emmitor
        {
            get;
            private set;
        }

        public Object receptor
        {
            get;
            private set;
        }

        public bool blocking
        {
            get;
            private set;
        }

        public string description
        {
            get;
            private set;
        }

        public int dimension
        {
            get;
            private set;
        }

        public static C07 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new C07();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private C07()
        {
            emmitor = P10.Instance;
            receptor = P13.Instance;
            description = "Un message est envoyé au processus sytèmes électriques pour demander de stimuler l'attention du conducteur.";
            dimension = 1;
            blocking = false;
        }
        #endregion
    }
}
