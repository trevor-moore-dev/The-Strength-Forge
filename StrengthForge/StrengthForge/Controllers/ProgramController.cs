using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheStrengthForge.Controllers
{
	public class ProgramController : Controller
    {
        // GET: Program
        public ActionResult Index()
        {
            return View();
        }

		public ActionResult OnPowerlifting1()
		{
			return View("Powerlifting1");
		}

		public ActionResult OnPowerlifting2()
		{
			return View("Powerlifting2");
		}

		public ActionResult OnPowerlifting3()
		{
			return View("Powerlifting3");
		}

		public ActionResult OnPowerlifting4()
		{
			return View("Powerlifting4");
		}

		public ActionResult OnPowerlifting5()
		{
			return View("Powerlifting5");
		}
	}
}