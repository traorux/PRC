using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PRC.CORE.Media.Call.Types
{
    public class HuntingGroupStatus
    {
        /// <summary>
        /// This property indicates whether the user is logged in the hunting group.
        /// </summary>
        /// <value>
        /// A <see langword="bool"/> value that indicates whether the user is logged.
        /// </value>
        [JsonPropertyName("Logon")]
        public bool LogonOn { get; init; }
    }
}
