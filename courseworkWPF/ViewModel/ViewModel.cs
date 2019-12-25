using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
            if (!Directory.Exists(this.FolderFrom))
                return;
            if (!Directory.Exists(this.FolderTo))
                return;

            Model.Folder newSynch = new Model.Folder() { FolderFrom = this.FolderFrom, FolderTo = this.FolderTo };
            if (Folders.Count != 0)
                foreach (Model.Folder item in Folders)
                {
                    if (newSynch.FolderFrom == item.FolderFrom && newSynch.FolderTo == item.FolderTo)
                        return;
                }
            Folders.Add(newSynch);
            Folders[Folders.Count - 1].InitWatcher();
            Folders[Folders.Count - 1].InitLogs();
        }
        public void DeleteSynch(object obj, int index)
        {
            if (obj == null)
                return;
            var synch = (Model.Folder)obj;
            synch.StopWatch();
            Folders.RemoveAt(index);
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
