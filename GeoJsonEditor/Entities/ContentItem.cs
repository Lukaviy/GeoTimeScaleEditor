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
        public string Attribution { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string MediaSource { get; set; }
        public MediaType MediaType { get; set; }
        public string ParentExhibitId { get; set; }
        public string Title { get; set; }
        public string Uri { get; set; }
    }
}