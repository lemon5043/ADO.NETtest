using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string connString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			Console.WriteLine(connString);

			var conn = new SqlConnection(connString);
			conn.Open();

			Console.WriteLine("Connected");
			conn.Close();
		}
	}
}
