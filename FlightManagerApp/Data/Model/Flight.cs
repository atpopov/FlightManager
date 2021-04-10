using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Flight
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a departure location!")]
        public string FromLocation { get; set; }

        [Required(ErrorMessage = "Please enter an arrival location!")]
        public string ToLocation { get; set; }

        [Required(ErrorMessage = "Please enter a departure date!")]
        [DataType(DataType.DateTime)]
        public DateTime DepartureTime { get; set; }

        [Required(ErrorMessage = "Please enter an arrival date!")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalTime { get; set; }

        [Required(ErrorMessage = "Please enter an airplane type!")]
        public string AirplaneType { get; set; }

        [Required(ErrorMessage = "Please enter an airplane id!")]
        public string AirplaneId { get; set; }

        [Required(ErrorMessage = "Please enter a pilot's name!")]
        public string PilotName { get; set; }

        [Required(ErrorMessage = "Please enter the free Economy class tickets!")]
        public int UnusedPlacesEconomy { get; set; }

        [Required(ErrorMessage = "Please enter the free Business class tickets!")]
        public int UnusedPlacesBusiness { get; set; }
    }
}
