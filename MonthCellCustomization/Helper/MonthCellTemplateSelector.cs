using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthCellCustomization
{
    public class MonthCellTemplateSelector : DataTemplateSelector
    {
        public MonthCellTemplateSelector()
        {

        }

        public DataTemplate NormalDayMonthCellTemplate { get; set; }
        public DataTemplate CurrentDayMonthCellTemplate { get; set; }

        /// <summary>
        /// Template selection method
        /// </summary>
        /// <param name="item">return the object</param>
        /// <param name="container">return the bindable object</param>
        /// <returns>return the template</returns>
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var monthCell = container as MonthCell;
            if (monthCell != null)
            {
                if (monthCell.DateTime.Date == DateTime.Now.Date)
                    return CurrentDayMonthCellTemplate;
            }
            return NormalDayMonthCellTemplate;
        }
    }
}
