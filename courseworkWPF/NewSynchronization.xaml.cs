using System;
using System.Net;
using System.Windows;
using winForm = System.Windows.Forms;

namespace courseworkWPF
{
    /// <summary>
    /// Логика взаимодействия для NewSynchronization.xaml
    /// </summary>
    public partial class NewSynchronization : Window
    {
        public NewSynchronization()
        {
            InitializeComponent();
        }
        public void click_Overwiev1(Object sender, EventArgs e)
        {
            FolderFrom.Text = selectFolder();
        }
        public void click_Overwiev2(Object sender, EventArgs e)
        {
            FolderTo.Text = selectFolder();
        }
        public void AddSynch(Object sender, EventArgs e)
        {
            ((ViewModel.ViewModel)DataContext).AddSynch();
        }
        private string selectFolder()
        {
            winForm.FolderBrowserDialog ofd = new winForm.FolderBrowserDialog();
            ofd.SelectedPath = string.Format(@"\C:\Users\sereja\Desktop\");

            winForm.DialogResult result = ofd.ShowDialog();
            if (result == winForm.DialogResult.Cancel)
            {
                return "";
            }
            var selectedFolder = ofd.SelectedPath;
            return selectedFolder;
        }
    }
}
