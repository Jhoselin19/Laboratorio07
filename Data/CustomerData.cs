using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CustomerData
    {
        private string connectionString = "Data Source=LAB1504-26\\TECSUP ;Initial Catalog=Lab07;User Id=user01;Password=123456";

        public List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetCustomers", connection);
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Customer customer = new Customer
                    {
                        CustomerID = reader.GetInt32(reader.GetOrdinal("customer_id")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        Address = reader.IsDBNull(reader.GetOrdinal("address")) ? string.Empty : reader.GetString(reader.GetOrdinal("address")),
                        Phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? string.Empty : reader.GetString(reader.GetOrdinal("phone")),
                        Active = reader.GetBoolean(reader.GetOrdinal("active"))
                    };

                    customers.Add(customer);
                }
            }

            return customers;
        }
    }
}
