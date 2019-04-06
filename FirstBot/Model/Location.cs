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
    /// Location
    /// </summary>
    [DataContract]
    public partial class Location : IEquatable<Location>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public Location()
        {
        }
        
        public Location(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        //public static Location operator -(Location location) {
        //    return this.M
        //}


        public Location Minus(Location location) =>
               new Location
               {
                   X = this.X - location.X,
                   Y = this.Y - location.Y,
                   Z = this.Z - location.Z
               };

        public Location Plus(Location location) =>
                 new Location
                 {
                     X = this.X + location.X,
                     Y = this.Y + location.Y,
                     Z = this.Z + location.Z
                 };


        /// <summary>
        /// Gets or Sets X
        /// </summary>
        [DataMember(Name = "X", EmitDefaultValue = false)]
        public int? X { get; set; }

        /// <summary>
        /// Gets or Sets Y
        /// </summary>
        [DataMember(Name = "Y", EmitDefaultValue = false)]
        public int? Y { get; set; }

        /// <summary>
        /// Gets or Sets Z
        /// </summary>
        [DataMember(Name = "Z", EmitDefaultValue = false)]
        public int? Z { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Location {\n");
            sb.Append("  X: ").Append(X).Append("\n");
            sb.Append("  Y: ").Append(Y).Append("\n");
            sb.Append("  Z: ").Append(Z).Append("\n");
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
            return this.Equals(input as Location);
        }

        /// <summary>
        /// Returns true if Location instances are equal
        /// </summary>
        /// <param name="input">Instance of Location to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Location input)
        {
            if (input == null)
                return false;

            return
                (
                    this.X == input.X ||
                    (this.X != null &&
                    this.X.Equals(input.X))
                ) &&
                (
                    this.Y == input.Y ||
                    (this.Y != null &&
                    this.Y.Equals(input.Y))
                ) &&
                (
                    this.Z == input.Z ||
                    (this.Z != null &&
                    this.Z.Equals(input.Z))
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
                if (this.X != null)
                    hashCode = hashCode * 59 + this.X.GetHashCode();
                if (this.Y != null)
                    hashCode = hashCode * 59 + this.Y.GetHashCode();
                if (this.Z != null)
                    hashCode = hashCode * 59 + this.Z.GetHashCode();
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
