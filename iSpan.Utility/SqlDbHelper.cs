using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iSpan.Utility
{
	public class SqlDbHelper
	{
		private string connString;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="keyOfConnString">app.config裡的值，例如"default"</param>
		public SqlDbHelper(string keyOfConnString)
		{
			connString = System.Configuration.ConfigurationManager.ConnectionStrings[keyOfConnString].ConnectionString;
		}

		public void ExecuteNonQuery(string sql, SqlParameter[] parameters)
		{
			using (var conn = new SqlConnection(connString))
			{
				
					SqlCommand cmd = new SqlCommand(sql, conn);
					conn.Open();


					cmd.Parameters.AddRange(parameters);
					cmd.ExecuteNonQuery();

			}
				
			}
		}
}
