using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter First Name!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Middle Name!")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Please enter Last Name!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Personal Id!")]
        [MinLength(10)]
        [MaxLength(10)]
        public string PersonalId { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number!")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Please enter Nationality!")]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Please enter Ticket Type!")]
        public string TicketType { get; set; }

        [Required(ErrorMessage = "Please enter Flight Id!")]
        public int FlightId { get; set; }

        [Required(ErrorMessage = "Please enter Email Address!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
