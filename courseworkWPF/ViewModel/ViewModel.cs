using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
        public ViewModel()
        {
            Folders = new ObservableCollection<Model.Folder>
            {
                //new Model.Folder { FolderFrom = "folder1", FolderTo = "folder1" },
                //new Model.Folder { FolderFrom = "folder2", FolderTo = "folder2" },
                //new Model.Folder { FolderFrom = "folder3", FolderTo = "folder3" }
            };
        }
        public void AddSynch()
        {
            Model.Folder newSynch = new Model.Folder() { FolderFrom = this.FolderFrom, FolderTo = this.FolderTo };
            if (Folders.Count != 0)
                foreach (Model.Folder item in Folders)
                {
                    if (newSynch.FolderFrom == item.FolderFrom && newSynch.FolderTo == item.FolderTo)
                        return;
                }
            Folders.Add(newSynch);
            Folders[Folders.Count - 1].initWatcher();
        }
        public void DeleteSynch(object obj, int index)
        {
            if (obj == null)
                return;
            var synch = (Model.Folder)obj;
            synch.watcher.Dispose();
            Folders.RemoveAt(index);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
