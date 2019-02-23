using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace test.Models
{
    public partial class Mon
    {
        [JsonProperty("Monsterdata")]
        public List<Monsterdatum> Monsterdata { get; set; }
    }

    public partial class Monsterdatum
    {
        [JsonProperty("MonsterName")]
        public string MonsterName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("health")]
        public long Health { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("difficulty")]
        public long Difficulty { get; set; }
    }
}
