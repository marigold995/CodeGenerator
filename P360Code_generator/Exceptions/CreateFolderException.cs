using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _360Generator.Exceptions
{
    class CreateFolderException: Exception
    {
        public CreateFolderException()
            : base()
        {

        }
        public CreateFolderException(string message)
            :base(message)
        {

        }
    }
}
