using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoJsonEditor.Entities
{
    public class Exhibit
    {
        public ContentItem[] ContentItems { get; set; } = new ContentItem[0];
        public string Id { get; set; }
        public string ParentTimeLineId { get; set; }
        public float? Time { get; set; }
        public string Title { get; set; }
    }
}
