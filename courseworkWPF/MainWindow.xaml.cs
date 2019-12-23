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
        public MainWindow()
        {
            vm = new ViewModel.ViewModel();
            DataContext = vm;
        }
        public void newSynch(Object sender, EventArgs e)
        {
            NewSynchronization NS = new NewSynchronization();
            NS.DataContext = vm;
            NS.ShowDialog();

            FoldersList.SelectionChanged += SelectionIndex;
        }

        private void SelectionIndex(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            vm.DeleteSynch(item.SelectedItem, item.SelectedIndex);
        }
    }
}
