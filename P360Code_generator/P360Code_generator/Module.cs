using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P360Code_generator
{
    class Module
    {
        private string moduleName { get; set; }

        public string ModuleName
        {
            get { return moduleName; }
            set { moduleName = value; }
        }

        public Module(string ModuleName)
        {
            this.moduleName = ModuleName;
        }
    }
}
