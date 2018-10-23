using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheStrengthForge.Models;

namespace TheStrengthForge.Controllers
{
	public class SearchController : Controller
    {
        // GET: Search
		[HttpGet]
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult OnSearch(LoginModel model)
		{


			if (!ModelState.IsValid)
				return View("SearchError");

			//search

			return View("~/Views/Home/Home.cshtml");
		}
    }
}