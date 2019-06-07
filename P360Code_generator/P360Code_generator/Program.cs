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

            var apiWebController = new ApiWebController(newModule);
            apiWebController.CreateApiWebControllerTemplate();

            var apiRepository = new ApiRepository(newModule);
            apiRepository.CreateApiInterfaceRepositoryTemplate();

            var apiModelDTO = new ApiModelDTO(newModule);
            apiModelDTO.CreateApiModelTemplate();

            var apiFacadeProxy = new ApiFacadeProxy(newModule);
            apiFacadeProxy.CreateApiFacadeProxyTemplate();

            var domainModel = new DomainModel(newModule);
            domainModel.CreateDomainModelTemplate();

            Console.ReadKey();
        }
    }
}
