using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;

namespace ResourceGrouping
{
    public class ResourceViewModel : NotificationObject
    {
        #region Fields

        private ScheduleAppointmentCollection events;
        private ObservableCollection<object> resources;
        private List<string> eventNames;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleViewModel" /> class.
        /// </summary>
        public ResourceViewModel()
        {
            this.InitializeResources();
            this.CreateResourceAppointments();
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets or sets resource appointments.
        /// </summary>
        public ScheduleAppointmentCollection ResourceAppointments
        {
            get { return events; }
            set
            {
                events = value;
                RaisePropertyChanged("Events");
            }
        }

        /// <summary>
        /// Gets or sets resource collection.
        /// </summary>
        public ObservableCollection<object> Resources
        {
            get
            {
                return resources;
            }

            set
            {
                resources = value;
                this.RaisePropertyChanged("Resources");
            }
        }

        #endregion

        #region Methods

        private void InitializeResources()
        {
            Resources = new ObservableCollection<object>()
            {
            new SchedulerResource() { Name = "Sophia",Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)), Background = new SolidColorBrush((Color.FromArgb(255, 157, 101, 201))), Id = "1000" },
            new SchedulerResource() { Name = "Zoey Addison", Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)), Background = new SolidColorBrush(Color.FromArgb(255, 240, 138, 93)), Id = "1001" },
            new SchedulerResource() { Name = "James William",Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)), Background = new SolidColorBrush(Color.FromArgb(255,103, 155, 155)), Id = "1002" },
            };
        }

        private void CreateResourceAppointments()
        {
            ResourceAppointments = new ScheduleAppointmentCollection();
            Random randomTime = new Random();

            List<Point> randomTimeCollection = this.GettingTimeRanges();
            var resurceCollection = this.Resources as ObservableCollection<object>;

            this.eventNames = new List<string>();
            this.eventNames.Add("General Meeting");
            this.eventNames.Add("Plan Execution");
            this.eventNames.Add("Project Plan");
            this.eventNames.Add("Consulting");
            this.eventNames.Add("Performance Check");
            this.eventNames.Add("Yoga Therapy");

            for (int resource = 0; resource < resurceCollection.Count; resource++)
            {
                var scheduleResource = resurceCollection[resource] as SchedulerResource;
                DateTime date;
                DateTime dateFrom = DateTime.Now.AddDays(-15);
                DateTime dateTo = DateTime.Now.AddDays(15);
                DateTime dateRangeStart = DateTime.Now.AddDays(-15);
                DateTime dateRangeEnd = DateTime.Now.AddDays(15);

                for (date = dateFrom; date < dateTo; date = date.AddDays(1))
                {
                    if ((DateTime.Compare(date, dateRangeStart) > 0) && (DateTime.Compare(date, dateRangeEnd) < 0))
                    {
                        for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 4; additionalAppointmentIndex++)
                        {
                            //int dateTime = randomTime.Next(0, 23);
                            DateTime dateTime1 = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(0, 23), 0, 0);
                            ResourceAppointments.Add(new ScheduleAppointment()
                            {
                                StartTime = dateTime1,
                                EndTime = dateTime1.AddHours(2),
                                Subject = this.eventNames[randomTime.Next(4)],
                                ResourceIdCollection = new ObservableCollection<object>() { scheduleResource.Id },
                                AppointmentBackground = scheduleResource.Background,
                            });
                        }
                    }
                }
            }
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

        private List<Point> GettingTimeRanges()
        {
            List<Point> randomTimeCollection = new List<Point>();
            randomTimeCollection.Add(new Point(9, 11));
            randomTimeCollection.Add(new Point(12, 14));
            randomTimeCollection.Add(new Point(15, 17));

            return randomTimeCollection;
        }
    }
#endregion
}