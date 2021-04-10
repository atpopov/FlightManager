using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class User
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter username!")]
        public string Username { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "Please enter your password!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your First Name!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name!")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Please enter your Personal Id!")]
        [StringLength(10)]
        [MinLength(10)]
        public string PersonalId { get; set; }

        [Required(ErrorMessage = "Please enter your Address!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your Phone Number!")]
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; }

        public string Role { get; set; }
    }
}
