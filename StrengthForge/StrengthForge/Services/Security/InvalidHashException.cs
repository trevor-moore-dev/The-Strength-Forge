using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheStrengthForge.Services.Security
{
	public class InvalidHashException : Exception
	{
		public InvalidHashException() { }
		public InvalidHashException(string message)
			: base(message) { }
		public InvalidHashException(string message, Exception inner)
			: base(message, inner) { }
	}
}