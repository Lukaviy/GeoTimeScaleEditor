using System;
using GeoJsonEditor.Entities;

namespace GeoJsonEditor.VM
{
    public class ContentVM
    {
        private ContentItem _contentItem;
        private ExhibitVM _parent;

        public ContentVM(ContentItem contentItem, ExhibitVM parent)
        {
            _contentItem = contentItem;
            _parent = parent;
        }

        public ContentItem ContentItem => _contentItem;

        public ExhibitVM ParentExhibitVm => _parent;

        public string Title
        {
            get => _contentItem.Title;
            set => _contentItem.Title = value;
        }

        public string Uri
        {
            get => _contentItem.Uri;
            set => _contentItem.Uri = value;
        }

        public string Description {
            get => _contentItem.Description;
            set => _contentItem.Description = value;
        }

        public string MediaSource {
            get => _contentItem.MediaSource;
            set => _contentItem.MediaSource = value;
        }

        public MediaType MediaType {
            get => _contentItem.MediaType;
            set => _contentItem.MediaType = value;
        }
    }
}