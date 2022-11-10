using iSpan.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"CREATE database VStest";
			var dbHelper = new SqlDbHelper("default");

			try
			{
				var parameters = new SqlParameterBuilder()
					.Build();

				dbHelper.ExecuteNonQuery(sql, parameters);
				Console.WriteLine("已建立database");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"操作失敗，原因:{ex.Message}");
			}
		}
	}
}
