using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace courseworkWPF
{
    /// <summary>
    /// Логика взаимодействия для NotifyWindow.xaml
    /// </summary>
    public partial class NotifyWindow : Window
    {
        public string Message { get; set; }
        private DispatcherTimer timer;
        public NotifyWindow(string message)
        {
            this.Topmost = true;
            InitializeComponent();
            this.Message = message;
            this.DataContext = this;

            WindowPosition();
            CreateTimeWatch();
        }
        private void CreateTimeWatch()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(TimerWindowAbort);
            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Start();
        }
        private void WindowPosition()
        {
            this.Top = 20;
            this.Left = SystemParameters.WorkArea.Width - this.Width - 20;
        }
        public void Window_MouseLeftButtonDown(Object sender, EventArgs e)
        {
            this.DragMove();
        }
        public void TimerWindowAbort(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }
    }
}