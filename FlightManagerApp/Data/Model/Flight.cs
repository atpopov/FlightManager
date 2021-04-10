using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Flight
    {
        public int Id { get; set; }
        public string FromLocation { get; set; }

        public string ToLocation { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string AirplaneType { get; set; }

        public string AirplaneId { get; set; }

        public string PilotName { get; set; }

        public int UnusedPlacesEconomy { get; set; }

        public int UnusedPlacesBusiness { get; set; }
    }
}
