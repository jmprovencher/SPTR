using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class C01
    {
        #region Fields
        private static C01 instance;
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

        public static C01 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new C01();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private C01()
        {
            emmitor = P01.Instance;
            receptor = P03.Instance;
            description = "Suite à un bris, le processus d'auto-vérification envoie un message au processus de changement de vitesse.";
            dimension = 1;
            blocking = false;
        }
        #endregion
    }
}
