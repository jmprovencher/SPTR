using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class C05
    {
        #region Fields
        private static C05 instance;
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

        public static C05 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new C05();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private C05()
        {
            emmitor = P05.Instance;
            receptor = P06.Instance;
            description = "Lorsque le cumulatif des u.a. atteint param:consommation, un message est envoyé pour envoyer un bilan.";
            dimension = 1;
            blocking = false;
        }
        #endregion
    }
}
