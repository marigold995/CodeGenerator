using _360.Api.Facade.GBM.Core.Converters;
using _360.Api.Facade.GBM.Document.Converters;
using _360.Framework.Libs.Extensions;
using BusinessMap.Client.Rest.Models;
using System.Collections.Generic;
using System.Linq;
using SecurityAndItPolicy = _360.Domain.CyberDetection.SecurityAndItPolicy;

namespace _360.Api.Facade.GBM.CyberDetection
{
    public static class SecurityAndItPolicyConverter
    {
        public static SecurityAndItPolicy Convert(this SecurityAndItPolicyDto securityAndItPolicyDto)
        {
            if (!securityAndItPolicyDto.IsAssigned())
            {
                return new SecurityAndItPolicy();
            }

            return new  SecurityAndItPolicy
            {
                
            };
        }
    }
}

