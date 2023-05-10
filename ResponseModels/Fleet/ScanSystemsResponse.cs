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
    public class ScanResponse
    {
        public Cooldown Cooldown { get; set; }

        public List<ScannedSystem> Systems { get; set; }
        public List<ScannedWaypoint> Waypoints { get; set; }
        public List<ScannedShip> Ships { get; set; }
    }
}
