using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FareCalendar_DataTemplateSelector
{
    public class Airline : NotificationObject
    {
        private DateTime from;
        private Brush color;
        private string name;
        private string fare;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        public DateTime Date
        {
            get { return from; }
            set
            {
                from = value;
                RaisePropertyChanged("Date");
            }
        }

        public string Fare
        {
            get { return fare; }
            set
            {
                fare = value;
                RaisePropertyChanged("Fare");
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
