using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;

namespace RecurringBusinessObjects
{
  public class RecurringAppointmentViewModel : NotificationObject
    {
        #region Fields

        /// <summary>
        /// team management
        /// </summary>
        internal List<string> TeamManagement;

        /// <summary>
        /// color collection
        /// </summary>
        internal List<Brush> ColorCollection;

        /// <summary>
        /// current day meetings 
        /// </summary>
        private List<string> currentDayMeetings;

        /// <summary>
        /// Notes Collection.
        /// </summary>
        private List<string> notesCollection;

        /// <summary>
        /// Notes Collection.
        /// </summary>
        private List<string> noteCollection;
        /// <summary>
        /// minimum time meetings
        /// </summary>
        private List<string> minTimeMeetings;

        /// <summary>
        /// start time collection
        /// </summary>
        private List<DateTime> startTimeCollection;

        /// <summary>
        /// end time collection
        /// </summary>
        private List<DateTime> endTimeCollection;

        /// <summary>
        /// random numbers
        /// </summary>
        ////creating random number collection
        private List<int> randomNums = new List<int>();

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleViewModel" /> class.
        /// </summary>
        public RecurringAppointmentViewModel()
        {
            this.CreateRandomNumbersCollection();
            this.CreateStartTimeCollection();
            this.CreateEndTimeCollection();
            this.CreateSubjectCollection();
            this.CreateColorCollection();
            this.InitializeDataForBookings();
            this.CreateRecurrsiveAppointments();
        }

        #endregion Constructor

        #region Properties
       
        /// <summary>
        /// Gets or sets recursive appointments.
        /// </summary>
        public ObservableCollection<Event> RecursiveAppointmentCollection { get; set; }

        #endregion

        #region Methods

        #region creating RecurrsiveAppointments

        #endregion creating RecurrsiveAppointments

        #region creating RecurrsiveAppointments

        /// <summary>
        /// recursive appointments
        /// </summary>
        ////creating RecurrsiveAppointments
        private void CreateRecurrsiveAppointments()
        {
            this.RecursiveAppointmentCollection = new ObservableCollection<Event>();

            DateTime currentDate = DateTime.Now.AddMonths(-1);

            Event dailyEvent = new Event
            {
                EventName = "Daily recurring meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 11, 0, 0),
                Color = new SolidColorBrush((Color.FromArgb(255, 191, 235, 97))),
                ForegroundColor = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51)),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=100",
            };

            RecursiveAppointmentCollection.Add(dailyEvent);

            Event weeklyEvent = new Event
            {
                EventName = "Weekly recurring meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 13, 0, 0),
                Color = new SolidColorBrush((Color.FromArgb(255, 45, 216, 175))),
                ForegroundColor = new SolidColorBrush(Color.FromArgb(255, 51, 51, 51)),
                RecurrenceRule = "FREQ=WEEKLY;BYDAY=MO,WE,FR;INTERVAL=1;COUNT=20",
            };

            RecursiveAppointmentCollection.Add(weeklyEvent);

            Event monthlyEvent = new Event
            {
                EventName = "Monthly recurring Meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 13, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 14, 0, 0),
                Color = new SolidColorBrush(Microsoft.UI.Colors.Red),
                RecurrenceRule = "FREQ=MONTHLY;BYDAY=TU;BYSETPOS=1;INTERVAL=1;COUNT=50",
            };

            RecursiveAppointmentCollection.Add(monthlyEvent);

