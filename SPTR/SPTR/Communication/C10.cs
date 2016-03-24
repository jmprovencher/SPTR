using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class C10
    {
        #region Fields
        private static C10 instance;
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

        public static C10 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new C10();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private C10()
        {
            emmitor = P12.Instance;
            receptor = P06.Instance;
            description = "En situation normale, le processus de suivi de chemin demande d'envoyer un bilan si nécessaire. ";
            dimension = 1;
            blocking = false;
        }
        #endregion
    }
}
