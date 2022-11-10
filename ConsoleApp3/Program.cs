﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			#region 使用 using

			using (var conn = new SqlConnection(connString))
			{
				try
				{
					SqlCommand cmd = new SqlCommand(sql, conn);
					conn.Open();

					SqlParameter titleParam = new SqlParameter("@Title", SqlDbType.NVarChar, 50)
						{ Value = "Greeting" };

					SqlParameter contentParameter = new SqlParameter("@vcontent", SqlDbType.NVarChar, 3000)
						{ Value = "Hello!" };

					cmd.Parameters.AddRange(new SqlParameter[] { titleParam, contentParameter });
					cmd.ExecuteNonQuery();

					Console.WriteLine("紀錄已新增");
				}
				catch (Exception ex)
				{
					Console.WriteLine($"操作失敗，原因:{ex.Message}");
				}
				#endregion
			}
		}
	}
}