using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using GeoJsonEditor.Entities;

namespace GeoJsonEditor.VM
{
    public class ExhibitVM
    {
        private Exhibit _exhibit;

        private ObservableCollection<ContentVM> _content;
        private TimeLineVM _parent;

        public ExhibitVM(Exhibit exhibit, TimeLineVM parent)
        {
            _exhibit = exhibit;

            _content = new ObservableCollection<ContentVM>();

            if (_exhibit.ContentItems != null)
            {
                foreach (var exhibitContentItem in _exhibit.ContentItems)
                {
                    _content.Add(new ContentVM(exhibitContentItem, this));
                }
            }

            _parent = parent;
        }

        public string Title
        {
            get => _exhibit.Title;
            set => _exhibit.Title = value;
        }

        public long Time {
            get => (long)_exhibit.Time.GetValueOrDefault(0);
            set => _exhibit.Time = value;
        }

        public ObservableCollection<ContentVM> Content => _content;

        public Exhibit Exhibit => _exhibit;

        public TimeLineVM ParenTimeLineVm => _parent;

        public void AddContent(ContentItem content)
        {
            Content.Add(new ContentVM(content, this));
            _exhibit.ContentItems = _exhibit.ContentItems.Concat(new[] {content}).ToArray();
        }

        public void RemoveContent(ContentItem item)
        {
            Content.Remove(Content.First(x => x.ContentItem.Id == item.Id));
            _exhibit.ContentItems = _exhibit.ContentItems.Where(x => x.Id != item.Id).ToArray();
        }
    }
}