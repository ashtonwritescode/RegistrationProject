using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        public static string GetConnectionString(string connectionName = "RegistrationProjectDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public int InsertCustomer<T>(T data)
        {
            string sql =
                @"BEGIN
                  IF NOT EXISTS(SELECT 1 FROM dbo.Customer WHERE FirstName = @FirstName AND LastName = @LastName AND AddressLine1 = @AddressLine1 AND City = @City AND State = @State AND Zipcode = @Zipcode)
                    BEGIN
                        INSERT INTO dbo.Customer (FirstName, LastName, AddressLine1, AddressLine2, City, State, Zipcode, Country, RegistrationDate)
                        VALUES (@FirstName, @LastName, @AddressLine1, @AddressLine2, @City, @State, @Zipcode, @Country, @RegistrationDate)
                     END;
                END;";

            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }
    }
}
