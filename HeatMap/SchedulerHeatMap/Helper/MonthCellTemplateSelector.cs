using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerHeatMap
{
    public class MonthCellTemplateSelector : DataTemplateSelector
    {
        public DataTemplate LightGrayTemplate { get; set; }
        public DataTemplate LightGreenTemplate { get; set; }
        public DataTemplate MidGreenTemplate { get; set; }
        public DataTemplate GreenTemplate { get; set; }
        public DataTemplate DarkGreenTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var appointments = (container as MonthCell).Appointments;
            if (appointments.Count != 0)
            {
                var internetData = appointments[0].Data as InternetData;
                //// Select custom template based on internet data used in each day.
                if (internetData.Usage < 3)
                {
                    return LightGrayTemplate;
                }
                else if (internetData.Usage < 6)
                {
                    return LightGreenTemplate;
                }
                else if (internetData.Usage < 9)
                {
                    return MidGreenTemplate;
                }
                else if (internetData.Usage < 12)
                {
                    return GreenTemplate;
                }
                else
                {
                    return DarkGreenTemplate;
                }
            }

            return LightGrayTemplate;
        }
    }
}
