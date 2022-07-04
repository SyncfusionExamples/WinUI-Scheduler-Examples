using Microsoft.UI;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FareCalendarDataTemplateSelector
{
    /// <summary>
    /// The airlines view model.
    /// </summary>
    public class AirlinesViewModel
    {
        /// <summary>
        /// Gets or sets the lowest airfares.
        /// </summary>
        public List<Airline> LowestFares { get; set; }

        /// <summary>
        /// Initializes a new instance of the AirlinesViewModel class.
        /// </summary>
        public AirlinesViewModel()
        {
            GetLowestFares();
        }

        /// <summary>
        /// Methods to get the lowest airfares.
        /// </summary>
        private void GetLowestFares()
        {
            this.LowestFares = new List<Airline>();
            List<Airline> fares = GetAllFares();

            var currentDate = DateTime.Now.Date;
            for (int startdate = -100; startdate < 100; startdate++)
            {
                var currentDateFares = fares.Where(x => x.Date == currentDate.AddDays(startdate)).ToList();
                //Add only lowest fare for the day. 
                double minimumFare = Math.Min(currentDateFares[0].Fare, Math.Min(currentDateFares[1].Fare, currentDateFares[2].Fare));
                this.LowestFares.Add(currentDateFares.Where(x => x.Fare == minimumFare).FirstOrDefault());
            }
        }

        /// <summary>
        /// Method to get all the airways fare.
        /// </summary>
        /// <returns>returns all airways fares</returns>
        private List<Airline> GetAllFares()
        {
            var random = new Random();
            var fares = new List<Airline>();
            var airwaysFares = new List<double>()
             {
                90.50, 95.00, 102.66, 200.09, 180.20, 122.10, 138.83,
                134.50, 305.00, 152.66, 267.09, 189.20, 212.10, 238.83,
                100.17, 101.72, 332.48 ,100.17, 449.68, 378.44, 273.45,
            };

            for (int startdate = -100; startdate < 100; startdate++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    var airline = new Airline();
                    airline.Name = "Airways " + j.ToString();
                    //// Adding random fares for airways.
                    airline.Fare = airwaysFares[random.Next(0, 20)];
                    airline.Cost = "$" + airline.Fare.ToString();
                    airline.Color = GetAirlineColor(airline.Name);
                    airline.Date = DateTime.Now.Date.AddDays(startdate);
                    fares.Add(airline);
                }
            }

            return fares;
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
