﻿using Mapping_Tools.Annotations;
using Mapping_Tools.Classes.SystemTools;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Mapping_Tools.Views {
    /// <summary>
    /// Interaction logic for BeatmapImportDialog.xaml
    /// </summary>
    public partial class BeatmapImportDialog : INotifyPropertyChanged {
        private string _path;

        public string Path {
            get => _path;
            set {
                if (_path == value) return;
                _path = value;
                OnPropertyChanged();
            }
        }

        public BeatmapImportDialog() {
            InitializeComponent();
            DataContext = this;
            Path = MainWindow.AppWindow.GetCurrentMaps().FirstOrDefault() ?? "";
        }

        private void BeatmapBrowse_Click(object sender, RoutedEventArgs e) {
            string[] paths = IOHelper.BeatmapFileDialog();
            if( paths.Length != 0 ) { Path = paths[0]; }
        }

        private void BeatmapLoad_Click(object sender, RoutedEventArgs e) {
            string path = IOHelper.GetCurrentBeatmap();
            if( path != "" ) { Path = path; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
