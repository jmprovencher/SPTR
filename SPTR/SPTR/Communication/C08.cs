using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class C08
    {
        #region Fields
        private static C08 instance;
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

        public static C08 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new C08();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private C08()
        {
            emmitor = P11.Instance;
            receptor = P08.Instance;
            description = "Lorsqu'il y a collision, le coussin gonflable s'active et un message est envoyé au processus media qui fera un appel automatique à un centre d'aide.";
            dimension = 1;
            blocking = false;
        }
        #endregion
    }
}
