using Data.Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class FlightBusiness
    {
        private FlightContext context;

        public List<Flight> GetAll()
        {
            using (context = new FlightContext())
            {
                return context.Flights.ToList();
            }
        }
    }
}
