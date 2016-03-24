using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class C11
    {
        #region Fields
        private static C11 instance;
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

        public static C11 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new C11();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private C11()
        {
            emmitor = P12.Instance;
            receptor = P10.Instance;
            description = "Le chemin à suivre est transmis pour affichage en surimpression sur le pare-brise.";
            dimension = 1;
            blocking = false;
        }
        #endregion
    }
}
