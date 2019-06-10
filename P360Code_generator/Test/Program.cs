using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Metadata;
using _360Generator.Generator;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var newModule = new Module("CyberDetection");
            newModule.AddEntity(new Entity("CyberDetectionProfile"));
            newModule.AddEntity(new Entity("CyberService"));
            newModule.AddEntity(new Entity("SecurityAndITPolicy"));
            newModule.AddEntity(new Entity("ZoneProfile"));

            var generator = new Generator(newModule);
            generator.CreateBackend();

            Console.ReadKey();
        }
    }
}
