using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GeoJsonEditor.Entities
{
    public enum MediaType {
        Audio,
        Image,
        Pdf,
        Picture,
        Video
    }

    public class ContentItem
    {
        public int Order { get; set; }
        [JsonProperty("attribution")]
        public string Attribution { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("mediaSource")]
        public string MediaSource { get; set; }
        [JsonProperty("mediaType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MediaType MediaType { get; set; }
        [JsonProperty("parentExhibitId")]
        public string ParentExhibitId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    }
}