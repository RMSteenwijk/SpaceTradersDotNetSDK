using SpaceTradersDotNetSDK.Models;
using SpaceTradersDotNetSDK.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.ResponseModels.Fleet
{
    [IsResponse]
    public class ExtractResourcesResponse
    {
        public Extraction Extraction { get; set; }

        public ShipCargo Cargo { get; set; }

        public Cooldown Cooldown { get; set; }
    }
}
