using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FareCalendar_DataTemplateSelector
{
	public class AirlinesViewModel
	{
		/// <summary>
		/// Initializes a new instance of the AirlinesViewModel class.
		/// </summary>
		public AirlinesViewModel()
		{
			GetAirlinesData();
		}

		/// <summary>
		/// Gets or sets the airline collection.
		/// </summary>
		public ObservableCollection<Airline> AirlineCollection { get; set; }

		/// <summary>
		/// Methods to get the airlines data.
		/// </summary>
		private void GetAirlinesData()
		{
			List<string> Fares = new List<string>()
			 {   "$134.50", "$305.00", "$152.66", "$267.09", "$189.20", "$212.10", "$238.83",
				 "$100.17", "$101.72", "$332.48" ,"$100.17", "$449.68", "$378.44", "$273.45",
				 "$134.50", "$305.00", "$152.66", "$267.09", "$189.20", "$212.10", "$238.83",
			};

			List<string> airlineNames = new List<string>() { "Airways 1", "Airways 2", "Airways 3" };
			Random random = new Random();

			var startDate = new DateTime(DateTime.Now.Date.Year, DateTime.Now.Date.Month, 1);
			//// Creating an instance for airline collection.
			this.AirlineCollection = new ObservableCollection<Airline>();
			//// Adding random airline data to the airline collecion.
			for (int i = 0; i < 300; i++)
			{
				var airline = new Airline();
				airline.Name = airlineNames[random.Next(0, 3)];
				airline.Fare = Fares[random.Next(0, 20)];
				airline.Color = GetAirlineColor(airline.Name);
				airline.Date = startDate.AddDays(i);
				this.AirlineCollection.Add(airline);
			}
		}

		/// <summary>
		/// Methods to get the airline color.
		/// </summary>
		/// <param name="airlineName"></param>
		/// <returns></returns>
		private Brush GetAirlineColor(string airlineName)
		{
			if (airlineName == "Airways 1")
				return new SolidColorBrush(Colors.Red);
			else if (airlineName == "Airways 2")
				return new SolidColorBrush(Colors.Green);
			else
				return new SolidColorBrush(Colors.Gray);
		}
	}
}
