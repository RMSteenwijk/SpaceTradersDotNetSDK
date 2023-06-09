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
    /// Extraction
    /// </summary>
    [DataContract]
    public partial class Extraction :  IEquatable<Extraction>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Extraction" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Extraction() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Extraction" /> class.
        /// </summary>
        /// <param name="shipSymbol">shipSymbol (required).</param>
        /// <param name="yield">yield (required).</param>
        public Extraction(string shipSymbol = default(string), ExtractionYield yield = default(ExtractionYield))
        {
            // to ensure "shipSymbol" is required (not null)
            if (shipSymbol == null)
            {
                throw new InvalidDataException("shipSymbol is a required property for Extraction and cannot be null");
            }
            else
            {
                this.ShipSymbol = shipSymbol;
            }

            // to ensure "yield" is required (not null)
            if (yield == null)
            {
                throw new InvalidDataException("yield is a required property for Extraction and cannot be null");
            }
            else
            {
                this.Yield = yield;
            }

        }

        /// <summary>
        /// Gets or Sets ShipSymbol
        /// </summary>
        [DataMember(Name="shipSymbol", EmitDefaultValue=true)]
        public string ShipSymbol { get; set; }

        /// <summary>
        /// Gets or Sets Yield
        /// </summary>
        [DataMember(Name="yield", EmitDefaultValue=true)]
        public ExtractionYield Yield { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Extraction {\n");
            sb.Append("  ShipSymbol: ").Append(ShipSymbol).Append("\n");
            sb.Append("  Yield: ").Append(Yield).Append("\n");
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
            return this.Equals(input as Extraction);
        }

        /// <summary>
        /// Returns true if Extraction instances are equal
        /// </summary>
        /// <param name="input">Instance of Extraction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Extraction input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ShipSymbol == input.ShipSymbol ||
                    (this.ShipSymbol != null &&
                    this.ShipSymbol.Equals(input.ShipSymbol))
                ) && 
                (
                    this.Yield == input.Yield ||
                    (this.Yield != null &&
                    this.Yield.Equals(input.Yield))
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
                if (this.ShipSymbol != null)
                    hashCode = hashCode * 59 + this.ShipSymbol.GetHashCode();
                if (this.Yield != null)
                    hashCode = hashCode * 59 + this.Yield.GetHashCode();
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

            // ShipSymbol (string) minLength
            if(this.ShipSymbol != null && this.ShipSymbol.Length < 1)
            {
                yield return new ValidationResult("Invalid value for ShipSymbol, length must be greater than 1.", new [] { "ShipSymbol" });
            }

            yield break;
        }
    }

}
