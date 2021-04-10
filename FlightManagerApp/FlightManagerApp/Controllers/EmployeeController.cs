using Data.Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace FlightManagerApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Reservation(int id = 0)
        {
            Data.Model.Reservation reservationModel = new Reservation();
            return View(reservationModel);
        }

        [HttpPost]
        public ActionResult Reservation(Reservation reservationModel)
        {

            Flight bookedFlight = new Flight();
            using (FlightContext flightContext = new FlightContext())
            {
                if (reservationModel.FirstName == null || reservationModel.MiddleName == null || reservationModel.LastName == null || reservationModel.PersonalId == null
                    || reservationModel.Nationality == null || reservationModel.TicketType == null || reservationModel.Email == null || reservationModel.FlightId == 0
                    || reservationModel.MobileNumber == null)
                {
                    ViewBag.FailedRservationMessage = "You must fill in all of the spaces!";
                    return View("Reservation", new Reservation());
                }
                else
                {
                    foreach (var flight in flightContext.Flights)
                    {
                        if (reservationModel.FlightId == flight.Id) bookedFlight = flight;
                    }

                    if (reservationModel.TicketType.ToLower() == "business")
                    {
                        if (bookedFlight.UnusedPlacesBusiness <= 0)
                        {
                            ViewBag.DuplicateMessage = "There are not enough Business places.";
                            return View("Reservation", reservationModel);
                        }
                        else
                        {
                            foreach (var flight in flightContext.Flights)
                            {
                                if (reservationModel.FlightId == flight.Id) flight.UnusedPlacesBusiness -= 1;
                            }
                            flightContext.SaveChanges();
                        }
                    }
                    else
                    {
                        if (bookedFlight.UnusedPlacesEconomy <= 0)
                        {
                            ViewBag.DuplicateMessage = "There are not enough Economy places.";
                            return View("Reservation", reservationModel);
                        }
                        else
                        {
                            foreach (var flight in flightContext.Flights)
                            {
                                if (reservationModel.FlightId == flight.Id) flight.UnusedPlacesEconomy -= 1;
                            }
                            flightContext.SaveChanges();
                        }
                    }


                    using (ReservationContext reservationContext = new ReservationContext())
                    {
                        reservationContext.Reservations.Add(reservationModel);
                        reservationContext.SaveChanges();
                    }
                    ModelState.Clear();
                    ViewBag.SuccessMessage = "Reservation successful!";
                    MailMessage o = new MailMessage("taisan9931@hotmail.com", $"{reservationModel.Email}",
                        "Flight Ticket", $"Hello, Mr/Mrs{reservationModel.LastName}," + $" Your flight ticket was booked successfully!" + "    " +
                        $"Departure : {bookedFlight.FromLocation}" + "    " +
                        $"Arrival : {bookedFlight.ToLocation}" + "    " +
                        $"Departure Time : {bookedFlight.DepartureTime}" + "    " +
                        $"Arrival Time : {bookedFlight.ArrivalTime}" + "    " +
                        $"Class : {reservationModel.TicketType}" + "    " +
                        $"Have a good flight!");
                    NetworkCredential netCred = new NetworkCredential("taisan9931@hotmail.com", "taisan993");
                    SmtpClient smtpobj = new SmtpClient("smtp.live.com", 587);
                    smtpobj.EnableSsl = true;
                    smtpobj.Credentials = netCred;
                    smtpobj.Send(o);
                    return View("Reservation", new Reservation());
                }
            }
        }
    }
}