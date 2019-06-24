using _360.Api.Facade.GBM.Core.Converters;
using _360.Api.Facade.GBM.Document.Converters;
using _360.Framework.Libs.Extensions;
using BusinessMap.Client.Rest.Models;
using System.Collections.Generic;
using System.Linq;
using CyberDetectionProfile = _360.Domain.CyberDetection.CyberDetectionProfile;

namespace _360.Api.Facade.GBM.CyberDetection
{
    public static class CyberDetectionProfileConverter
    {
        public static CyberDetectionProfile Convert(this CyberDetectionProfileDto cyberDetectionProfileDto)
        {
            if (!cyberDetectionProfileDto.IsAssigned())
            {
                return new CyberDetectionProfile();
            }

            return new  CyberDetectionProfile
            {
                
            };
        }
    }
}

