using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core
{
    public class CoreException : Exception
    {
        internal CoreException(string businessMessage)
            : base(businessMessage)
        {
        }
    }
}
