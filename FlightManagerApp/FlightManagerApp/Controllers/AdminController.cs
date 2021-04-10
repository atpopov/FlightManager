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

        // GET: Admin
        public ActionResult Home()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id=0)
        {
            User userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        public ActionResult Edit(User userModel)
        {
            using (userContext = new UserContext())
            {
                var currentEdit = userContext.Users.First(x => x.Id == userModel.Id);
                userModel.Id = currentEdit.Id;
                userModel.Role = currentEdit.Role;
                userModel.Password = currentEdit.Password;
                userContext.Users.Remove(currentEdit);
                userContext.Users.Add(userModel);
                userContext.SaveChanges();
                return View("~/Views/Admin/Home.cshtml");
            }
        }
    }
}