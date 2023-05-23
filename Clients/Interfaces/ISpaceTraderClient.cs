using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Clients.Interfaces
{
    public interface ISpaceTraderClient
    {
        IRegisterClient Register { get; set; }
        IAgentsClient Agents { get; set; }
        IFactionsClient Factions { get; set; }
        IFleetClient Fleet { get; set; }
        IContractsClient Contracts { get; set; }
        ISystemsClient Systems { get; set; }

        void UpdateToken(string token);
    }
}
