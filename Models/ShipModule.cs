/*
 * SpaceTraders API
 *
 * SpaceTraders is an open-universe game and learning platform that offers a set of HTTP endpoints to control a fleet of ships and explore a multiplayer universe.  The API is documented using [OpenAPI](https://github.com/SpaceTradersAPI/api-docs). You can send your first request right here in your browser to check the status of the game server.  ```json http {   \"method\": \"GET\",   \"url\": \"https://api.spacetraders.io/v2\", } ```  Unlike a traditional game, SpaceTraders does not have a first-party client or app to play the game. Instead, you can use the API to build your own client, write a script to automate your ships, or try an app built by the community.  We have a [Discord channel](https://discord.com/invite/jh6zurdWk5) where you can share your projects, ask questions, and get help from other players.   
 *
 * The version of the OpenAPI document: 2.0.0
 * Contact: joel@spacetraders.io
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
 

namespace SpaceTradersDotNetSDK.Models
{
    /// <summary>
    /// A module can be installed in a ship and provides a set of capabilities such as storage space or quarters for crew. Module installations are permanent.
    /// </summary>
    [DataContract]
    public partial class ShipModule :  IEquatable<ShipModule>, IValidatableObject
    {
        /// <summary>
        /// Defines Symbol
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum SymbolEnum
        {
            /// <summary>
            /// Enum MINERALPROCESSORI for value: MODULE_MINERAL_PROCESSOR_I
            /// </summary>
            [EnumMember(Value = "MODULE_MINERAL_PROCESSOR_I")]
            MINERALPROCESSORI = 1,

            /// <summary>
            /// Enum CARGOHOLDI for value: MODULE_CARGO_HOLD_I
            /// </summary>
            [EnumMember(Value = "MODULE_CARGO_HOLD_I")]
            CARGOHOLDI = 2,

            /// <summary>
            /// Enum CREWQUARTERSI for value: MODULE_CREW_QUARTERS_I
            /// </summary>
            [EnumMember(Value = "MODULE_CREW_QUARTERS_I")]
            CREWQUARTERSI = 3,

            /// <summary>
            /// Enum ENVOYQUARTERSI for value: MODULE_ENVOY_QUARTERS_I
            /// </summary>
            [EnumMember(Value = "MODULE_ENVOY_QUARTERS_I")]
            ENVOYQUARTERSI = 4,

            /// <summary>
            /// Enum PASSENGERCABINI for value: MODULE_PASSENGER_CABIN_I
            /// </summary>
            [EnumMember(Value = "MODULE_PASSENGER_CABIN_I")]
            PASSENGERCABINI = 5,

            /// <summary>
            /// Enum MICROREFINERYI for value: MODULE_MICRO_REFINERY_I
            /// </summary>
            [EnumMember(Value = "MODULE_MICRO_REFINERY_I")]
            MICROREFINERYI = 6,

            /// <summary>
            /// Enum OREREFINERYI for value: MODULE_ORE_REFINERY_I
            /// </summary>
            [EnumMember(Value = "MODULE_ORE_REFINERY_I")]
            OREREFINERYI = 7,

            /// <summary>
            /// Enum FUELREFINERYI for value: MODULE_FUEL_REFINERY_I
            /// </summary>
            [EnumMember(Value = "MODULE_FUEL_REFINERY_I")]
            FUELREFINERYI = 8,

            /// <summary>
            /// Enum SCIENCELABI for value: MODULE_SCIENCE_LAB_I
            /// </summary>
            [EnumMember(Value = "MODULE_SCIENCE_LAB_I")]
            SCIENCELABI = 9,

            /// <summary>
            /// Enum JUMPDRIVEI for value: MODULE_JUMP_DRIVE_I
            /// </summary>
            [EnumMember(Value = "MODULE_JUMP_DRIVE_I")]
            JUMPDRIVEI = 10,

            /// <summary>
            /// Enum JUMPDRIVEII for value: MODULE_JUMP_DRIVE_II
            /// </summary>
            [EnumMember(Value = "MODULE_JUMP_DRIVE_II")]
            JUMPDRIVEII = 11,

            /// <summary>
            /// Enum JUMPDRIVEIII for value: MODULE_JUMP_DRIVE_III
            /// </summary>
            [EnumMember(Value = "MODULE_JUMP_DRIVE_III")]
            JUMPDRIVEIII = 12,

            /// <summary>
            /// Enum WARPDRIVEI for value: MODULE_WARP_DRIVE_I
            /// </summary>
            [EnumMember(Value = "MODULE_WARP_DRIVE_I")]
            WARPDRIVEI = 13,

            /// <summary>
            /// Enum WARPDRIVEII for value: MODULE_WARP_DRIVE_II
            /// </summary>
            [EnumMember(Value = "MODULE_WARP_DRIVE_II")]
            WARPDRIVEII = 14,

            /// <summary>
            /// Enum WARPDRIVEIII for value: MODULE_WARP_DRIVE_III
            /// </summary>
            [EnumMember(Value = "MODULE_WARP_DRIVE_III")]
            WARPDRIVEIII = 15,

            /// <summary>
            /// Enum SHIELDGENERATORI for value: MODULE_SHIELD_GENERATOR_I
            /// </summary>
            [EnumMember(Value = "MODULE_SHIELD_GENERATOR_I")]
            SHIELDGENERATORI = 16,

            /// <summary>
            /// Enum SHIELDGENERATORII for value: MODULE_SHIELD_GENERATOR_II
            /// </summary>
            [EnumMember(Value = "MODULE_SHIELD_GENERATOR_II")]
            SHIELDGENERATORII = 17

        }

        /// <summary>
        /// Gets or Sets Symbol
        /// </summary>
        [DataMember(Name="symbol", EmitDefaultValue=true)]
        public SymbolEnum Symbol { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipModule" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ShipModule() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipModule" /> class.
        /// </summary>
        /// <param name="symbol">symbol (required).</param>
        /// <param name="capacity">capacity.</param>
        /// <param name="range">range.</param>
        /// <param name="name">name (required).</param>
        /// <param name="description">description.</param>
        /// <param name="requirements">requirements (required).</param>
        public ShipModule(SymbolEnum symbol = default(SymbolEnum), int capacity = default(int), int range = default(int), string name = default(string), string description = default(string), ShipRequirements requirements = default(ShipRequirements))
        {
            // to ensure "symbol" is required (not null)
            if (symbol == null)
            {
                throw new InvalidDataException("symbol is a required property for ShipModule and cannot be null");
            }
            else
            {
                this.Symbol = symbol;
            }

            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for ShipModule and cannot be null");
            }
            else
            {
                this.Name = name;
            }

            // to ensure "requirements" is required (not null)
            if (requirements == null)
            {
                throw new InvalidDataException("requirements is a required property for ShipModule and cannot be null");
            }
            else
            {
                this.Requirements = requirements;
            }

            this.Capacity = capacity;
            this.Range = range;
            this.Description = description;
        }


        /// <summary>
        /// Gets or Sets Capacity
        /// </summary>
        [DataMember(Name="capacity", EmitDefaultValue=false)]
        public int Capacity { get; set; }

        /// <summary>
        /// Gets or Sets Range
        /// </summary>
        [DataMember(Name="range", EmitDefaultValue=false)]
        public int Range { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Requirements
        /// </summary>
        [DataMember(Name="requirements", EmitDefaultValue=true)]
        public ShipRequirements Requirements { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ShipModule {\n");
            sb.Append("  Symbol: ").Append(Symbol).Append("\n");
            sb.Append("  Capacity: ").Append(Capacity).Append("\n");
            sb.Append("  Range: ").Append(Range).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Requirements: ").Append(Requirements).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ShipModule);
        }

        /// <summary>
        /// Returns true if ShipModule instances are equal
        /// </summary>
        /// <param name="input">Instance of ShipModule to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShipModule input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Symbol == input.Symbol ||
                    (this.Symbol != null &&
                    this.Symbol.Equals(input.Symbol))
                ) && 
                (
                    this.Capacity == input.Capacity ||
                    (this.Capacity != null &&
                    this.Capacity.Equals(input.Capacity))
                ) && 
                (
                    this.Range == input.Range ||
                    (this.Range != null &&
                    this.Range.Equals(input.Range))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Requirements == input.Requirements ||
                    (this.Requirements != null &&
                    this.Requirements.Equals(input.Requirements))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Symbol != null)
                    hashCode = hashCode * 59 + this.Symbol.GetHashCode();
                if (this.Capacity != null)
                    hashCode = hashCode * 59 + this.Capacity.GetHashCode();
                if (this.Range != null)
                    hashCode = hashCode * 59 + this.Range.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Requirements != null)
                    hashCode = hashCode * 59 + this.Requirements.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {


            // Capacity (int) minimum
            if(this.Capacity < (int)0)
            {
                yield return new ValidationResult("Invalid value for Capacity, must be a value greater than or equal to 0.", new [] { "Capacity" });
            }



            // Range (int) minimum
            if(this.Range < (int)0)
            {
                yield return new ValidationResult("Invalid value for Range, must be a value greater than or equal to 0.", new [] { "Range" });
            }

            yield break;
        }
    }

}
