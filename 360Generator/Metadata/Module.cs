using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P360Code_generator.Domain;

namespace P360Code_generator.Metadata
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

        public void CreateBackend()
        {
            var apiWebController = new ApiWebController(this);           
            apiWebController.CreateApiWebControllerTemplate();

            var apiRepository = new ApiRepository(this);
            apiRepository.CreateApiInterfaceRepositoryTemplate();

            var apiModelDTO = new ApiModelDTO(this);
            apiModelDTO.CreateApiModelTemplate();

            var apiFacadeProxy = new ApiFacadeProxy(this);
            apiFacadeProxy.CreateApiFacadeProxyTemplate();

            var domainModel = new DomainModel(this);
            domainModel.CreateDomainModelTemplate();
        }
    }
}
