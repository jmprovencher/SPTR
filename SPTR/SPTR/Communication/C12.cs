using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class C12
    {
        #region Fields
        private static C12 instance;
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

        public static C12 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new C12();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private C12()
        {
            emmitor = P12.Instance;
            receptor = P11.Instance;
            description = "En situation d'urgence, le processus de suivi du chemin demande d'activer les freins ABS pour freiner rapidement.";
            dimension = 1;
            blocking = false;
        }
        #endregion
    }
}
