using System;
using System.Collections.Generic;
using System.Text;

namespace Trilogic.Common.Settings
{
    public class ArgException : Exception
    {
        public ArgException(string msg)
            : base(msg)
        {
        }
    }
}
