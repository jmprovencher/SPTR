using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPTR.Proc;

namespace SPTR.Res
{
    class R06
    {
        #region Fields
        private static R06 instance;
        private bool _resLocked;
        #endregion

        #region Properties

        public string resName
        {
            get;
            private set;
        }
        public uint resID
        {
            get;
            private set;
        }
        public uint resOwnerID
        {
            get;
            private set;
        }

        public static R06 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new R06();
                }
                return instance;
            }
        }
        #endregion

        #region Constructor
        private R06()
        {
            resName = "Carte graphique";
            resID = 1;
            _resLocked = false;
            resOwnerID = 0;
        }
        #endregion

        #region Functions

        /// <summary>
        /// Take resource 1 if it's not owned by any other process.
        /// </summary>
        /// <param name="processID">Process id of the process taking control of the resource</param>
        /// <returns>Returns true for a successful operation, returns false otherwise</returns>
        public bool takeResource(uint processID)
        {
            if(!_resLocked)
            {
                _resLocked = true;
                resOwnerID = processID;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Release resource 1 if its owned by a process. The resource must be release by the current owner, otherwise, the operation won't be successful
        /// </summary>
        /// <param name="processID">Process id of the current resource owner</param>
        /// <returns>Returns true for a successful release operation, returns false otherwise</returns>
        public bool releaseResource(uint processID)
        {
            if(_resLocked && (processID == resOwnerID))
            {
                _resLocked = false;
                resOwnerID = 0;
                return true;
            }
            return false;
        }
        #endregion
    }
}
