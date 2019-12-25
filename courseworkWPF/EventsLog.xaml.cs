using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace courseworkWPF
{
    /// <summary>
    /// Логика взаимодействия для EventsLog.xaml
    /// </summary>
    public partial class EventsLog : Window
    {
        int index = 0;
        public EventsLog(int i)
        {
            InitializeComponent();
            index = i;
        }

        private void GetList(object sender, EventArgs e)
        {
            ((ViewModel.ViewModel)DataContext).getDeserializeEventsLog(index);
        }
        private void Created(object sender, EventArgs e)
        {
            ((ViewModel.ViewModel)DataContext).getEventLogs(index, "Created");
        }
        private void Renamed(object sender, EventArgs e)
        {
            ((ViewModel.ViewModel)DataContext).getEventLogs(index, "Renamed");
        }
        private void Deleted(object sender, EventArgs e)
        {
            ((ViewModel.ViewModel)DataContext).getEventLogs(index, "Deleted");
        }
        private void Changed(object sender, EventArgs e)
        {
            ((ViewModel.ViewModel)DataContext).getEventLogs(index, "Changed");
        }

    }
}
