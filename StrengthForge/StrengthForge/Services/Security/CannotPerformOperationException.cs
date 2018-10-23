using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheStrengthForge.Services.Security
{
	public class CannotPerformOperationException : Exception
	{
		public CannotPerformOperationException() { }
		public CannotPerformOperationException(string message)
			: base(message) { }
		public CannotPerformOperationException(string message, Exception inner)
			: base(message, inner) { }
	}
}