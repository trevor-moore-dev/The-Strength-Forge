using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using TheStrengthForge.Models;
using TheStrengthForge.Services.Security;
using TheStrengthForge.Services.Utility;

namespace TheStrengthForge.Services.Data
{
	public class SecurityDAO
	{
		// injecting logging service into controller
		private readonly ILogger logger;

		public SecurityDAO(ILogger service)
		{
			this.logger = service;
		}

		
		

		//method for registering a user
		public string Create(LoginModel user)
		{
			logger.Info("Inside securityDAO");
			string connString = ConfigurationManager.ConnectionStrings["tsfdbconn"].ToString();
			//ConfigurationManager.ConnectionStrings[1].ToString();
			bool result = false;
			int userId = 1;
			string secureHash = PasswordStorage.CreateHash(user.Password);
			logger.Info("This is the hashed password: " + secureHash);
			logger.Info("This is salt in the data layer\nafter passing through client layer: " + user.RandomSalt);
			try
			{
				// checking to see if username is already in database
				string query = "SELECT * FROM dbo.TSFUT WHERE USERNAME=@Username";

				//create connection and command
				using (SqlConnection cn = new SqlConnection(connString))
				using (SqlCommand cmd = new SqlCommand(query, cn))
				{
					//set query parameters and their values
					cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = user.Username;

					//open the connection
					cn.Open();

					//using a datareader see if query returns any rows (to make sure that username or password is not already in the database)
					SqlDataReader reader = cmd.ExecuteReader();
					if (reader.HasRows)
						result = false;
					else
						result = true;

					//close connection
					cn.Close();
				}
				logger.Info("Duplicate check success");
				if (result == false)
					return "duplicate";

				// Setup INSERT query with parameters
				query = "INSERT INTO dbo.TSFUT (USERNAME, USERKEY, USERCRED) VALUES (@Username, @Password, @RandomSalt); SELECT SCOPE_IDENTITY () As UserID";

				// Create connection and command
				using (SqlConnection cn = new SqlConnection(connString))
				using (SqlCommand cmd = new SqlCommand(query, cn))
				{
					// Set query parameters and their values
					cmd.Parameters.Add("@Username", SqlDbType.VarChar, 50).Value = user.Username;
					cmd.Parameters.Add("@Password", SqlDbType.VarChar, 200).Value = secureHash;
					cmd.Parameters.Add("@RandomSalt", SqlDbType.VarChar, 200).Value = user.RandomSalt;

					// Open the connection, execute INSERT, and close the connection
					cn.Open();

					// execute query using sqldatareader
					SqlDataReader dataReader = cmd.ExecuteReader();
					logger.Info("Insert Success");

					// if the query returned rows save the user's ID
					if (dataReader.HasRows)
					{
						dataReader.Read();
						userId = Convert.ToInt32(dataReader["UserID"]);
					}

					//close connection
					cn.Close();
				}
			}
			catch (SqlException e)
			{
				// TODO: should log exception and then throw a custom exception
				throw e;
			}

			// Return result of insert
			if (result == false)
				return "fail";
			else
				return "success";

		}
	}
}