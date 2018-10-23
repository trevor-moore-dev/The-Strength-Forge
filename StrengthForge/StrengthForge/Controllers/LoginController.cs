using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using TheStrengthForge.Models;
using TheStrengthForge.Services.Business;
using TheStrengthForge.Services.Utility;

namespace TheStrengthForge.Controllers
{
	public class LoginController : Controller
    {
		// injecting logging service into controller
		private readonly ILogger logger;

		public LoginController(ILogger service)
		{
			this.logger = service;
		}

		// GET: Login
		[HttpGet]
        public ActionResult Index()
        {
			LoginModel nm = new LoginModel();
			Random rndm = new Random();

			#pragma warning disable 618
			var Salt = FormsAuthentication.HashPasswordForStoringInConfigFile(Convert.ToString(rndm.Next()), "MD5");
			#pragma warning restore 618
			Trace.WriteLine("---------This is the salt: " + Salt);
			nm.RandomSalt = Salt;

			return View("Login", nm);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult OnLogin(LoginModel model)
		{
			logger.Info("Entering LoginController.OnLogin()");
			logger.Info("Parameters are: {0}", new JavaScriptSerializer().Serialize(model));

			
			Random rndm = new Random();

			#pragma warning disable 618
			var Salt = FormsAuthentication.HashPasswordForStoringInConfigFile(Convert.ToString(rndm.Next()), "MD5");
			#pragma warning restore 618
			Trace.WriteLine("---------This is the salt on creation: " + Salt);
			model.RandomSalt = Salt;

			logger.Info("Parameters are: {0}", new JavaScriptSerializer().Serialize(model));
			try
			{
				//validate input
				if (!ModelState.IsValid)
					return View("Login", model);

				//new security service for registering user
				SecurityService ss = new SecurityService(logger);

				string result = ss.Register(model);

				//returning the correct view
				if (result.Equals("success"))
				{
					logger.Info("Exiting LoginController.OnLogin() with login success");
					return View("~/Views/Home/Home.cshtml");
				}
				else if (result.Equals("fail"))
				{
					logger.Info("Exiting LoginController.OnLogin() with login fail");
					Trace.WriteLine("Fail");
					return View("~/Views/Shared/Error.cshtml");
				}
				else
				{
					logger.Info("Exiting LoginController.OnLogin() with attempt to login duplicate user");
					Trace.WriteLine("Duplicate");
					return View("~/Views/Shared/Error.cshtml");
				}
			}
			catch (Exception e)
			{
				logger.Error("Exception LoginController.OnLogin() " + e.Message);
				logger.Info(e.Message);
				Trace.WriteLine("Exception");
				return View("~/Views/Shared/Error.cshtml");
			}
		}

	}
}