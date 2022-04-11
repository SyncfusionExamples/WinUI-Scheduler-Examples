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
        public DataTemplate LightGray { get; set; }
        public DataTemplate LightGreen { get; set; }
        public DataTemplate MidGreen { get; set; }
        public DataTemplate Green { get; set; }
        public DataTemplate DarkGreen { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var date = (container as MonthCell).DateTime;
            if (date.Month % 2 == 0)
            {
                if (date.Day % 6 == 0)
                {
                    // 6, 12, 18, 24, 30
                    return DarkGreen;
                }
                else if (date.Day % 5 == 0)
                {
                    // 5, 10, 15, 20, 25
                    return MidGreen;
                }
                else if (date.Day % 8 == 0 || date.Day % 4 == 0)
                {
                    //  4, 8, 16, 24, 28
                    return Green;
                }
                else if (date.Day % 9 == 0 || date.Day % 3 == 0)
                {
                    // 3, 9, 18, 21, 27
                    return LightGray;
                }
                else
                {
                    // 1, 2, 7, 11, 13, 19, 22, 23, 26, 29
                    return LightGreen;
                }
            }
            else
            {
                if (date.Day % 6 == 0)
                {
                    // 6, 12, 18, 24, 30
                    return LightGray;
                }
                else if (date.Day % 5 == 0)
                {
                    // 5, 10, 15, 20, 25
                    return LightGreen;
                }
                else if (date.Day % 8 == 0 || date.Day % 4 == 0)
                {
                    //  4, 8, 16, 24, 28
                    return MidGreen;
                }
                else if (date.Day % 9 == 0 || date.Day % 3 == 0)
                {
                    // 3, 9, 18, 21, 27
                    return Green;
                }
                else
                {
                    // 1, 2, 7, 11, 13, 19, 22, 23, 26, 29
                    return DarkGreen;
                }
            }
        }
    }
}
