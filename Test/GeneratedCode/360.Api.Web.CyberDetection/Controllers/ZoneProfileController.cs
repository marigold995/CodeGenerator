










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
	[Route("api/v1/zoneProfiles")]
	[P360AuthorizeApi]
	[ZoneProfileExceptionFilter]
	public class ZoneProfileController : ApiController {
		private readonly IZoneProfileRepository _zoneProfileRepository;

        public ZoneProfileController(IZoneProfileRepository zoneProfileRepository)
        {
            _zoneProfileRepository = zoneProfileRepository;
        }

		                
		[HttpGet]
		[Route("~/api/v1/companies/{companyId}/zoneProfiles")]
		[ResponseType(typeof(CollectionResult<ZoneProfileDto>))]
		public IHttpActionResult GetAll(string companyId, [FromUri] string fields = "")
		{           
			return Ok(new NotImplementedException());
		}	        
			
		
		[HttpGet]
		[Route("~/api/v1/companies/{companyId}/zoneProfiles/{zoneProfileId}", Name = "GetZoneProfileById")]
        [ResponseType(typeof(ZoneProfileDto))]
		 public IHttpActionResult GetById(string companyId, string zoneProfileId)
        {
			return Ok(new NotImplementedException());
		}

		
		[HttpPost]       
        public IHttpActionResult Post([FromBody] ZoneProfileDto zoneProfileDto)
        {
			return BadRequest();
		}

		
		[HttpPut]       
        public IHttpActionResult Put([FromBody] ZoneProfileDto zoneProfileDto)
        {
           return Ok(new NotImplementedException());
        }
		
		
	}
}

