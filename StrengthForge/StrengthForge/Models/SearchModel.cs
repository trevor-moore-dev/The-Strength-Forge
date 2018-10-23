using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheStrengthForge.Models
{
	public class SearchModel
	{

		[Required]
		[DisplayName("Search")]
		[StringLength(40, MinimumLength = 1)]
		[DefaultValue("")]
		[RegularExpression(@"^[0-9a-zA-Z ]+$", ErrorMessage = "Use letters, numbers, and spaces only please.")]
		[AllowHtml]
		public string SearchCriteria { get; set; }

	}
}