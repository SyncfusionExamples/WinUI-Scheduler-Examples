using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FareCalendar_DataTemplateSelector
{
	public class MonthCellTemplateSelector : DataTemplateSelector
	{
		/// <summary>
		/// Gets or sets the month cell template with best price.
		/// </summary>
		public DataTemplate MonthCellWithBestPriceTemplate { get; set; }

		/// <summary>
		/// Gets or sets the month cell template without best price.
		/// </summary>
		public DataTemplate MonthCellWithoutBestPriceTemplate { get; set; }

		/// <summary>
		/// Template selection method.
		/// </summary>
		/// <param name="item">return the object.</param>
		/// <param name="container">return the bindable object.</param>
		/// <returns>The month cell template.</returns>
		protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
		{
			var appointments = item as List<ScheduleAppointment>;

			foreach (var app in appointments)
			{
				var ailrline = app.Data as Airline;
				if (ailrline.Fare == "$100.17")
					return MonthCellWithBestPriceTemplate;
				else
					return MonthCellWithoutBestPriceTemplate;
			}
			return MonthCellWithoutBestPriceTemplate;
		}
	}
}
