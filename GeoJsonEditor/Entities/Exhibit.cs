using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GeoJsonEditor.Entities
{
    public class Exhibit
    {
        [JsonProperty("contentItems")]
        public ContentItem[] ContentItems { get; set; } = new ContentItem[0];
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("parentTimelineId")]
        public string ParentTimeLineId { get; set; }
        [JsonProperty("time")]
        public float? Time { get; set; }
        [JsonProperty("parentTititilemelineId")]
        public string Title { get; set; }
    }
}
