using SpaceTradersDotNetSDK.Models;
using SpaceTradersDotNetSDK.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpaceTradersDotNetSDK.ResponseModels
{
    public class RegisterResponse
    {
        /// <summary>
        /// A Bearer token for accessing secured API endpoints.
        /// </summary>
        /// <value>A Bearer token for accessing secured API endpoints.</value>
        public string Token { get; set; }

        /// <summary>
        /// Gets or Sets Agent
        /// </summary>
        public Agent Agent { get; set; }

        /// <summary>
        /// Gets or Sets Contract
        /// </summary>
        public Contract Contract { get; set; }

        /// <summary>
        /// Gets or Sets Faction
        /// </summary>
        public Faction Faction { get; set; }

        /// <summary>
        /// Gets or Sets Ship
        /// </summary>
        public Ship Ship { get; set; }

    }
}
