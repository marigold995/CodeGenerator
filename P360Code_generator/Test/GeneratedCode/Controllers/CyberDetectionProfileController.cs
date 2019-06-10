
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

	[Route("api/v1/cyberDetectionProfiles")]
	[P360AuthorizeApi]
	[CyberDetectionProfileExceptionFilter]
	public class CyberDetectionProfileController : ApiController {
		private readonly ICyberDetectionProfileRepository _cyberDetectionProfileRepository;

        public CyberDetectionProfileController(ICyberDetectionProfileRepository cyberDetectionProfileRepository)
        {
            _cyberDetectionProfileRepository = cyberDetectionProfileRepository;
        }

		[HttpGet]
		[Route("~/api/v1/companies/{companyId}/cyberDetectionProfiles")]
		[ResponseType(typeof(CollectionResult<CyberDetectionProfileDto>))]
		public IHttpActionResult GetAll(string companyId, [FromUri] string fields = "")
        {           
            return Ok(new NotImplementedException());
        }

		[HttpGet]
		[Route("~/api/v1/companies/{companyId}/cyberDetectionProfiles/{cyberDetectionProfileId}", Name = "GetCyberDetectionProfileById")]
        [ResponseType(typeof(CyberDetectionProfileDto))]
		 public IHttpActionResult GetById(string companyId, string cyberDetectionProfileId)
        {
			return Ok(new NotImplementedException());
		}	

		[HttpPost]       
        public IHttpActionResult Post([FromBody] CyberDetectionProfileDto cyberDetectionProfileDto)
        {
			return BadRequest();
		}

		[HttpPut]       
        public IHttpActionResult Put([FromBody] CyberDetectionProfileDto cyberDetectionProfileDto)
        {
           return Ok(new NotImplementedException());
        }
	}
}

