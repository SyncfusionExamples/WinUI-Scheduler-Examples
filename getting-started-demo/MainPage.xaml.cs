using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Syncfusion.UI.Xaml.Scheduler;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GettingStarted
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.InitializeComboBoxItemSource();
            this.GetAppointments();
        }

        private void InitializeComboBoxItemSource()
        {
            this.viewType.ItemsSource = Enum.GetValues(typeof(SchedulerViewType));
        }

        private void GetAppointments()
        {
            // Creating an instance for schedule appointment collection.
            var scheduleAppointmentCollection = new ScheduleAppointmentCollection();
            //Adding schedule appointment in the schedule appointment collection.
            scheduleAppointmentCollection.Add(new ScheduleAppointment
            {
                StartTime = DateTime.Now.Date.AddHours(4),
                EndTime = DateTime.Now.Date.AddHours(5),
                Subject = "Client Meeting"
            }); 

            //Adding schedule appointment collection to the ItemSource of SfScheduler
            Schedule.ItemsSource = scheduleAppointmentCollection;
        }
    }
}
