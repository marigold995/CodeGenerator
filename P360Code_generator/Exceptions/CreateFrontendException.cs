using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Exceptions
{
    public class CreateFrontendException: Exception
    {
        public CreateFrontendException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
