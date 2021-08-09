using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SQLWithCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customers>();
            using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                #region UPDATE 

                var newCustomer = new Customers()
                {
                    CustomerID = "BEARD",
                    ContactName = "Martin Beard",
                    City = "London",
                    CompanyName = "Sparta Global"
                };

                string sqlString = $"INSERT INTO CUSTOMERS(CustomerID, ContactName, CompanyName, City) " +
                    $"VALUES('{newCustomer.CustomerID}','{newCustomer.ContactName}', '{newCustomer.CompanyName}','{newCustomer.City}')";

                using (var command2 = new SqlCommand(sqlString, connection))
                {
                    int affected = command2.ExecuteNonQuery();
                }

                connection.Close();
                //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
                #endregion

                #region CREATE & READ 
                //using (var command = new SqlCommand("select * from Customers", connection))
                //{
                //    SqlDataReader sqlReader = command.ExecuteReader();

                //    while(sqlReader.Read())
                //    {
                //        var customerID = sqlReader["CustomerID"].ToString();
                //        var contactName = sqlReader["ContactName"].ToString();
                //        var companyName = sqlReader["CompanyName"].ToString();
                //        var city = sqlReader["City"].ToString();
                //        var contactTitle = sqlReader["ContactTitle"].ToString();

                //        var customer = new Customers()
                //        {
                //            ContactTitle = contactTitle,
                //            CustomerID = customerID,
                //            ContactName = contactName,
                //            City = city,
                //            CompanyName = companyName
                //        };

                //        customers.Add(customer);

                //    }

                //    foreach(var c in customers)
                //    {
                //        Console.WriteLine($"Customer {c.GetFullName()} has ID:{c.CustomerID} and lives in {c.City}.");
                //    }

                //    sqlReader.Close();

                //}
                #endregion
            }
        }
        public class Customers
        {
            public string CustomerID { get; set; }
            public string CompanyName { get; set; }
            public string ContactName { get; set; }
            public string ContactTitle { get; set; }
            public string City { get; set; }
            public string GetFullName()
            {
                return $"{ContactTitle} - {ContactName}";
            }
        }
    }
}