using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GeoJsonEditor.Entities
{
    public class TimeLine
    {
        public int? ChildTimelines { get; set; }
        public float? ForkNode { get; set; }
        public float? FromDay { get; set; }
        public float? FromMonth { get; set; }
        public float? FromTimeUnit { get; set; }
        public float? FromYear { get; set; }
        public float? Height { get; set; }
        public string ParentTimelineId { get; set; }
        public string Regime { get; set; }
        public int? Sequence { get; set; }
        public string Threshold { get; set; }
        public float? ToDay { get; set; }
        public float? ToMonth { get; set; }
        public float? ToYear { get; set; }
        public float? ToTimeUnit { get; set; }
        public int? UniqueID { get; set; }
        [JsonProperty("__type")]
        public string Type { get; set; }
        [JsonProperty("end")]
        public float? End { get; set; }
        [JsonProperty("exhibits")]
        public Exhibit[] Exhibits { get; set; } = new Exhibit[0];
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("start")]
        public float? Start { get; set; }
        [JsonProperty("timelines")]
        public TimeLine[] TimeLines { get; set; } = new TimeLine[0];
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
