using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using iSpan.Utility;

namespace ConsoleApp3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string connString = System.Configuration.ConfigurationManager.ConnectionStrings["default"].ConnectionString;
			string sql = @"INSERT INTO News
						(Title, vContent, ModifyTime)
						VALUES(@Title, @vContent, getdate())";
			var dbHelper = new SqlDbHelper("default");

				try
				{
					SqlParameter titleParam = new SqlParameter("@Title", SqlDbType.NVarChar, 50)
						{ Value = "Greeting" };

					SqlParameter contentParam = new SqlParameter("@vcontent", SqlDbType.NVarChar, 3000)
						{ Value = "Howdy!" };
					var parameters = new SqlParameter[] { titleParam, contentParam };

					dbHelper.ExecuteNonQuery(sql, parameters);
					Console.WriteLine("紀錄已新增");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"操作失敗，原因:{ex.Message}");
				}
		}
	}
}
