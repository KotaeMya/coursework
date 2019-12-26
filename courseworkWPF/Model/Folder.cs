using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace courseworkWPF.Model
{

    [Serializable]
    [XmlRoot(Namespace = "http://cpe.mitre.org/language/2.0")]
    public class Folder
    {
        private string _folderFromName; // имя папки за которой ведется слежка
        private FileSystemWatcher watcher;
        private DispatcherTimer timer;
        private ObservableCollection<OneEventLog> Logs = new ObservableCollection<OneEventLog>();
        public Folder()
        {
            CreateTimeWatch();
        }
        public string FolderFrom { get; set; }
        public string FolderTo { get; set; }
        private void CreateTimeWatch()
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
        public void InitWatcher()
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
            Logs.Add(new OneEventLog() { Event = WatcherChangeTypes.Renamed.ToString(), EventLog = notifyMessage });
            SerializeEventsLog();
        }
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            string notifyMessage;
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created:
                    notifyMessage = string.Format("По пути: {0}, файл создан: {1}, Действие: {2}", watcher.Path, e.Name, e.ChangeType);
                    NotifyWindow(notifyMessage);
                    Logs.Add(new OneEventLog() { Event = WatcherChangeTypes.Created.ToString(), EventLog = notifyMessage });
                    SerializeEventsLog();
                    return;
                case WatcherChangeTypes.Changed:
                    notifyMessage = string.Format("По пути: {0}, файл изменен: {1}, Действие: {2}", watcher.Path, e.Name, e.ChangeType);
                    NotifyWindow(notifyMessage);
                    Logs.Add(new OneEventLog() { Event = WatcherChangeTypes.Changed.ToString(), EventLog = notifyMessage });
                    SerializeEventsLog();
                    return;
                case WatcherChangeTypes.Deleted:
                    notifyMessage = string.Format("По пути: {0}, файл удален: {1}, Действие: {2}", watcher.Path, e.Name, e.ChangeType);
                    NotifyWindow(notifyMessage);
                    Logs.Add(new OneEventLog() { Event = WatcherChangeTypes.Deleted.ToString(), EventLog = notifyMessage });
                    SerializeEventsLog();
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
        private void NotifyWindow(string notifyMessage)
        {
            Thread threadWindow = null;
            threadWindow = new Thread(new ThreadStart(() =>
            {
                NotifyWindow notifyWindow = new NotifyWindow(notifyMessage);
                notifyWindow.Show();
                Dispatcher.Run();
            }));
            threadWindow.SetApartmentState(ApartmentState.STA);
            threadWindow.IsBackground = true;
            threadWindow.Start();
        }
        public void SerializeEventsLog()
        {
            SetFolderFormName();
            if (IsLogsEmpty())
                return;
            if (IsFile(string.Format("{0}.xml", _folderFromName)))
            {
                File.Delete(string.Format("{0}.xml", _folderFromName));
            }
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(ObservableCollection<OneEventLog>));
            using (FileStream fileStream = new FileStream(string.Format("{0}.xml", _folderFromName), FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(fileStream, Logs);
            }
        }

        private bool IsFile(string file)
        {
            return File.Exists(file);
        }

        private bool IsLogsEmpty()
        {
            return Logs.Count == 0;
        }

        public ObservableCollection<OneEventLog> DeserializeEventsLog()
        {
            SetFolderFormName();
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(ObservableCollection<OneEventLog>));
            using (FileStream fileStream = new FileStream(string.Format("{0}.xml", _folderFromName), FileMode.Open))
            {
                return (ObservableCollection<OneEventLog>)xmlFormatter.Deserialize(fileStream);
            }
        }
        public void InitLogs()
        {
            SetFolderFormName();
            if (!IsFile(string.Format("{0}.xml", _folderFromName)))
            {
                return;
            }
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(ObservableCollection<OneEventLog>));
            using (FileStream fileStream = new FileStream(string.Format("{0}.xml", _folderFromName), FileMode.Open))
            {
                Logs = (ObservableCollection<OneEventLog>)xmlFormatter.Deserialize(fileStream);
            }
        }
        public void SetFolderFormName()
        {
            var folderFromInfo = new DirectoryInfo(string.Format(@"{0}", FolderFrom));
            _folderFromName = folderFromInfo.Name;
        }
        public bool getLogCount()
        {
            if (IsLogsEmpty())
                return false;
            return true;
        }
    }
}
