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
    public class CreateSurveyResponse
    {
        public Cooldown Cooldown { get; set; }

        public List<Survey> Surveys { get; set; }
    }
}
