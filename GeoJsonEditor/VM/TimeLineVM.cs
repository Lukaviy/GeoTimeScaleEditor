using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoJsonEditor.Entities;

namespace GeoJsonEditor.VM
{
    public class TimeLineVM
    {
        private TimeLine _timeLine;
        private ObservableCollection<TimeLineVM> _timeLines;
        private ObservableCollection<ExhibitVM> _exhibits;
        private TimeLineVM _parent;

        public TimeLineVM(TimeLine timeLine, TimeLineVM parent)
        {
            _timeLine = timeLine;
            _timeLines = new ObservableCollection<TimeLineVM>();
            _exhibits = new ObservableCollection<ExhibitVM>();
            _parent = parent;

            if (timeLine.TimeLines != null)
            {
                foreach (var timeLineTimeLine in timeLine.TimeLines)
                {
                    _timeLines.Add(new TimeLineVM(timeLineTimeLine, this));
                }
            }

            if (_timeLine.Exhibits != null)
            {
                foreach (var timeLineExhibit in _timeLine.Exhibits)
                {
                    _exhibits.Add(new ExhibitVM(timeLineExhibit, this));
                }
            }
        }

        public TimeLineVM ParenTimeLineVm => _parent;
        public TimeLine TimeLine => _timeLine;

        public string Id
        {
            get => _timeLine.Id;
            set => _timeLine.Id = value;
        }

        public string Title
        {
            get => _timeLine.Title;
            set => _timeLine.Title = value;
        }

        public float Height
        {
            get => _timeLine.Height.GetValueOrDefault(0);
            set => _timeLine.Height = value;
        }

        public string Region
        {
            get => _timeLine.Regime;
            set => _timeLine.Regime = value;
        }

        public long Start
        {
            get => (long)_timeLine.Start.GetValueOrDefault(0);
            set => _timeLine.Start = value;
        }

        public long End {
            get => (long)_timeLine.End.GetValueOrDefault(0);
            set => _timeLine.End = value;
        }

        public ObservableCollection<TimeLineVM> TimeLines => _timeLines;
        public ObservableCollection<ExhibitVM> Exhibits => _exhibits;

        public void AddExhibit(Exhibit exhibit)
        {
            _exhibits.Add(new ExhibitVM(exhibit, this));
            _timeLine.Exhibits = _timeLine.Exhibits.Concat(new[] {exhibit}).ToArray();
        }

        public void RemoveExhibit(Exhibit exhibit)
        {
            _exhibits.Remove(_exhibits.First(x => x.Exhibit.Id == exhibit.Id));
            _timeLine.Exhibits = _timeLine.Exhibits.Where(x => x.Id != exhibit.Id).ToArray();
        }

        public void AddTimeLine(TimeLine timeLine)
        {
            _timeLines.Add(new TimeLineVM(timeLine, this));
            _timeLine.TimeLines = _timeLine.TimeLines.Concat(new[] { timeLine }).ToArray();
        }

        public void RemoveTimeLine(TimeLine timeLine)
        {
            _timeLines.Remove(_timeLines.First(x => x._timeLine.Id == timeLine.Id));
            _timeLine.TimeLines = _timeLine.TimeLines.Where(x => x.Id != timeLine.Id).ToArray();
        }
    }
}
