using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheStrengthForge.Models
{
	public class LoginModel
	{

		[Required]
		[DisplayName("Username")]
		[StringLength(40, MinimumLength = 10)]
		[DefaultValue("")]
		[RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Use letters and numbers only please.")]
		[AllowHtml]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[DisplayName("Password")]
		[StringLength(20, MinimumLength = 10)]
		[DefaultValue("")]
		[RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Use letters and numbers only please.")]
		[AllowHtml]
		public string Password { get; set; }

		public string RandomSalt { get; set; }

		//[Required]
		[DisplayName("Search")]
		[StringLength(40, MinimumLength = 1)]
		[DefaultValue("")]
		[RegularExpression(@"^[0-9a-zA-Z ]+$", ErrorMessage = "Use letters, numbers, and spaces only please.")]
		[AllowHtml]
		public string SearchCriteria { get; set; }

	}
}