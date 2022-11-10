using iSpan.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSelect
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"SELECT Id, title from News where id > @Id order by id desc";
			var dbHelper = new SqlDbHelper("default");

			try
			{
				var parameters = new SqlParameterBuilder()
					.AddInt("id", 0)
					.Build();

				DataTable news = dbHelper.Select(sql, parameters);
					foreach (DataRow row in news.Rows)
					{
						int id = row.Field<int>("id");
						string title = row.Field<string>("title");
						Console.WriteLine($"ID = {id}, Title = {title}");
					}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"操作失敗，原因:{ex.Message}");
			}
		}
	}
}
