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
    public class SellCargoResponse
    {
        public Agent Agent { get; set; }

        public ShipCargo ShipCargo { get; set; }

        public MarketTransaction Transaction { get; set; }  
    }
}
