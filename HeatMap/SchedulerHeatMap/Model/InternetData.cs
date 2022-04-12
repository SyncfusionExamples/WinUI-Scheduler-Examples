using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerHeatMap
{
    /// <summary>    
    /// Represents the Internet data properties.    
    /// </summary> 
    public class InternetData : NotificationObject
    {
        private DateTime date;
        private Brush color;
        private int usage;

        public int Usage
        {
            get { return usage; }
            set
            {
                usage = value;
                RaisePropertyChanged("Usage");
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                RaisePropertyChanged("Date");
            }
        }

        public Brush Color
        {
            get { return color; }
            set
            {
                color = value;
                RaisePropertyChanged("Color");
            }
        }
    }
}
