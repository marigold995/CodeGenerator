using _360.Api.Facade.GBM.Core.Converters;
using _360.Api.Facade.GBM.Document.Converters;
using _360.Framework.Libs.Extensions;
using BusinessMap.Client.Rest.Models;
using System.Collections.Generic;
using System.Linq;
using ZoneProfile = _360.Domain.CyberDetection.ZoneProfile;

namespace _360.Api.Facade.GBM.CyberDetection
{
    public static class ZoneProfileConverter
    {
        public static ZoneProfile Convert(this ZoneProfileDto zoneProfileDto)
        {
            if (!zoneProfileDto.IsAssigned())
            {
                return new ZoneProfile();
            }

            return new  ZoneProfile
            {
                
            };
        }
    }
}

