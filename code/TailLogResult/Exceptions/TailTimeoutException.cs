using System;
using System.Collections.Generic;
using System.Text;

namespace TailLogResult.Exceptions
{
    class TailTimeoutException: Exception
    {
        public TailTimeoutException()
        : base(String.Format("Couldn't find Log line within determined time"))
        {
        }
    }
}
