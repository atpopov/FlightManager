using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class FlightContext : DbContext
    {
        public FlightContext()
            :base ("name = FlightContext")
        {

        }

        public DbSet<Flight> Flights { get; set; }
    }
}
