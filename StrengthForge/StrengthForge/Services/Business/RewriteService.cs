using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace StrengthForge.Services.Business
{
	public class RewriteService
	{

		public void Rewrite()
		{

			File.WriteAllText(@"C:\Users\Trevor\Documents\Summer2018Project\StrengthForge\StrengthForge\Controllers\HomeController.cs", "using System;using System.Collections.Generic;using System.Configuration;using System.Linq;using System.Web;using System.Web.Configuration;using System.Web.Mvc;using TheStrengthForge.Services.Utility;namespace TheStrengthForge.Controllers{public class HomeController : Controller{private readonly ILogger logger;public HomeController(ILogger service){this.logger = service;}[HttpGet]public ActionResult Index(){logger.Info(" + "\"" + "Entering HomeController.Index()" + "\"" + ");return View(" + "\"" + "Home" +"\"" + ");}}}");


		}

	}
}