using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iSpan.Utility;

namespace DatabaseDelete
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string sql = @"DELETE 
						from News
						where Id = @Id";
			var dbHelper = new SqlDbHelper("default");

			try
			{
				var parameters = new SqlParameterBuilder()
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
