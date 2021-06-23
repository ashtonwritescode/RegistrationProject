using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataLibrary.Repositories
{
    public class ReportingRepository : IReportingRepository
    {
        public static string GetConnectionString(string connectionName = "RegistrationProjectDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public List<T> GetCustomers<T>()
        {
            string sql = @"SELECT FirstName, LastName, AddressLine1, AddressLine2, City, State, Zipcode, Country, RegistrationDate
                           FROM dbo.Customer ORDER BY RegistrationDate DESC";

            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }
    }
}
