using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class ReservationContext : DbContext
    {
        public ReservationContext()
            : base ("name = ReservationContext")
        {

        }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
