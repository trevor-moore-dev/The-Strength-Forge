using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheStrengthForge.Models;
using TheStrengthForge.Services.Data;
using TheStrengthForge.Services.Utility;

namespace TheStrengthForge.Services.Business
{
	public class SecurityService
	{
		// injecting logging service into controller
		private readonly ILogger logger;

		public SecurityService(ILogger service)
		{
			this.logger = service;
		}

		//method for calling Create method from SecurityDAO class
		public string Register(LoginModel user)
		{
			logger.Info("Inside SecurityService");
			SecurityDAO service = new SecurityDAO(logger);

			// return result of Create method called on security dao
			return service.Create(user);
		}
	}
}