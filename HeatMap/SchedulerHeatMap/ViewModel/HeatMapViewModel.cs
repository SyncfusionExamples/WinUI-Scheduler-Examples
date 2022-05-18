using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace SchedulerHeatMap
{
	/// <summary>
	/// The heat map view model class.
	/// </summary>
	public class HeatMapViewModel
	{
		public HeatMapViewModel()
		{
			this.GenerateData();
		}

		public ObservableCollection<InternetData> InternetDataUsages { get; set; }

		/// <summary>
		/// Generate random data for heat map calendar based on internet data usage.
		/// </summary>
		private void GenerateData()
		{
			//// Creating an instance for internet data collection.
			InternetDataUsages = new ObservableCollection<InternetData>();
			var startDate = DateTime.Now.Date.AddMonths(-2);
			var random = new Random();

			//// Adding random data to the internet data collection.
			for (int i = 0; i < 200; i++)
			{
				InternetData internetData = new InternetData();
				internetData.Date = startDate.AddDays(i);
				//// Data usage in terms of GB.
				internetData.Usage = random.Next(0, 15);
				internetData.Color = GetColor(internetData.Usage);
				this.InternetDataUsages.Add(internetData);
			}
		}

		/// <summary>
		/// Methods to get the color based on data usage.
		/// </summary>
		/// <param name="data"></param>
		private Brush GetColor(int data)
		{
			//// Data usage in terms of GB.
			if (data < 3)
			{
				return new SolidColorBrush(Color.FromArgb(255, 238, 238, 238));
			}
			else if (data < 6)
			{
				return new SolidColorBrush(Color.FromArgb(255, 198, 228, 139));
			}
			else if (data < 9)
			{
				return new SolidColorBrush(Color.FromArgb(255, 123, 201, 111));
			}
			else if (data < 12)
			{
				return new SolidColorBrush(Color.FromArgb(255, 35, 154, 59));
			}
			else
			{
				return new SolidColorBrush(Color.FromArgb(255, 25, 97, 39));
			}
		}
	}
}
