using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Res;

namespace SPTR.Proc
{
    class C06
    {
        #region Fields
        private static C06 instance;
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

        public static C06 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new C06();
                }
                return instance;
            }
        }
        #endregion
        #region Constructor
        private C06()
        {
            emmitor = P07.Instance;
            receptor = P03.Instance;
            description = "Lorsqu'une collision est imminente, un message est envoyé pour changer la vitesse du véhicule de façon à l'éviter.";
            dimension = 1;
            blocking = false;
        }
        #endregion
    }
}
