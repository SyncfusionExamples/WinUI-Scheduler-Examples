﻿using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace CalendarTypes
{
    public class ViewModel : NotificationObject
    {
        public ViewModel()
        {
            GetCalendarTypes();
            Events = GenerateRandomAppointments();
            DisplayDate = DateTime.Now.Date.AddHours(9);
        }

        private ScheduleAppointmentCollection events;

        public ObservableCollection<string> CalendarTypes { get; set; }

        public DateTime DisplayDate { get; set; }

        public ScheduleAppointmentCollection Events
        {
            get { return events; }
            set
            {
                events = value;
                RaisePropertyChanged("Events");
            }
        }

        private ScheduleAppointmentCollection GenerateRandomAppointments()
        {
            var WorkWeekDays = new ObservableCollection<DateTime>();
            var WorkWeekSubjects = new ObservableCollection<string>()
                                                           { "GoToMeeting", "Business Meeting", "Conference", "Project Status Discussion",
                                                             "Auditing", "Client Meeting", "Generate Report", "Target Meeting", "General Meeting" };

            var NonWorkingDays = new ObservableCollection<DateTime>();

            var YearlyOccurranceSubjects = new ObservableCollection<string>() { "Wedding Anniversary", "Sam's Birthday", "Jenny's Birthday" };
            var MonthlyOccurranceSubjects = new ObservableCollection<string>() { "Pay House Rent", "Car Service", "Medical Check Up" };
            var WeekEndOccurranceSubjects = new ObservableCollection<string>() { "FootBall Match", "TV Show" };

            var brush = new ObservableCollection<SolidColorBrush>();
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 157, 101, 201)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 240, 138, 93)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 103, 155, 155)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 141, 34, 45)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 22, 146, 22)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 12, 22, 216)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 216, 145, 12)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 177, 7, 191)));
            brush.Add(new SolidColorBrush(Color.FromArgb(255, 39, 170, 254)));
            Random ran = new Random();
            DateTime today = DateTime.Now;
            if (today.Month == 12)
            {
                today = today.AddMonths(-1);
            }
            else if (today.Month == 1)
            {
                today = today.AddMonths(1);
            }

            DateTime startMonth = new DateTime(today.Year, today.Month - 1, 1, 0, 0, 0);
            int day = (int)startMonth.DayOfWeek;
            DateTime CurrentStart = startMonth.AddDays(-day);

            var appointments = new ScheduleAppointmentCollection();
            for (int i = 0; i < 90; i++)
            {
                if (i % 7 == 0 || i % 7 == 6)
                {
                    //add weekend appointments
                    NonWorkingDays.Add(CurrentStart.AddDays(i));
                }
                else
                {
                    //Add Workweek appointment
                    WorkWeekDays.Add(CurrentStart.AddDays(i));
                }
            }

            for (int i = 0; i < 50; i++)
            {
                DateTime date = WorkWeekDays[ran.Next(0, WorkWeekDays.Count)].AddHours(ran.Next(9, 17));
                appointments.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = brush[i % brush.Count],
                    Subject = WorkWeekSubjects[i % WorkWeekSubjects.Count]
                });
            }
            int j = 0;
            int k = 0;
            int l = 0;

            while (j < YearlyOccurranceSubjects.Count)
            {
                DateTime date = NonWorkingDays[ran.Next(0, NonWorkingDays.Count)];
                appointments.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = brush[1],
                    Subject = YearlyOccurranceSubjects[j]
                });
                j++;
            }
            while (k < MonthlyOccurranceSubjects.Count)
            {
                DateTime date = NonWorkingDays[ran.Next(0, NonWorkingDays.Count)].AddHours(ran.Next(9, 23));
                appointments.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = brush[k],
                    Subject = MonthlyOccurranceSubjects[k]
                });
                k++;
            }
            while (l < WeekEndOccurranceSubjects.Count)
            {
                DateTime date = NonWorkingDays[ran.Next(0, NonWorkingDays.Count)].AddHours(ran.Next(0, 23));
                appointments.Add(new ScheduleAppointment()
                {
                    StartTime = date,
                    EndTime = date.AddHours(1),
                    AppointmentBackground = brush[l],
                    Subject = WeekEndOccurranceSubjects[l]
                });
                l++;
            }

            return appointments;
        }

        private void GetCalendarTypes()
        {
            CalendarTypes = new ObservableCollection<string>()
            {
                "GregorianCalendar",
                "HebrewCalendar",
                "HijriCalendar",
                "KoreanCalendar",
                "PersianCalendar",
                "TaiwanCalendar",
                "ThaiCalendar",
                "UmAlQuraCalendar",
                "JulianCalendar"
            };
        }
    }
}
