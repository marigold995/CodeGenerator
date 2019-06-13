using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _360Generator.Templates;
using _360Generator.Domain;
using _360Generator.Metadata;

namespace _360Generator.Generator
{
    public class Generator
    {
        public Module Module{ get; set; }

        public Generator(Module newModule)
        {
            this.Module = newModule;
        }

        public void CreateBackend()
        {            
            var apiWebController = new ApiWebController(this.Module);
            apiWebController.CreateApiWebControllerTemplate();

            var apiRepository = new ApiRepository(this.Module);
            apiRepository.CreateApiInterfaceRepositoryTemplate();

            var apiModelDTO = new ApiModelDTO(this.Module);
            apiModelDTO.CreateApiModelTemplate();

            var apiFacadeProxy = new ApiFacadeProxy(this.Module);
            apiFacadeProxy.CreateApiFacadeProxyTemplate();

            var apiFacade = new ApiFacade(this.Module);
            apiFacade.CreateApiFacadeTemplate();

            var domainModel = new DomainModel(this.Module);
            domainModel.CreateDomainModelTemplate();
        }

        public void CreateFrontend()
        {
            var portalData = new PortalData(this.Module);
            portalData.CreatePortalDataTemplate();

            var portalInitializer = new PortalInitializer(this.Module);
            portalInitializer.CreatePortalInitializerTemplate();

            var portalModel = new PortalModel(this.Module);
            portalModel.CreatePortalModelTemplate();

            var portalValidator = new PortalValidator(this.Module);
            portalValidator.CreatePortalValidatorTemplate();

            var portalView = new PortalView(this.Module);
            portalView.CreatePortalViewTemplate();

            var portalViewModel = new PortalViewModel(this.Module);
            portalViewModel.CreatePortalViewModelTemplate();
        }

    }
}
