
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
	[Route("api/v1/securityAndItPolicys")]
	[P360AuthorizeApi]
	[SecurityAndItPolicyExceptionFilter]
	public class SecurityAndItPolicyController : ApiController {
		private readonly ISecurityAndItPolicyRepository _securityAndItPolicyRepository;

        public SecurityAndItPolicyController(ISecurityAndItPolicyRepository securityAndItPolicyRepository)
        {
            _securityAndItPolicyRepository = securityAndItPolicyRepository;
        }

		                
		[HttpGet]
		[Route("~/api/v1/companies/{companyId}/securityAndItPolicys")]
		[ResponseType(typeof(CollectionResult<SecurityAndItPolicyDto>))]
		public IHttpActionResult GetAll(string companyId, [FromUri] string fields = "")
		{           
			return Ok(new NotImplementedException());
		}	        
			
				[HttpGet]
		[Route("~/api/v1/companies/{companyId}/securityAndItPolicys/{securityAndItPolicyId}", Name = "GetSecurityAndItPolicyById")]
        [ResponseType(typeof(SecurityAndItPolicyDto))]
		 public IHttpActionResult GetById(string companyId, string securityAndItPolicyId)
        {
			return Ok(new NotImplementedException());
		}
				[HttpPost]       
        public IHttpActionResult Post([FromBody] SecurityAndItPolicyDto securityAndItPolicyDto)
        {
			return BadRequest();
		}
				[HttpPut]       
        public IHttpActionResult Put([FromBody] SecurityAndItPolicyDto securityAndItPolicyDto)
        {
           return Ok(new NotImplementedException());
        }		
			}
}

