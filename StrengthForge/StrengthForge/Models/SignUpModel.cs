using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheStrengthForge.Models
{
	public class SignUpModel
	{
		[Required]
		[DisplayName("First Name")]
		[StringLength(30, MinimumLength = 2)]
		[DefaultValue("")]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		[AllowHtml]
		public string Firstname { get; set; }

		[Required]
		[DisplayName("Last Name")]
		[StringLength(30, MinimumLength = 2)]
		[DefaultValue("")]
		[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
		[AllowHtml]
		public string Lastname { get; set; }

		[Required]
		[DisplayName("Age")]
		[Range(18, 120)]
		[DefaultValue("")]
		[AllowHtml]
		public int Age { get; set; }

		[Required]
		[DisplayName("Weight in Pounds")]
		[Range(50, 600)]
		[DefaultValue("")]
		[AllowHtml]
		public int Weight { get; set; }

		[Required]
		[DisplayName("Height in Inches")]
		[Range(36, 108)]
		[DefaultValue("")]
		[AllowHtml]
		public int Height { get; set; }

		[Required]
		[DisplayName("Username")]
		[StringLength(40, MinimumLength = 10)]
		[DefaultValue("")]
		[RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Use letters and numbers only please.")]
		[AllowHtml]
		public string Username { get; set; }

		[Required]
		[DisplayName("Email")]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		[DefaultValue("")]
		[AllowHtml]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[DisplayName("Password")]
		[StringLength(20, MinimumLength = 10)]
		[DefaultValue("")]
		[RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Use letters and numbers only please.")]
		[AllowHtml]
		public string Password { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[DisplayName("Confirm Password")]
		[StringLength(20, MinimumLength = 10)]
		[DefaultValue("")]
		[RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Use letters and numbers only please.")]
		[System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Passwords do not match.")]
		[AllowHtml]
		public string ConfirmPassword { get; set; }

		public string RandomSalt { get; set; }

	}
}