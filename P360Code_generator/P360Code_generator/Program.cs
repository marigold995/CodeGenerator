using P360Code_generator;
using P360Code_generator.Domain;
using System;

namespace P360Code_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var newModule = new Module("CyberDetection");
            newModule.CreateBackend();
       
            Console.ReadKey();
        }

        
    }
}
