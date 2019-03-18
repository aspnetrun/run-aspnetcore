using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Infrastructure.Exceptions
{
    public class InfrastructureException : Exception
    {
        internal InfrastructureException(string businessMessage)
               : base(businessMessage)
        {
        }
    }
}
