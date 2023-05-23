﻿using SpaceTradersDotNetSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Clients.Interfaces
{
    public interface IFactionsClient
    {
        Task<List<Faction>> ListFactionsAsync(int limit = 20, int page = 1);
        Task<Faction> GetFactionAsync(string factionSymbol);
    }
}
