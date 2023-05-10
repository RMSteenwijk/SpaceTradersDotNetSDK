using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpaceTradersDotNetSDK.ResponseModels
{
    public class GenericCargoItem
    {
        public string TradeSymbol { get; set; }
        public int Units { get; set; }
    }
}
