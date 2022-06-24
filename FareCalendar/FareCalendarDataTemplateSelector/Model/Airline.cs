using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using System;

namespace FareCalendarDataTemplateSelector
{
    /// <summary>    
    /// Represents the airline data properties.    
    /// </summary> 
    public class Airline : NotificationObject
    {
        private DateTime from;
        private Brush color;
        private string name;
        private double fare;
        private string cost;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public DateTime Date
        {
            get { return from; }
            set
            {
                from = value;
                RaisePropertyChanged(nameof(Date));
            }
        }

        public double Fare
        {
            get { return fare; }
            set
            {
                fare = value;
                RaisePropertyChanged(nameof(Fare));
            }
        }

        public string Cost
        {
            get { return cost; }
            set
            {
                cost = value;
                RaisePropertyChanged(nameof(Cost));
            }
        }

        public Brush Color
        {
            get { return color; }
            set
            {
                color = value;
                RaisePropertyChanged(nameof(Color));
            }
        }
    }
}
