using Newtonsoft.Json;
using SpaceTradersDotNetSDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.ResponseModels
{
    public class CooldownErrorResponse
    {
        public ErrorMessage Error { get; set; }
    }

    public class ErrorMessage
    {
        public string Message { get; set; }

        public int Code { get; set;}

        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("cooldown")]
        public Cooldown Cooldown { get; set; }
    }
}
