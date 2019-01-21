using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoJsonEditor.Entities
{
    public class TimeLine
    {
        public int? ChildTimeLines { get; set; }
        public float ForkNode { get; set; }
        public float? FromDay { get; set; }
        public float? FromMonth { get; set; }
        public float? FromTimeUnity { get; set; }
        public float? FromYear { get; set; }
        public float? Height { get; set; }
        public string ParentTimelineId { get; set; }
        public string Regime { get; set; }
        public int? Sequence { get; set; }
        public string Threshold { get; set; }
        public float? ToDay { get; set; }
        public float? ToYear { get; set; }
        public int? UniquieID { get; set; }
        public string Type { get; set; }
        public float? End { get; set; }
        public Exhibit[] Exhibits { get; set; } = new Exhibit[0];
        public string Id { get; set; }
        public float? Start { get; set; }
        public TimeLine[] TimeLines { get; set; } = new TimeLine[0];
        public string Title { get; set; }
    }
}
