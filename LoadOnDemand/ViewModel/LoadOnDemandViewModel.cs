using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Windows.UI;

namespace LoadOnDemand
{
    public class LoadOnDemandViewModel : NotificationObject
    {
        /// <summary>
        /// Gets or sets load on demand command.
        /// </summary>
        public DelegateCommand LoadOnDemandCommand { get; set; }


        private IEnumerable events;
        public IEnumerable Events
        {
            get { return events; }
            set
            {
                events = value;
                this.RaisePropertyChanged("Events");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show the busy indicator.
        /// </summary>
        private bool showBusyIndicator;
        public bool ShowBusyIndicator
        {
            get { return showBusyIndicator; }
            set
            {
                showBusyIndicator = value;
                this.RaisePropertyChanged("ShowBusyIndicator");
            }
        }

        public LoadOnDemandViewModel()
        {
            this.InitializeDataForBookings();
            this.LoadOnDemandCommand = new DelegateCommand(ExecuteOnDemandLoading, CanExecuteOnDemandLoading);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public async void ExecuteOnDemandLoading(object parameter)
        {
            this.ShowBusyIndicator = true;
            await Task.Delay(1000);
            Application.Current.Resources.DispatcherQueue.TryEnqueue(() =>
            {
                this.Events = this.GenerateSchedulerAppointments((parameter as QueryAppointmentsEventArgs).VisibleDateRange);
            });
            this.ShowBusyIndicator = false;
        }

        private bool CanExecuteOnDemandLoading(object sender)
        {
            return true;
        }

        /// <summary>
        ///  current day meetings
        /// </summary>
        private List<string> currentDayMeetings;

        /// <summary>
        /// color collection
        /// </summary>
        private List<Brush> colorCollection;

        private void InitializeDataForBookings()
        {
            this.currentDayMeetings = new List<string>();
            this.currentDayMeetings.Add("General Meeting");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");
            this.currentDayMeetings.Add("Yoga Therapy");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");

            this.colorCollection = new List<Brush>();
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 133, 81, 242)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 140, 245, 219)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 255, 222, 133)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 45, 153, 255)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 253, 183, 165)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 198, 237, 115)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 253, 185, 222)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)));
        }

        private IEnumerable GenerateSchedulerAppointments(DateRange dateRange)
        {
            Random ran = new Random();
            int daysCount = (dateRange.ActualEndDate - dateRange.ActualStartDate).Days;
            var appointments = new ScheduleAppointmentCollection();
            for (int i = 0; i < 50; i++)
            {
                var startTime = dateRange.ActualStartDate.AddDays(ran.Next(0, daysCount + 1)).AddHours(ran.Next(0, 24)); appointments.Add(new ScheduleAppointment
                {
                    StartTime = startTime,
                    EndTime = startTime.AddHours(1),
                    Subject = currentDayMeetings[ran.Next(0, currentDayMeetings.Count)],
                    AppointmentBackground = colorCollection[ran.Next(0, colorCollection.Count)],
                });
            }
            return appointments;
        }
    }
}
