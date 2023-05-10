using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradersDotNetSDK.Models.Enums
{
    public enum FactionType
    {
        /// <summary>
        /// Enum COSMIC for value: COSMIC
        /// </summary>
        [EnumMember(Value = "COSMIC")]
        COSMIC = 1,

        /// <summary>
        /// Enum VOID for value: VOID
        /// </summary>
        [EnumMember(Value = "VOID")]
        VOID = 2,

        /// <summary>
        /// Enum GALACTIC for value: GALACTIC
        /// </summary>
        [EnumMember(Value = "GALACTIC")]
        GALACTIC = 3,

        /// <summary>
        /// Enum QUANTUM for value: QUANTUM
        /// </summary>
        [EnumMember(Value = "QUANTUM")]
        QUANTUM = 4,

        /// <summary>
        /// Enum DOMINION for value: DOMINION
        /// </summary>
        [EnumMember(Value = "DOMINION")]
        DOMINION = 5

    }
}
