using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace salonlardapper.Models
{
    public class DP
    {

        public static string connectionString = @"Server=HP;Database=Salonlar;Integrated Security=true;";

        public static void ExecuteReturn(string procadi, DynamicParameters param = null)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                db.Execute(procadi, param, commandType: CommandType.StoredProcedure);
                //ekle, güncelle, sil metodu bu alanda yapılıyor.

            }
        }

        public static IEnumerable<T> Listeleme<T>(string procadi, DynamicParameters param = null)
        {
            using (SqlConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                return db.Query<T>(procadi, param, commandType: CommandType.StoredProcedure);
                //listeleme metodu bu alanda yapılıyor.
            }

        }
    }
}