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
        ViewModel.ViewModel vm;
        ListBox _selectedItem;
        public MainWindow()
        {
            vm = new ViewModel.ViewModel();
            DataContext = vm;
            Loaded += MainLoaded;
        }
        private void MainLoaded(object sender, RoutedEventArgs e)
        {
            btnDeleteSynch.IsEnabled = false;
            btnEventsLog.IsEnabled = false;
            FoldersList.SelectionChanged += SelectionItemOfList;
        }

        public void newSynch(Object sender, EventArgs e)
        {
            NewSynchronization NS = new NewSynchronization();
            NS.DataContext = vm;
            NS.ShowDialog();
        }
        private void SelectionItemOfList(object sender, SelectionChangedEventArgs e)
        {
            _selectedItem = (ListBox)sender;
            if(_selectedItem.SelectedIndex >= 0)
                btnDeleteSynch.IsEnabled = true;
            if(vm.IsSerializeble(_selectedItem.SelectedIndex))
                btnEventsLog.IsEnabled = true;
            else
                btnEventsLog.IsEnabled = false;
        }
        private void deleteSynch(object sender, EventArgs e)
        {
            vm.DeleteSynch(_selectedItem.SelectedItem, _selectedItem.SelectedIndex);
            btnsReset();
        }

        public void ShowEventsLog(object sender, EventArgs e)
        {
            EventsLog EL = new EventsLog(_selectedItem.SelectedIndex);
            EL.DataContext = vm;
            vm.getDeserializeEventsLog(_selectedItem.SelectedIndex);
            btnsReset();
            EL.ShowDialog();
        }

        private void btnsReset()
        {
            btnDeleteSynch.IsEnabled = false;
            btnEventsLog.IsEnabled = false;
            _selectedItem.SelectedIndex = -1;
        }
    }
}
