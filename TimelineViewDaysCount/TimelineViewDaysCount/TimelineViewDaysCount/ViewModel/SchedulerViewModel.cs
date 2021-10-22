using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.ComponentModel;
using Windows.UI;

namespace TimelineViewDaysCount
{
    public class SchedulerViewModel : INotifyPropertyChanged
    {
        private ScheduleAppointmentCollection scheduleAppointmentCollection;
        public SchedulerViewModel()
        {
            this.ScheduleAppointmentCollection = new ScheduleAppointmentCollection();
            scheduleAppointmentCollection.Add(new ScheduleAppointment
            {
                StartTime = DateTime.Now.Date.AddHours(10),
                EndTime = DateTime.Now.Date.AddHours(11),
                Subject = "Client Meeting",
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 133, 81, 242)),
                Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)),
            });

            scheduleAppointmentCollection.Add(new ScheduleAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(1).AddHours(13),
                EndTime = DateTime.Now.Date.AddDays(1).AddHours(14),
                Subject = "GoToMeeting",
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 140, 245, 219)),
                Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)),
            });

            scheduleAppointmentCollection.Add(new ScheduleAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(-1).AddHours(9),
                EndTime = DateTime.Now.Date.AddDays(-1).AddHours(10),
                Subject = "Generate Report",
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)),
                Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)),
            });

            scheduleAppointmentCollection.Add(new ScheduleAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(2).AddHours(14),
                EndTime = DateTime.Now.Date.AddDays(2).AddHours(15),
                Subject = "Generate Report",
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 255, 222, 133)),
                Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)),
            });

            scheduleAppointmentCollection.Add(new ScheduleAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(-2).AddHours(4),
                EndTime = DateTime.Now.Date.AddDays(-2).AddHours(5),
                Subject = "Plan Execution",
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 45, 153, 255)),
                Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)),
            });

            scheduleAppointmentCollection.Add(new ScheduleAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(0).AddHours(5),
                EndTime = DateTime.Now.Date.AddDays(0).AddHours(6),
                Subject = "Consulting",
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 253, 183, 165)),
                Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)),
            });

            scheduleAppointmentCollection.Add(new ScheduleAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(1).AddHours(9),
                EndTime = DateTime.Now.Date.AddDays(1).AddHours(10),
                Subject = "Performance Check",
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 198, 237, 115)),
                Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)),
            });

            scheduleAppointmentCollection.Add(new ScheduleAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(3).AddHours(17),
                EndTime = DateTime.Now.Date.AddDays(3).AddHours(18),
                Subject = "Project Plan",
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 253, 185, 222)),
                Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)),
            });

            scheduleAppointmentCollection.Add(new ScheduleAppointment
            {
                StartTime = DateTime.Now.Date.AddDays(0).AddHours(17),
                EndTime = DateTime.Now.Date.AddDays(0).AddHours(18),
                Subject = "Consulting",
                AppointmentBackground = new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)),
                Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)),
                IsAllDay = true
            });
        }
        public ScheduleAppointmentCollection ScheduleAppointmentCollection
        {
            get
            {
                return this.scheduleAppointmentCollection;
            }
            set
            {
                this.scheduleAppointmentCollection = value;
                this.RaiseOnPropertyChanged("ScheduleAppointmentCollection");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseOnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
