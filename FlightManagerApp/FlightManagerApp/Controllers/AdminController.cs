using Data.Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightManagerApp.Controllers
{
    public class AdminController : Controller
    {
        UserContext userContext;
        FlightContext flightContext;

        // GET: Admin
        public ActionResult Home()
        {
            return View();
        }


        //Get Method for the Edit User Page
        [HttpGet]
        public ActionResult EditUser(int id=0)
        {
            User userModel = new User();
            return View(userModel);
        }

        //Post Method for the Edit User Page
        [HttpPost]
        public ActionResult EditUser(User userModel)
        {
            using (userContext = new UserContext())
            {
                if (userModel.Username == null || userModel.FirstName == null || userModel.LastName == null || userModel.MobileNumber == null
                    || userModel.PersonalId == null || userModel.Address == null || userModel.MobileNumber == null)
                {
                    ViewBag.FailedAddMessage = "You must fill in all of the spaces and the data should be correct!";
                    return View("EditUser", new User());
                }
                else
                {
                    userContext.Users.First(x => x.Id == userModel.Id).Username = userModel.Username;
                    userContext.Users.First(x => x.Id == userModel.Id).FirstName = userModel.FirstName;
                    userContext.Users.First(x => x.Id == userModel.Id).LastName = userModel.LastName;
                    userContext.Users.First(x => x.Id == userModel.Id).MobileNumber = userModel.MobileNumber;
                    userContext.Users.First(x => x.Id == userModel.Id).PersonalId = userModel.PersonalId;
                    userContext.Users.First(x => x.Id == userModel.Id).Address = userModel.Address;
                    userContext.Users.First(x => x.Id == userModel.Id).MobileNumber = userModel.MobileNumber;
                    userContext.SaveChanges();
                    return View("~/Views/Admin/Home.cshtml");
                }
            }
        }

        //Get Method for the Edit Flight Page
        [HttpGet]
        public ActionResult EditFlight(int id = 0)
        {
            Flight flightModel = new Flight();
            return View(flightModel);
        }

        //Post Method for the Edit Flight Page
        [HttpPost]
        public ActionResult EditFlight(Flight flightModel)
        {
            using(flightContext = new FlightContext())
            {
                if (flightModel.FromLocation == null || flightModel.ToLocation == null || flightModel.DepartureTime == null || flightModel.ArrivalTime == null
                    || flightModel.AirplaneType == null || flightModel.AirplaneId == null || flightModel.PilotName == null ||
                    flightModel.UnusedPlacesBusiness <= 0 || flightModel.UnusedPlacesEconomy <= 0 || flightModel.DepartureTime>flightModel.ArrivalTime)
                {
                    ViewBag.FailedAddMessage = "You must fill in all of the spaces and the data should be correct!";
                    return View("EditFlight", new Flight());
                }
                else
                {
                    flightContext.Flights.First(x => x.Id == flightModel.Id).FromLocation = flightModel.FromLocation;
                    flightContext.Flights.First(x => x.Id == flightModel.Id).ToLocation = flightModel.ToLocation;
                    flightContext.Flights.First(x => x.Id == flightModel.Id).DepartureTime = flightModel.DepartureTime;
                    flightContext.Flights.First(x => x.Id == flightModel.Id).ArrivalTime = flightModel.ArrivalTime;
                    flightContext.Flights.First(x => x.Id == flightModel.Id).AirplaneType = flightModel.AirplaneType;
                    flightContext.Flights.First(x => x.Id == flightModel.Id).AirplaneId = flightModel.AirplaneId;
                    flightContext.Flights.First(x => x.Id == flightModel.Id).PilotName = flightModel.PilotName;
                    flightContext.SaveChanges();
                    return View("~/Views/Admin/Home.cshtml");
                }
            }
        }

        //Get Method for the Add Flight Page
        [HttpGet]
        public ActionResult AddFlight(int id = 0)
        {
            Flight flightModel = new Flight();
            return View(flightModel);
        }

        //Post Method for the Add Flight Page
        [HttpPost]
        public ActionResult AddFlight(Flight flightModel)
        {
            using (flightContext = new FlightContext())
            {
                if (flightModel.FromLocation == null || flightModel.ToLocation == null || flightModel.DepartureTime == null || flightModel.ArrivalTime == null
                    || flightModel.AirplaneType == null || flightModel.AirplaneId == null || flightModel.PilotName == null ||
                    flightModel.UnusedPlacesBusiness <= 0 || flightModel.UnusedPlacesEconomy <= 0 || flightModel.DepartureTime > flightModel.ArrivalTime)
                {
                    ViewBag.FailedAddMessage = "You must fill in all of the spaces and the data should be correct!";
                    return View("AddFlight", new Flight());
                }
                else
                {
                    flightContext.Flights.Add(flightModel);
                    flightContext.SaveChanges();
                }
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Flight was successfully added!";
            return View("~/Views/Admin/Home.cshtml");
        }

        //Method for displaying the details of a flight
        public ActionResult FlightDetails(int id = 0)
        {
            using (FlightContext flightContext = new FlightContext())
            {
                Flight flight = flightContext.Flights.First(x => x.Id == id);
                if (flight == null)
                {
                    return View("~/Views/Home/Index.cshtml");
                }
                return View(flight);
            }

        }
    }
}