using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Exceptions
{
    public class CreateBackendException : Exception
    {
        public CreateBackendException(string message) :
            base(message)
        {

        }
    }
}
