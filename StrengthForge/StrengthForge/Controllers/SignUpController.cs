using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheStrengthForge.Models;

namespace TheStrengthForge.Controllers
{
	public class SignUpController : Controller
    {
        // GET: SignUp
		[HttpGet]
        public ActionResult Index()
        {
            return View("SignUp");
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult OnSignUp(SignUpModel model, String sex)
		{
			if (!ModelState.IsValid)
				return View("SignUp");

			//rergister user

			return View("~/Views/Home/Home.cshtml");
		}
    }
}