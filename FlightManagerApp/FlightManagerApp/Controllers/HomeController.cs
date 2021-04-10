using Data.Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace FlightManagerApp.Controllers
{
    public class HomeController : Controller
    {
        User loggedInUser;

        public ActionResult Index()
        {
            return View();
        }

        //Get Method for the Login Page
        [HttpGet]
        public ActionResult Login(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }

        //Post Method for the Login Page
        [HttpPost]
        public ActionResult Login(User userModel)
        {
            using (UserContext context = new UserContext())
            {
                if (context.Users.Any(x => x.Username == userModel.Username && x.Password == userModel.Password))
                {
                    var ddd = context.Users.Where(x => x.Username == userModel.Username && x.Password == userModel.Password);
                    loggedInUser = userModel;

                    //Methods for storing the data for the logged in User, so we can use it in the other Controllers
                    TempData["Admin"] = ddd.First();
                    TempData["Employee"] = ddd.First();
                    ViewBag.SuccessLoginMessage = "Success!";
                    if (ddd.First().Role == "Admin")
                    {
                        return View("~/Views/Admin/Home.cshtml");
                    }
                    else if (ddd.First().Role == "Employee")
                    {
                        return View("~/Views/Employee/Home.cshtml");
                    }
                    else return View("~/Views/Home/Index.cshtml");
                }
                else
                {
                    ViewBag.FailedLoginMessage = "The username or password is invalid!";
                    return View("Login", new User());
                }
            }
        }
        
        //Get Method for the Registration Page
        [HttpGet]
        public ActionResult Register(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }

        //Post Method for the Registration Page
        [HttpPost]
        public ActionResult Register(User userModel)
        {
            using (UserContext context = new UserContext())
            {
                if (userModel.FirstName == null || userModel.LastName == null || userModel.Password == null
                    || userModel.PersonalId == null || userModel.PersonalId.Length !=10 || userModel.MobileNumber==null || userModel.Username == null)
                {
                    ViewBag.FailedRegisterMessage = "You must fill in all of the spaces!";
                    return View("Register", new User());
                }
                else
                {

                    if (context.Users.Count() == 0)
                    {
                        userModel.Role = "Admin";
                    }
                    else
                    {
                        userModel.Role = "Employee";
                    }
                    if (context.Users.Any(x => x.Username == userModel.Username))
                    {
                        ViewBag.DuplicateMessage = "An User with this user name already exists.";
                        return View("Register", userModel);
                    }
                    context.Users.Add(userModel);
                    context.SaveChanges();

                }
                ModelState.Clear();
                ViewBag.SuccessMessage = "Register successful!";
                return View("~/Home/Index.cshtml");
            }
        }

        //Get Method for the Reservation Page
        [HttpGet]
        public ActionResult Reservation(int id = 0)
        {
            Data.Model.Reservation reservationModel = new Reservation();
            return View(reservationModel);
        }

        //Post Method for the Reservation Page with the Email Sending functionality
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

        //Method for displaying the details of a flight
        public ActionResult FlightDetails(int id=0)
        {
            using(FlightContext flightContext = new FlightContext())
            {
                Flight flight = flightContext.Flights.First(x => x.Id == id);
                if (flight == null)
                {
                    return View("~/Views/Home/Index.cshtml");
                }                
                return View(flight);
            }
           
        }

        //Method for Logout
        public ActionResult Logout()
        {
            loggedInUser = null;
            return View("~/Views/Home/Index.cshtml");
        }


    }
}