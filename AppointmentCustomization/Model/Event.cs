using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentCustomization
{
   public class Event : NotificationObject
    {
        private string eventName;
        private DateTime from;
        private DateTime to;
        private Brush backgroundColor, foregroundColor;
        private bool isAllDay;

        public string EventName
        {
            get { return eventName; }
            set
            {
                eventName = value;
                this.RaisePropertyChanged("EventName");
            }
        }

        public DateTime From
        {
            get { return from; }
            set
            {
                from = value;
                this.RaisePropertyChanged("From");
            }
        }

        public DateTime To
        {
            get { return to; }
            set
            {
                to = value;
                this.RaisePropertyChanged("To");
            }
        }

        public Brush BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                backgroundColor = value;
                this.RaisePropertyChanged("BackgroundColor");
            }
        }

        public Brush ForegroundColor
        {
            get { return foregroundColor; }
            set
            {
                foregroundColor = value;
                this.RaisePropertyChanged("ForegroundColor");
            }
        }

        public bool IsAllDay
        {
            get { return isAllDay; }
            set
            {
                isAllDay = value;
                this.RaisePropertyChanged("IsAllDay");
            }
        }
    }
}