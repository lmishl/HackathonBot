/* 
 * MskDotNet.Race API
 *
 * MskDotNet.Race
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
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
using SwaggerDateConverter = IO.Swagger.Client.SwaggerDateConverter;

namespace IO.Swagger.Model
{
    /// <summary>
    /// ValueTupleLocationSurfaceType
    /// </summary>
    [DataContract]
    public partial class ValueTupleLocationSurfaceType :  IEquatable<ValueTupleLocationSurfaceType>, IValidatableObject
    {
        /// <summary>
        /// Defines Item2
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum Item2Enum
        {
            
            /// <summary>
            /// Enum Empty for value: Empty
            /// </summary>
            [EnumMember(Value = "Empty")]
            Empty = 1,
            
            /// <summary>
            /// Enum Rock for value: Rock
            /// </summary>
            [EnumMember(Value = "Rock")]
            Rock = 2,
            
            /// <summary>
            /// Enum DangerousArea for value: DangerousArea
            /// </summary>
            [EnumMember(Value = "DangerousArea")]
            DangerousArea = 3,
            
            /// <summary>
            /// Enum Pit for value: Pit
            /// </summary>
            [EnumMember(Value = "Pit")]
            Pit = 4
        }

        /// <summary>
        /// Gets or Sets Item2
        /// </summary>
        [DataMember(Name="Item2", EmitDefaultValue=false)]
        public Item2Enum? Item2 { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueTupleLocationSurfaceType" /> class.
        /// </summary>
        /// <param name="item1">item1.</param>
        /// <param name="item2">item2.</param>
        public ValueTupleLocationSurfaceType(Location item1 = default(Location), Item2Enum? item2 = default(Item2Enum?))
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }
        
        /// <summary>
        /// Gets or Sets Item1
        /// </summary>
        [DataMember(Name="Item1", EmitDefaultValue=false)]
        public Location Item1 { get; set; }


        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ValueTupleLocationSurfaceType {\n");
            sb.Append("  Item1: ").Append(Item1).Append("\n");
            sb.Append("  Item2: ").Append(Item2).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ValueTupleLocationSurfaceType);
        }

        /// <summary>
        /// Returns true if ValueTupleLocationSurfaceType instances are equal
        /// </summary>
        /// <param name="input">Instance of ValueTupleLocationSurfaceType to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ValueTupleLocationSurfaceType input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Item1 == input.Item1 ||
                    (this.Item1 != null &&
                    this.Item1.Equals(input.Item1))
                ) && 
                (
                    this.Item2 == input.Item2 ||
                    (this.Item2 != null &&
                    this.Item2.Equals(input.Item2))
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
                if (this.Item1 != null)
                    hashCode = hashCode * 59 + this.Item1.GetHashCode();
                if (this.Item2 != null)
                    hashCode = hashCode * 59 + this.Item2.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
