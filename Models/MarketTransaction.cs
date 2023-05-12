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
    /// MarketTransaction
    /// </summary>
    [DataContract]
    public partial class MarketTransaction :  IEquatable<MarketTransaction>, IValidatableObject
    {
        /// <summary>
        /// The type of transaction.
        /// </summary>
        /// <value>The type of transaction.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum PURCHASE for value: PURCHASE
            /// </summary>
            [EnumMember(Value = "PURCHASE")]
            PURCHASE = 1,

            /// <summary>
            /// Enum SELL for value: SELL
            /// </summary>
            [EnumMember(Value = "SELL")]
            SELL = 2

        }

        /// <summary>
        /// The type of transaction.
        /// </summary>
        /// <value>The type of transaction.</value>
        [DataMember(Name="type", EmitDefaultValue=true)]
        public TypeEnum Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="MarketTransaction" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected MarketTransaction() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="MarketTransaction" /> class.
        /// </summary>
        /// <param name="waypointSymbol">The symbol of the waypoint where the transaction took place. (required).</param>
        /// <param name="shipSymbol">The symbol of the ship that made the transaction. (required).</param>
        /// <param name="tradeSymbol">The symbol of the trade good. (required).</param>
        /// <param name="type">The type of transaction. (required).</param>
        /// <param name="units">The number of units of the transaction. (required).</param>
        /// <param name="pricePerUnit">The price per unit of the transaction. (required).</param>
        /// <param name="totalPrice">The total price of the transaction. (required).</param>
        /// <param name="timestamp">The timestamp of the transaction. (required).</param>
        public MarketTransaction(string waypointSymbol = default(string), string shipSymbol = default(string), string tradeSymbol = default(string), TypeEnum type = default(TypeEnum), int units = default(int), int pricePerUnit = default(int), int totalPrice = default(int), DateTime timestamp = default(DateTime))
        {
            // to ensure "waypointSymbol" is required (not null)
            if (waypointSymbol == null)
            {
                throw new InvalidDataException("waypointSymbol is a required property for MarketTransaction and cannot be null");
            }
            else
            {
                this.WaypointSymbol = waypointSymbol;
            }

            // to ensure "shipSymbol" is required (not null)
            if (shipSymbol == null)
            {
                throw new InvalidDataException("shipSymbol is a required property for MarketTransaction and cannot be null");
            }
            else
            {
                this.ShipSymbol = shipSymbol;
            }

            // to ensure "tradeSymbol" is required (not null)
            if (tradeSymbol == null)
            {
                throw new InvalidDataException("tradeSymbol is a required property for MarketTransaction and cannot be null");
            }
            else
            {
                this.TradeSymbol = tradeSymbol;
            }

            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new InvalidDataException("type is a required property for MarketTransaction and cannot be null");
            }
            else
            {
                this.Type = type;
            }

            // to ensure "units" is required (not null)
            if (units == null)
            {
                throw new InvalidDataException("units is a required property for MarketTransaction and cannot be null");
            }
            else
            {
                this.Units = units;
            }

            // to ensure "pricePerUnit" is required (not null)
            if (pricePerUnit == null)
            {
                throw new InvalidDataException("pricePerUnit is a required property for MarketTransaction and cannot be null");
            }
            else
            {
                this.PricePerUnit = pricePerUnit;
            }

            // to ensure "totalPrice" is required (not null)
            if (totalPrice == null)
            {
                throw new InvalidDataException("totalPrice is a required property for MarketTransaction and cannot be null");
            }
            else
            {
                this.TotalPrice = totalPrice;
            }

            // to ensure "timestamp" is required (not null)
            if (timestamp == null)
            {
                throw new InvalidDataException("timestamp is a required property for MarketTransaction and cannot be null");
            }
            else
            {
                this.Timestamp = timestamp;
            }

        }

        /// <summary>
        /// The symbol of the waypoint where the transaction took place.
        /// </summary>
        /// <value>The symbol of the waypoint where the transaction took place.</value>
        [DataMember(Name="waypointSymbol", EmitDefaultValue=true)]
        public string WaypointSymbol { get; set; }

        /// <summary>
        /// The symbol of the ship that made the transaction.
        /// </summary>
        /// <value>The symbol of the ship that made the transaction.</value>
        [DataMember(Name="shipSymbol", EmitDefaultValue=true)]
        public string ShipSymbol { get; set; }

        /// <summary>
        /// The symbol of the trade good.
        /// </summary>
        /// <value>The symbol of the trade good.</value>
        [DataMember(Name="tradeSymbol", EmitDefaultValue=true)]
        public string TradeSymbol { get; set; }


        /// <summary>
        /// The number of units of the transaction.
        /// </summary>
        /// <value>The number of units of the transaction.</value>
        [DataMember(Name="units", EmitDefaultValue=true)]
        public int Units { get; set; }

        /// <summary>
        /// The price per unit of the transaction.
        /// </summary>
        /// <value>The price per unit of the transaction.</value>
        [DataMember(Name="pricePerUnit", EmitDefaultValue=true)]
        public int PricePerUnit { get; set; }

        /// <summary>
        /// The total price of the transaction.
        /// </summary>
        /// <value>The total price of the transaction.</value>
        [DataMember(Name="totalPrice", EmitDefaultValue=true)]
        public int TotalPrice { get; set; }

        /// <summary>
        /// The timestamp of the transaction.
        /// </summary>
        /// <value>The timestamp of the transaction.</value>
        [DataMember(Name="timestamp", EmitDefaultValue=true)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MarketTransaction {\n");
            sb.Append("  WaypointSymbol: ").Append(WaypointSymbol).Append("\n");
            sb.Append("  ShipSymbol: ").Append(ShipSymbol).Append("\n");
            sb.Append("  TradeSymbol: ").Append(TradeSymbol).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Units: ").Append(Units).Append("\n");
            sb.Append("  PricePerUnit: ").Append(PricePerUnit).Append("\n");
            sb.Append("  TotalPrice: ").Append(TotalPrice).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
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
            return this.Equals(input as MarketTransaction);
        }

        /// <summary>
        /// Returns true if MarketTransaction instances are equal
        /// </summary>
        /// <param name="input">Instance of MarketTransaction to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MarketTransaction input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.WaypointSymbol == input.WaypointSymbol ||
                    (this.WaypointSymbol != null &&
                    this.WaypointSymbol.Equals(input.WaypointSymbol))
                ) && 
                (
                    this.ShipSymbol == input.ShipSymbol ||
                    (this.ShipSymbol != null &&
                    this.ShipSymbol.Equals(input.ShipSymbol))
                ) && 
                (
                    this.TradeSymbol == input.TradeSymbol ||
                    (this.TradeSymbol != null &&
                    this.TradeSymbol.Equals(input.TradeSymbol))
                ) && 
                (
                    this.Type == input.Type ||
                    (this.Type != null &&
                    this.Type.Equals(input.Type))
                ) && 
                (
                    this.Units == input.Units ||
                    (this.Units != null &&
                    this.Units.Equals(input.Units))
                ) && 
                (
                    this.PricePerUnit == input.PricePerUnit ||
                    (this.PricePerUnit != null &&
                    this.PricePerUnit.Equals(input.PricePerUnit))
                ) && 
                (
                    this.TotalPrice == input.TotalPrice ||
                    (this.TotalPrice != null &&
                    this.TotalPrice.Equals(input.TotalPrice))
                ) && 
                (
                    this.Timestamp == input.Timestamp ||
                    (this.Timestamp != null &&
                    this.Timestamp.Equals(input.Timestamp))
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
                if (this.WaypointSymbol != null)
                    hashCode = hashCode * 59 + this.WaypointSymbol.GetHashCode();
                if (this.ShipSymbol != null)
                    hashCode = hashCode * 59 + this.ShipSymbol.GetHashCode();
                if (this.TradeSymbol != null)
                    hashCode = hashCode * 59 + this.TradeSymbol.GetHashCode();
                if (this.Type != null)
                    hashCode = hashCode * 59 + this.Type.GetHashCode();
                if (this.Units != null)
                    hashCode = hashCode * 59 + this.Units.GetHashCode();
                if (this.PricePerUnit != null)
                    hashCode = hashCode * 59 + this.PricePerUnit.GetHashCode();
                if (this.TotalPrice != null)
                    hashCode = hashCode * 59 + this.TotalPrice.GetHashCode();
                if (this.Timestamp != null)
                    hashCode = hashCode * 59 + this.Timestamp.GetHashCode();
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


            // Units (int) minimum
            if(this.Units < (int)1)
            {
                yield return new ValidationResult("Invalid value for Units, must be a value greater than or equal to 1.", new [] { "Units" });
            }



            // PricePerUnit (int) minimum
            if(this.PricePerUnit < (int)1)
            {
                yield return new ValidationResult("Invalid value for PricePerUnit, must be a value greater than or equal to 1.", new [] { "PricePerUnit" });
            }



            // TotalPrice (int) minimum
            if(this.TotalPrice < (int)1)
            {
                yield return new ValidationResult("Invalid value for TotalPrice, must be a value greater than or equal to 1.", new [] { "TotalPrice" });
            }

            yield break;
        }
    }

}