using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class C02
    {
        #region Fields
        private static C02 instance;
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

        public static C02 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new C02();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private C02()
        {
            emmitor = P02.Instance;
            receptor = P07.Instance;
            description = "Avant de suivre le chemin calculé, il faut vérifier si une collision n'est pas imminente.";
            dimension = 1;
            blocking = true;
        }
        #endregion
    }
}
