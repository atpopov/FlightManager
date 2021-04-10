using Data.Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ReservationBusiness
    {
        private ReservationContext context;

        //Makes a list with all of the Reservations in the Database
        public List<Reservation> GetAll()
        {
            using (context = new ReservationContext())
            {
                return context.Reservations.ToList();
            }
        }
    }
}
