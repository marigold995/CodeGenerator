
using _360.Api.Facade.Document;
using _360.Api.Facade.FileSystem;
using _360.Api.Facade.GBM.Contracting;
using _360.Api.Facade.GBM.CyberDetection;
using _360.Api.Facade.Order;
using _360.Api.Facade.ServiceBus;
using _360.Api.FacadeProxy.Base;
using _360.Api.FacadeProxy.Core;
using _360.Framework.Libs.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace _360.Api.FacadeProxy.CyberDetection
{
    public partial class CyberDetectionFacadeProxy : BaseFacadeProxy
    {
		private CoreFacadeProxy _coreFacadeProxy;

        public CyberDetectionFacadeProxy(ICurrentUserWrapper currentUser) : base(currentUser) => ModuleTechnology = "CyberDetection";

		private CoreFacadeProxy CoreFacadeProxy => _coreFacadeProxy ?? (_coreFacadeProxy = new CoreFacadeProxy(CurrentUser));
	}
}