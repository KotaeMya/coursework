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
        string ip;
        public NewSynchronization()
        {
            InitializeComponent();
            string Host = Dns.GetHostName();
            ip = Dns.GetHostByName(Host).AddressList[0].ToString();
        }
        public void click_Overwiev1(Object sender, EventArgs e)
        {
            FolderFrom.Text = selectFolder(ip);
        }
        public void click_Overwiev2(Object sender, EventArgs e)
        {
            FolderTo.Text = selectFolder(ip);
        }
        public void AddFolder(Object sender, EventArgs e)
        {
            ((ViewModel.ViewModel)DataContext).AddFolder();
        }

        private string selectFolder(string ip)
        {
            winForm.FolderBrowserDialog ofd = new winForm.FolderBrowserDialog();
            // ofd.SelectedPath = string.Format(@"\\{0}\", ip);
            ofd.SelectedPath = string.Format(@"\\C:\\Users\\sereja\\Desktop\\");

            winForm.DialogResult result = ofd.ShowDialog();
            if (result.Equals(false))
            {
                return "";
            }
            var selectedFolder = ofd.SelectedPath;
            return selectedFolder;
        }
    }
}
