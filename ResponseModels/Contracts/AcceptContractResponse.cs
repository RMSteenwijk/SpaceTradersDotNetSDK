using SpaceTradersDotNetSDK.Models;
using SpaceTradersDotNetSDK.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.ResponseModels.Contracts
{
    [IsResponse]
    public class AcceptContractResponse
    {
        public Agent Agent { get; set; }

        public Contract Contract { get; set; }
    }
}
