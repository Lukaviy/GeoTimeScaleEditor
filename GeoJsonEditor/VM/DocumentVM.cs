using System.Collections.ObjectModel;
using System.IO;
using GeoJsonEditor.Entities;

namespace GeoJsonEditor.VM
{
    public class DocumentVM
    {
        private string _path;
        private TimeLine _timeLine;

        public DocumentVM(string path, TimeLine timeLine)
        {
            _path = path;
            _timeLine = timeLine;
            TimeLineVM = new TimeLineVM(timeLine, null);
            TimeLines = new ObservableCollection<TimeLineVM> {TimeLineVM};
        }

        public TimeLineVM TimeLineVM { get; set; }

        public TimeLine TimeLine => _timeLine;

        public ObservableCollection<TimeLineVM> TimeLines { get; }

        public string Name => Path.GetFileName(_path);

        public string FilePath => _path;
    }
}