using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PersonalId { get; set; }

        public string MobileNumber { get; set; }

        public string Nationality { get; set; }

        public string TicketType { get; set; }

        public int FlightId { get; set; }

        public string Email { get; set; }
    }
}
