using SpaceTradersDotNetSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Clients.Interfaces
{
    public interface IAgentsClient
    {
        Task<Agent> GetMyAgentAsync();
    }
}
