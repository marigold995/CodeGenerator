
using _360.Api.Model.CyberDetection;
using _360.Api.Repository.CyberDetection;
using _360.Api.Web.CyberDetection.Infrastructure;
using _360Generator.Templates;
using _360.Framework.Api.Helpers;
using _360.Framework.Api.Infrastructure;
using _360.Framework.Libs.Extensions;
using AutoMapper;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace _360.Api.Web.CyberDetection.Controllers
{
	[Route("api/v1/cyberServices")]
	[P360AuthorizeApi]
	[CyberServiceExceptionFilter]
	public class CyberServiceController : ApiController {
		private readonly ICyberServiceRepository _cyberServiceRepository;

        public CyberServiceController(ICyberServiceRepository cyberServiceRepository)
        {
            _cyberServiceRepository = cyberServiceRepository;
        }

		                
		[HttpGet]
		[Route("~/api/v1/companies/{companyId}/cyberServices")]
		[ResponseType(typeof(CollectionResult<CyberServiceDto>))]
		public IHttpActionResult GetAll(string companyId, [FromUri] string fields = "")
		{           
			return Ok(new NotImplementedException());
		}	        
			
		
		
				
			}
}

