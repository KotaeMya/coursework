using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace courseworkWPF.Model
{
    class Folder : INotifyPropertyChanged
    {
        private string _folderFrom;
        private string _forlderTo;
        private FileSystemWatcher watcher;
        private DispatcherTimer timer;
        List<string> Log = new List<string>();

        public Folder()
        {
            TimeWatch();
        }

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
        private void TimeWatch()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(CopyFolder);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
        }
        public void StopWatch()
        {
            timer.Stop();
            watcher.Dispose();
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
            string notifyMessage = string.Format("По пути: {0}, файл переименован: {1}, Действие: {2}", watcher.Path, e.Name, e.ChangeType);
            NotifyWindow(notifyMessage);
            Log.Add(notifyMessage);
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            string notifyMessage;
            switch (e.ChangeType.ToString())
            {
                case "Created":
                    notifyMessage = string.Format("По пути: {0}, файл создан: {1}, Действие: {2}", watcher.Path, e.Name, e.ChangeType);
                    NotifyWindow(notifyMessage);
                    Log.Add(notifyMessage);
                    return;
                case "Changed":
                    notifyMessage = string.Format("По пути: {0}, файл изменен: {1}, Действие: {2}", watcher.Path, e.Name, e.ChangeType);
                    NotifyWindow(notifyMessage);
                    Log.Add(notifyMessage);
                    return;
                case "Deleted":
                    notifyMessage = string.Format("По пути: {0}, файл удален: {1}, Действие: {2}", watcher.Path, e.Name, e.ChangeType);
                    NotifyWindow(notifyMessage);
                    Log.Add(notifyMessage);
                    return;
                default: return;
            }
        }
        private void CopyFolder(Object sender, EventArgs e)
        {
            DirectoryInfo source = new DirectoryInfo(string.Format(@"{0}", FolderFrom));
            DirectoryInfo destin = new DirectoryInfo(string.Format(@"{0}", FolderTo));
            CopySubDirectoryes(source, destin);
        }

        static void CopySubDirectoryes(DirectoryInfo source, DirectoryInfo destination)
        {
            if (!destination.Exists)
            {
                destination.Create();
            }

            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(destination.FullName, file.Name), true);
            }

            DirectoryInfo[] dirs = source.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                string destinationDir = Path.Combine(destination.FullName, dir.Name);
                CopySubDirectoryes(dir, new DirectoryInfo(destinationDir));
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
