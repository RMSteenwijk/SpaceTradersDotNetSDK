using SpaceTradersDotNetSDK.Models;
using SpaceTradersDotNetSDK.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpaceTradersDotNetSDK.ResponseModels.Fleet
{
    [IsResponse]
    public class ShipRefineResponse
    {
        public ShipCargo Cargo { get; set; }

        public Cooldown Cooldown { get; set; }

        public List<GenericCargoItem> Produced { get; set; }

        public List<GenericCargoItem> Consumed { get; set; }
    }
}
