using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class C09
    {
        #region Fields
        private static C09 instance;
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

        public static C09 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new C09();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private C09()
        {
            emmitor = P12.Instance;
            receptor = P03.Instance;
            description = "En situation normale, le processus de suivi de chemin demande de changer la vitesse si nécessaire. ";
            dimension = 1;
            blocking = false;
        }
        #endregion
    }
}
