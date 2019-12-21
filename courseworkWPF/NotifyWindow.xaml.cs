using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace courseworkWPF
{
    /// <summary>
    /// Логика взаимодействия для NotifyWindow.xaml
    /// </summary>
    public partial class NotifyWindow : Window
    {
        public string Message { get; set; }
        private Thread _window;
        public NotifyWindow(string message, Thread newWindowThread)
        {
            InitializeComponent();
            this.Message = message;
            this.DataContext = this;
            this.Top = 20;
            this.Left = SystemParameters.WorkArea.Width - this.Width - 20;
            _window = newWindowThread;
        }
        public void Window_MouseLeftButtonDown(Object sender, EventArgs e)
        {
            this.DragMove();
            _window.Abort();
        }
    }
}