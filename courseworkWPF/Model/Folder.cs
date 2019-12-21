using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace courseworkWPF.Model
{
    class Folder : INotifyPropertyChanged
    {
        private string _folderFrom;
        private string _forlderTo;
        FileSystemWatcher watcher;
        public string FolderFrom
        {
            get { return _folderFrom; }
            set
            {
                _folderFrom = value;
                OnPropertyChanged(nameof(FolderFrom));
            }
        }
        public string FolderTo
        {
            get { return _forlderTo; }
            set
            {
                _forlderTo = value;
                OnPropertyChanged(nameof(FolderTo));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        public void initWatcher()
        {
            watcher = new FileSystemWatcher();
            watcher.Path = this.FolderFrom;
            watcher.NotifyFilter = NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;
            watcher.Filter = "*.*";
            watcher.Changed += OnChanged;
            watcher.Created += OnChanged;
            watcher.Deleted += OnChanged;
            watcher.Renamed += OnRenamed;
            watcher.EnableRaisingEvents = true;
        }
        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            NotifyWindow(string.Format("По пути: {0}, файл переименован: {1}, Действие: {2}", watcher.Path, e.Name, e.ChangeType));
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            switch (e.ChangeType.ToString())
            {
                case "Created":
                    NotifyWindow(string.Format("По пути: {0}, файл создан: {1}, Действие: {2}", watcher.Path, e.Name, e.ChangeType));
                    return;
                case "Changed":
                    NotifyWindow(string.Format("По пути: {0}, файл изменен: {1}, Действие: {2}", watcher.Path, e.Name, e.ChangeType));
                    return;
                case "Deleted":
                    NotifyWindow(string.Format("По пути: {0}, файл удален: {1}, Действие: {2}", watcher.Path, e.Name, e.ChangeType));
                    return;
                default: return;
            }
        }
        private void NotifyWindow(string notify)
        {
            Thread threadWindow = null;
            threadWindow = new Thread(new ThreadStart(() =>
            {
                // create and show the window
                NotifyWindow notifyWindow = new NotifyWindow(
                    notify,
                    threadWindow
                    );
                notifyWindow.Show();
                // start the Dispatcher processing
                System.Windows.Threading.Dispatcher.Run();
            }));
            // set the apartment state  
            threadWindow.SetApartmentState(ApartmentState.STA);
            // make the thread a background thread  
            //newWindowThread.IsBackground = true;
            // start the thread  
            threadWindow.Start();
        }
    }
}
