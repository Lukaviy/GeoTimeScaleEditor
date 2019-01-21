using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GeoJsonEditor.Annotations;
using GeoJsonEditor.Entities;
using GeoJsonEditor.IO;
using GeoJsonEditor.Utility;
using GeoJsonEditor.VM;
using Microsoft.Win32;
using Newtonsoft.Json;
using Prism.Commands;

namespace GeoJsonEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ICommand _openCommand;
        private ICommand _saveCommand;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = this;


        }

        private void OpenFile()
        {
            var dialog = new OpenFileDialog();
            dialog.DefaultExt = ".json";

            dialog.Filter = "Json documents (.json)|*.json";

            var res = dialog.ShowDialog();

            if (res == true)
            {
                var fileName = dialog.FileName;

                try
                {
                    var timeLine = JsonImporter.Import(fileName);

                    Documents.Add(new DocumentVM(fileName, timeLine));
                } catch (JsonException e)
                {
                    MessageBox.Show($"There was errors while parse file: \n {e.Message}");
                }
            }
        }

        private void SaveFile()
        {
            var dialog = new SaveFileDialog();
            dialog.DefaultExt = ".json";

            dialog.Filter = "Json documents (.json)|*.json";

            var res = dialog.ShowDialog();

            if (res == true)
            {
                var fileName = dialog.FileName;

                JsonExporter.Export(SelectedDocument.TimeLine, fileName);
            }
        }

        public ObservableCollection<DocumentVM> Documents { get; } = new ObservableCollection<DocumentVM>();

        public DocumentVM SelectedDocument { get; set; }

        public object SelectedObject { get; set; }

        public ICommand OpenCommand => _openCommand ?? (_openCommand = new DelegateCommand(OpenFile));
        public ICommand SaveCommand => _saveCommand ?? (_saveCommand = new DelegateCommand(SaveFile));

        private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SelectedObject = e.NewValue;
            OnPropertyChanged(nameof(SelectedObject));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ButtonAddExhibit_OnClick(object sender, RoutedEventArgs e)
        {
            var timeLineVm = (sender as Button).DataContext as TimeLineVM;
            var parentTimeLineId = timeLineVm.Id;
            var guid = IdGenerator.GenerateNewId();

            var exhibit = new Exhibit {ParentTimeLineId = parentTimeLineId, Id = guid, Title = "Unnamed Exhibit"};

            timeLineVm.AddExhibit(exhibit);
        }

        private void ButtonRemoveExhibit_OnClick(object sender, RoutedEventArgs e)
        {
            var exhibitVm = (sender as Button).DataContext as ExhibitVM;

            exhibitVm.ParenTimeLineVm.RemoveExhibit(exhibitVm.Exhibit);
        }

        private void ButtonAddTimeLine_OnClick(object sender, RoutedEventArgs e)
        {
            var timeLineVm = (sender as Button).DataContext as TimeLineVM;
            var parentTimeLineId = timeLineVm.Id;
            var guid = IdGenerator.GenerateNewId();

            var timeLine = new TimeLine { ParentTimelineId = parentTimeLineId, Id = guid, Title = "Unnamed Timeline" };

            timeLineVm.AddTimeLine(timeLine);
        }

        private void ButtonRemoveTimeLine_OnClick(object sender, RoutedEventArgs e)
        {
            var timeLineVm = (sender as Button).DataContext as TimeLineVM;

            if (timeLineVm.ParenTimeLineVm == null)
            {
                MessageBox.Show("Can't remove root TimeLine");
                return;
            }

            timeLineVm.ParenTimeLineVm.RemoveTimeLine(timeLineVm.TimeLine);
        }

        private void ButtonAddContent_OnClick(object sender, RoutedEventArgs e)
        {
            var exhibitVm = (sender as Button).DataContext as ExhibitVM;
            var parentExhibitId = exhibitVm.Exhibit.Id;
            var guid = IdGenerator.GenerateNewId();

            var content = new ContentItem { ParentExhibitId = parentExhibitId, Id = guid, Title = "Unnamed Content" };

            exhibitVm.AddContent(content);
        }

        private void ButtonRemoveContent_OnClick(object sender, RoutedEventArgs e)
        {
            var contentVm = (sender as Button).DataContext as ContentVM;

            contentVm.ParentExhibitVm.RemoveContent(contentVm.ContentItem);
        }
    }
}
