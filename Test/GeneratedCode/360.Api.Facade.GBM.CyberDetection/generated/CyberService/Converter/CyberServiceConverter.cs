using _360.Api.Facade.GBM.Core.Converters;
using _360.Api.Facade.GBM.Document.Converters;
using _360.Framework.Libs.Extensions;
using BusinessMap.Client.Rest.Models;
using System.Collections.Generic;
using System.Linq;
using CyberService = _360.Domain.CyberDetection.CyberService;

namespace _360.Api.Facade.GBM.CyberDetection
{
    public static class CyberServiceConverter
    {
        public static CyberService Convert(this CyberServiceDto cyberServiceDto)
        {
            if (!cyberServiceDto.IsAssigned())
            {
                return new CyberService();
            }

            return new  CyberService
            {
                
            };
        }
    }
}

