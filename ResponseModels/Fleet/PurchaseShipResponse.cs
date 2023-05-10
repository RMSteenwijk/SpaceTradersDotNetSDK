using SpaceTradersDotNetSDK.Models;
using SpaceTradersDotNetSDK.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SpaceTradersDotNetSDK.ResponseModels.Fleet
{
    [IsResponse]
    public class PurchaseShipResponse
    {
        public Agent Agent { get; set; }

        public Ship Ship { get; set; }

        public ShipyardTransaction Transaction { get; set; }
    }
}
