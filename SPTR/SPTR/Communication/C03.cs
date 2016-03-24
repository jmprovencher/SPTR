using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class C03

    {
        #region Fields
        private static C03 instance;
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

        public int dimension(int lenght, int scale)
        {
            return 1+(lenght/(scale*8));
        }

        public static C03 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new C03();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private C03()
        {
            emmitor = P02.Instance;
            receptor = P12.Instance;
            description = "Le chemin calculé est envoyé au processus de suivi du chemin.";
            blocking = false;
        }
        #endregion
    }
}
