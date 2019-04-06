using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace FirstBot.Model
{
    /// <summary>
    /// Player&#39;s desired direction.
    /// </summary>
    /// <value>Player&#39;s desired direction.</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DirectionEnum
    {

        /// <summary>
        /// Enum West for value: West
        /// </summary>
        [EnumMember(Value = "West")]
        West = 1,

        /// <summary>
        /// Enum NorthWest for value: NorthWest
        /// </summary>
        [EnumMember(Value = "NorthWest")]
        NorthWest = 2,

        /// <summary>
        /// Enum NorthEast for value: NorthEast
        /// </summary>
        [EnumMember(Value = "NorthEast")]
        NorthEast = 3,

        /// <summary>
        /// Enum East for value: East
        /// </summary>
        [EnumMember(Value = "East")]
        East = 4,

        /// <summary>
        /// Enum SouthEast for value: SouthEast
        /// </summary>
        [EnumMember(Value = "SouthEast")]
        SouthEast = 5,

        /// <summary>
        /// Enum SouthWest for value: SouthWest
        /// </summary>
        [EnumMember(Value = "SouthWest")]
        SouthWest = 6
    }

    public static class DirectionEnumExtension
    {
        public static DirectionEnum Next(this DirectionEnum cur)
        {
            if (cur == DirectionEnum.West)
                return DirectionEnum.NorthWest;
            if (cur == DirectionEnum.NorthWest)
                return DirectionEnum.NorthEast;
            if (cur == DirectionEnum.NorthEast)
                return DirectionEnum.East;
            if (cur == DirectionEnum.East)
                return DirectionEnum.SouthEast;
            if (cur == DirectionEnum.SouthEast)
                return DirectionEnum.SouthWest;

            return DirectionEnum.West;
        }
    }
}
