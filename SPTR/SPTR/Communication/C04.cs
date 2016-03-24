using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class C04
    {
        #region Fields
        private static C04 instance;
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

        public static C04 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new C04();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private C04()
        {
            emmitor = P03.Instance;
            receptor = P05.Instance;
            description = "Lors d'un changement de vitesse, un message est envoyé au processus de contrôle des émissions indiquant le nombre d'unités d'accélération(u.a.) utilisé.";
            dimension = 1;
            blocking = false;
        }
        #endregion
    }
}
