using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStrengthForge.Services.Utility
{
	public interface ILogger
	{
		// debug method with optional second argument for message
		void Debug(string message, string arg = null);

		// info method with optional second argument for message
		void Info(string message, string arg = null);

		// warning method with optional second argument for message
		void Warning(string message, string arg = null);

		// error method with optional second argument for message
		void Error(string message, string arg = null);

	}
}

