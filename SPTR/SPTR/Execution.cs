using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTR
{
    class Execution
    {
        public Execution(int arg_time)
        {
            time = arg_time;
        }

        public int time
        {
            get;

            private set;
        }

        public void run()
        {
            throw new NotImplementedException();
        }
    }
}
