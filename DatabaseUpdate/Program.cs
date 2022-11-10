using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iSpan.Utility;

namespace DatabaseUpdate
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"UPDATE News
						SET title = @Title,
						vContent = @vContent,
						ModifyTime = getDate() 
						where Id = @Id";
			var dbHelper = new SqlDbHelper("default");

			try
			{
				var parameters = new SqlParameterBuilder()
					.AddVarchar("title", 50, "Greeting mod")
					.AddVarchar("vContent", 3000, "Hello! mod")
					.AddInt("ID", 2)
					.Build();

				dbHelper.ExecuteNonQuery(sql, parameters);
				Console.WriteLine("紀錄已更新");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"操作失敗，原因:{ex.Message}");
			}
		}
	}
}