            Event yearlyEvent = new Event
            {
                EventName = "Yearly recurring Meeting",
                From = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 2, 0, 0),
                To = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 3, 0, 0),
                Color = new SolidColorBrush(Microsoft.UI.Colors.Yellow),
                RecurrenceRule = "FREQ=YEARLY;BYMONTHDAY=3;BYMONTH=5;INTERVAL=1;COUNT=50",
            };

            RecursiveAppointmentCollection.Add(yearlyEvent);
        }

        /// <summary>
        /// Method to get foreground color based on background.
        /// </summary>
        /// <param name="backgroundColor"></param>
        /// <returns></returns>
        private Brush GetAppointmentForeground(Brush backgroundColor)
        {
            if (backgroundColor.ToString().Equals("#FF8551F2") || backgroundColor.ToString().Equals("#FF5363FA") || backgroundColor.ToString().Equals("#FF2D99FF"))
                return new SolidColorBrush(Microsoft.UI.Colors.White);
            else
                return new SolidColorBrush(Color.FromArgb(255, 51, 51, 51));
        }

        #endregion creating RecurrsiveAppointments

        #region InitializeDataForBookings

        /// <summary>
        /// Method for initialize data bookings.
        /// </summary>
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

            // MinimumHeight Appointment Subjects
            this.minTimeMeetings = new List<string>();
            this.minTimeMeetings.Add("Work log alert");
            this.minTimeMeetings.Add("Birthday wish alert");
            this.minTimeMeetings.Add("Task due date");
            this.minTimeMeetings.Add("Status mail");
            this.minTimeMeetings.Add("Start sprint alert");

            this.notesCollection = new List<string>();
            this.notesCollection.Add("Consulting firm laws with business advisers");
            this.notesCollection.Add("Execute Project Scope");
            this.notesCollection.Add("Project Scope & Deliverables");
            this.notesCollection.Add("Executive summary");
            this.notesCollection.Add("Try to reduce the risks");
            this.notesCollection.Add("Encourages the integration of mind, body, and spirit");
            this.notesCollection.Add("Execute Project Scope");
            this.notesCollection.Add("Project Scope & Deliverables");
            this.notesCollection.Add("Executive summary");
            this.notesCollection.Add("Try to reduce the risk");

            this.noteCollection = new List<string>();
            this.noteCollection.Add("To show the status of multiple underlying simple alerts with one overall status.");
            this.noteCollection.Add("25th Celebration");
            this.noteCollection.Add("Date by which member should complete a task");
            this.noteCollection.Add("Helps you to establish reports for company, team, and individual usage");
            this.noteCollection.Add("Receive a warning regarding scope");
        }

        #endregion InitializeDataForBookings

        #region SubjectCollection

        /// <summary>
        /// Subject collection
        /// </summary>
        ////creating subject collection
        private void CreateSubjectCollection()
        {
            this.TeamManagement = new List<string>();
            this.TeamManagement.Add("General Meeting");
            this.TeamManagement.Add("Plan Execution");
            this.TeamManagement.Add("Project Plan");
            this.TeamManagement.Add("Consulting");
            this.TeamManagement.Add("Performance Check");
            this.TeamManagement.Add("General Meeting");
            this.TeamManagement.Add("Plan Execution");
            this.TeamManagement.Add("Project Plan");
            this.TeamManagement.Add("Consulting");
            this.TeamManagement.Add("Performance Check");
        }

        #endregion SubjectCollection

        #region creating color collection

        /// <summary>
        /// color collection
        /// </summary>
        ////creating color collection
        private void CreateColorCollection()
        {
            this.ColorCollection = new List<Brush>();
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 133, 81, 242)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 140, 245, 219)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 255, 222, 133)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 45, 153, 255)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 253, 183, 165)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 198, 237, 115)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 253, 185, 222)));
            this.ColorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)));
        }

        #endregion creating color collection

        #region CreateRandomNumbersCollection

        /// <summary>
        /// random numbers collection
        /// </summary>
        private void CreateRandomNumbersCollection()
        {
            this.randomNums = new List<int>();

            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                int random = rand.Next(9, 15);
                this.randomNums.Add(random);
            }
        }

        #endregion CreateRandomNumbersCollection

        #region CreateStartTimeCollection

        /// <summary>
        /// start time collection
        /// </summary>
        //// creating StartTime collection
        private void CreateStartTimeCollection()
        {
            this.startTimeCollection = new List<DateTime>();
            DateTime currentDate = DateTime.Now;

            int count = 0;
            for (int i = -5; i < 5; i++)
            {
                DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, this.randomNums[count], 0, 0);
                DateTime startDateTime = startTime.AddDays(i);
                this.startTimeCollection.Add(startDateTime);
                count++;
            }
        }

        #endregion CreateStartTimeCollection

        #region CreateEndTimeCollection

        /// <summary>
        /// end time collection
        /// </summary>
        ////  creating EndTime collection
        private void CreateEndTimeCollection()
        {
            this.endTimeCollection = new List<DateTime>();
            DateTime currentDate = DateTime.Now;
            int count = 0;
            for (int i = -5; i < 5; i++)
            {
                DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, this.randomNums[count] + 1, 0, 0);
                DateTime endDateTime = endTime.AddDays(i);
                if (i == -3 || i == 3)
                {
                    endDateTime = endTime.AddDays(i).AddHours(22);
                }

                this.endTimeCollection.Add(endDateTime);
                count++;
            }
        }

        #endregion CreateEndTimeCollection

        #endregion Methods
    }
}
