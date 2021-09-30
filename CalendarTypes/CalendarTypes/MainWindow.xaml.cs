using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CalendarTypes
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.viewtypecombobox.ItemsSource = Enum.GetValues(typeof(SchedulerViewType));
            var specialTimeRegions = this.GetSpecialTimeRegions();
            this.Schedule.MinimumDate = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(-3).Month, 12, 0, 0, 0);
            this.Schedule.MaximumDate = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(3).Month, 12, 0, 0, 0);
            this.Schedule.DisplayDate = DateTime.Today.Date.AddHours(9);
            this.Schedule.DaysViewSettings.SpecialTimeRegions = specialTimeRegions;
            this.Schedule.TimelineViewSettings.SpecialTimeRegions = specialTimeRegions;
            this.Schedule.BlackoutDates = GetBlackoutDates();
        }

        /// <summary>
        ///  Method to get Special time region collections.
        /// </summary>
        /// <returns></returns>
        private ObservableCollection<SpecialTimeRegion> GetSpecialTimeRegions()
        {
            var currentDate = DateTime.Now.AddMonths(-3);
            var timeRegion = new SpecialTimeRegion();
            timeRegion.StartTime = new DateTime(currentDate.Year, currentDate.Month, 1, 13, 0, 0);
            timeRegion.EndTime = timeRegion.StartTime.AddHours(1);
            timeRegion.RecurrenceRule = "FREQ=DAILY;INTERVAL=1";
            timeRegion.Text = "Lunch";
            timeRegion.CanEdit = true;
            timeRegion.Background = new SolidColorBrush(Colors.LightGray);
            timeRegion.Foreground = new SolidColorBrush(Colors.White);

            var specialTimeRegions = new ObservableCollection<SpecialTimeRegion>();
            specialTimeRegions.Add(timeRegion);

            return specialTimeRegions;
        }



        /// <summary>
        /// Method to get blackout date collections.
        /// </summary>
        // <returns>The blackoutDateCollection.</returns>
        private ObservableCollection<DateTime> GetBlackoutDates()
        {
            var blackoutDateCollection = new ObservableCollection<DateTime>()
            {
                DateTime.Now.AddDays(-2),
                DateTime.Now.AddDays(-1),
                DateTime.Now.AddDays(0),
                DateTime.Now.AddDays(1),
                DateTime.Now.AddDays(2)
            };

            return blackoutDateCollection;
        }


    }
}
