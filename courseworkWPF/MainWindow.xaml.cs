using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using System.Net;
using winForm = System.Windows.Forms;

namespace courseworkWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //NotifyWindow notifyWindow;
        //private string synhro;
        //private string selectedFolder;
        ViewModel.ViewModel vm;
        public MainWindow()
        {
            vm = new ViewModel.ViewModel();
            DataContext = vm;
            //string Host = Dns.GetHostName();
            //string ip = Dns.GetHostByName(Host).AddressList[0].ToString();
            //synhro = string.Format("{0}\\synhro\\", Environment.CurrentDirectory);
            //InitializeComponent();
            //createDirectory();
            //selectFolder(ip);
            //copyAll();
            //func();
        }
        public void newSynch(Object sender, EventArgs e)
        {
            NewSynchronization NS = new NewSynchronization();
            NS.DataContext = vm;
            NS.ShowDialog();
        }

        //private void copyAll()
        //{
        //    DirectoryInfo source = new DirectoryInfo(string.Format(@"{0}", selectedFolder));
        //    DirectoryInfo destin = new DirectoryInfo(string.Format(@"{0}", synhro));

        //    foreach (var item in source.GetFiles())
        //    {
        //        item.CopyTo(string.Format("{0}{1}", destin, item.Name), true);
        //    }
        //}

        //private void selectFolder(string ip)
        //{
        //    winForm.FolderBrowserDialog ofd = new winForm.FolderBrowserDialog();
        //    ofd.SelectedPath = string.Format(@"\\{0}\", ip);
        //    ofd.ShowDialog();
        //    selectedFolder = ofd.SelectedPath;

        //    //winForm.DialogResult result = ofd.ShowDialog();
        //    //if (result.Equals(false))
        //    //{
        //    //    return;
        //    //}
        //}

        //private void createDirectory()
        //{
        //    Directory.CreateDirectory(synhro);
        //}

        //public void func()
        //{
        //    FileSystemWatcher watcher = new FileSystemWatcher();
        //    watcher.Path = this.selectedFolder;
        //    watcher.NotifyFilter = NotifyFilters.LastWrite
        //                         | NotifyFilters.FileName
        //                         | NotifyFilters.DirectoryName;
        //    watcher.Filter = "*.*";
        //    watcher.Changed += OnChanged;
        //    watcher.Created += OnChanged;
        //    watcher.Deleted += OnChanged;
        //    watcher.Renamed += OnRenamed;
        //    watcher.EnableRaisingEvents = true;
        //}

        //private void OnRenamed(object sender, RenamedEventArgs e)
        //{
        //    Console.WriteLine(string.Format(
        //        "Файл переименован: {0}, Действие: {1}", e.Name, e.ChangeType));
        //    Application.Current.Dispatcher.Invoke(() => {

        //        notifyWindow = new NotifyWindow(string.Format(
        //            "Файл переименован: {0}, Действие: {1}", e.Name, e.ChangeType));
        //        notifyWindow.Show();
        //    });
        //}

        //private void OnChanged(object sender, FileSystemEventArgs e)
        //{
        //    Console.WriteLine(string.Format(
        //        "Файл создан | изменен | удален: {0}, Действие: {1}", e.Name, e.ChangeType));
        //    Application.Current.Dispatcher.Invoke(() => {
        //        notifyWindow = new NotifyWindow(string.Format(
        //            "Файл создан | изменен | удален: {0}, Действие: {1}", e.Name, e.ChangeType));
        //        notifyWindow.Show();
        //    });
        //}

        ////private void OnRenamed(object sender, FileSystemEventArgs e)
        ////{
        ////    Console.WriteLine(string.Format(
        ////        "Файл переименован: {0}, Действие: {1}", e.Name, e.ChangeType));

        ////    Application.Current.Dispatcher.Invoke(() => {

        ////        notifyWindow = new NotifyWindow(string.Format(
        ////            "Файл переименован: {0}, Действие: {1}", e.Name, e.ChangeType));
        ////        notifyWindow.Show();
        ////        }
        ////    );
        ////}

        ////private void OnChanged(object sender, FileSystemEventArgs e)
        ////{
        ////    Console.WriteLine(string.Format(
        ////        "Файл изменен: {0}, Действие: {1}", e.Name, e.ChangeType));
        ////    Application.Current.Dispatcher.Invoke(() => {

        ////        notifyWindow = new NotifyWindow(string.Format(
        ////            "Файл изменен: {0}, Действие: {1}", e.Name, e.ChangeType));
        ////        notifyWindow.Show();
        ////    }
        ////    );
        ////}
        ////private void OnDelete(object sender, FileSystemEventArgs e)
        ////{
        ////    Console.WriteLine(string.Format(
        ////        "Файл удален: {0}, Действие: {1}", e.Name, e.ChangeType));
        ////    Application.Current.Dispatcher.Invoke(() => {

        ////        notifyWindow = new NotifyWindow(string.Format(
        ////            "Файл удален: {0}, Действие: {1}", e.Name, e.ChangeType));
        ////        notifyWindow.Show();
        ////    });
        ////}
    }
}
