using StrengthForge.Services.Business;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using TheStrengthForge.Services.Utility;

namespace TheStrengthForge.Controllers
{
	public class HomeController : Controller
	{

		// injecting logging service into controller
		private readonly ILogger logger;

		public HomeController(ILogger service)
		{
			this.logger = service;
		}

		[HttpGet]
		public ActionResult Index()
		{
			logger.Info("Entering HomeController.Index()");
			//EncryptConnString();
			//DecryptConnString();
			//RewriteService rs = new RewriteService();
			//rs.Rewrite();
			return View("Home");
		}

















		//how to grab connection string from web.config
		//string ConnString = ConfigurationManager.ConnectionStrings[1].ToString();
		
		public static void EncryptConnString()
		{
			Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
			ConfigurationSection section = config.GetSection("connectionStrings");

			if (!section.SectionInformation.IsProtected)
			{
				section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
				config.Save();
			}
		}
		
		public static void DecryptConnString()
		{
			Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
			ConfigurationSection section = config.GetSection("connectionStrings");

			if (section.SectionInformation.IsProtected)
			{
				section.SectionInformation.UnprotectSection();
				config.Save();
			}
		}
	
	}
}