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
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace HighlightNonWorkingHour
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            scheduler.DaysViewSettings.SpecialTimeRegions.Add(new SpecialTimeRegion
            {
                StartTime = DateTime.MinValue.AddHours(0),
                EndTime = DateTime.MinValue.AddHours(9),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1"
            });

            scheduler.DaysViewSettings.SpecialTimeRegions.Add(new SpecialTimeRegion
            {
                StartTime = DateTime.MinValue.AddHours(18),
                EndTime = DateTime.MinValue.AddHours(23),
                RecurrenceRule = "FREQ=DAILY;INTERVAL=1"
            });
        }
    }
}
