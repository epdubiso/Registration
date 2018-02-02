using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2017MVC.Models;

namespace CommunityAssist2017MVC.Controllers
{
    public class RegistrationController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Registration
        public ActionResult Index()
        {
            return View(db.PersonAddresses.ToList());
        }

        public ActionResult Register()


        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "LastName, FirstName,"+
             "Email, Phone, PlainPassword, Apartment, Street, State, ZipCode" )]NewPerson np)
        {
            int result = db.usp_Person(
                np.LastName,
                np.FirstName,
                np.Email,
                np.Phone,
                np.PlainPassword,
                np.Apartment,
                np.Street,
                np.State,
                np.Zipcode);

            if (result != -1)

            { 

                return RedirectToAction("Index");
            }


            return View();
        }

    }
}