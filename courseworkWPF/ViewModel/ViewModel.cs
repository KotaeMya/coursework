using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace courseworkWPF.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        private string _folderFrom;
        private string _forlderTo;
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
        public ObservableCollection<Model.Folder> Folders { get; set; }
        public ObservableCollection<Model.OneEventLog> OneEventLogs { get; set; }
        public ViewModel()
        {
            Folders = new ObservableCollection<Model.Folder>();
            OneEventLogs = new ObservableCollection<Model.OneEventLog>();
        }
        public void AddSynch()
        {
            if (!IsFolder(this.FolderFrom))
                return;
            if (!IsFolder(this.FolderTo))
                return;

            Model.Folder newSynch = new Model.Folder() { FolderFrom = this.FolderFrom, FolderTo = this.FolderTo };
            if (IsNotFoldesEmpty())
                foreach (Model.Folder item in Folders)
                {
                    if (IsSynchronizationAlreadyExists(newSynch, item))
                        return;
                }
            Folders.Add(newSynch);
            Folders[Folders.Count - 1].InitWatcher();
            Folders[Folders.Count - 1].InitLogs();
        }

        private bool IsSynchronizationAlreadyExists(Model.Folder newSynch, Model.Folder item)
        {
            return newSynch.FolderFrom == item.FolderFrom && newSynch.FolderTo == item.FolderTo;
        }

        private bool IsNotFoldesEmpty()
        {
            return Folders.Count != 0;
        }

        private bool IsFolder(string folder)
        {
            return Directory.Exists(folder);
        }

        public void DeleteSynch(object obj, int index)
        {
            if (IsNull(obj))
                return;
            var synch = (Model.Folder)obj;
            synch.StopWatch();
            Folders.RemoveAt(index);
        }

        private bool IsNull(object obj)
        {
            return obj == null;
        }

        public bool IsSerializeble(int indexOfListItem)
        {
            try
            {
                if (Folders[indexOfListItem].getLogCount())
                    return true;
            }
            catch(Exception e)
            {
                return false;
            }
            return false;
        }
        public void getDeserializeEventsLog(int i)
        {
            OneEventLogs.Clear();
            foreach (var item in Folders[i].DeserializeEventsLog())
            {
                OneEventLogs.Add(item);
            }
        }
        public void getEventLogs(int i, string e)
        {
            OneEventLogs.Clear();
            foreach (var item in Folders[i].DeserializeEventsLog().Where(item => item.Event == e))
            {
                OneEventLogs.Add(item);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
