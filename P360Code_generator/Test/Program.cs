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
            var getAll = Entity.screenEnum.GetAll;
            var getById = Entity.screenEnum.Get;
            var post = Entity.screenEnum.Post;
            var put = Entity.screenEnum.Put;
            var delete = Entity.screenEnum.Delete;

            var newModule = new Module("CyberDetection");
            

            Entity cyberDetectionProfile = new Entity("CyberDetectionProfile");
            Entity cyberService = new Entity("CyberService");
            Entity securityAndItPolicy = new Entity("SecurityAndItPolicy");
            Entity zoneProfile = new Entity("ZoneProfile");

            cyberDetectionProfile.AddScreen(getAll);
            cyberDetectionProfile.AddScreen(getById);
            cyberDetectionProfile.AddScreen(post);
            cyberDetectionProfile.AddScreen(put);

            cyberService.AddScreen(getAll);

            securityAndItPolicy.AddScreen(getAll);
            securityAndItPolicy.AddScreen(getById);
            securityAndItPolicy.AddScreen(post);
            securityAndItPolicy.AddScreen(put);
            securityAndItPolicy.AddScreen(delete);

            zoneProfile.AddScreen(getAll);
            zoneProfile.AddScreen(getById);
            zoneProfile.AddScreen(post);
            zoneProfile.AddScreen(put);
            zoneProfile.AddScreen(delete);

            newModule.AddEntity(cyberDetectionProfile);
            newModule.AddEntity(cyberService);
            newModule.AddEntity(securityAndItPolicy);
            newModule.AddEntity(zoneProfile);

            var generator = new Generator(newModule);
            generator.CreateBackend();

            Console.ReadKey();
        }
    }
}
