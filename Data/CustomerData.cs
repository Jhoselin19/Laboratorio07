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
        private string connectionString = "Data Source=LAB1504-27\\TECSUP ;Initial Catalog=Lab07;User Id=user01;Password=123456";

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
        public void RegisterCustomer(Customer customer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("InsertCustomer", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Name", string.IsNullOrEmpty(customer.Name) ? DBNull.Value : (object)customer.Name);
                        cmd.Parameters.AddWithValue("@Address", string.IsNullOrEmpty(customer.Address) ? DBNull.Value : (object)customer.Address);
                        cmd.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(customer.Phone) ? DBNull.Value : (object)customer.Phone);


                        // Registrar los valores de los parámetros
                        Console.WriteLine($"ID Cliente: {customer.CustomerID}, Nombre: {customer.Name}, Dirección: {customer.Address}, Teléfono: {customer.Phone}");

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar la excepción o lanzarla nuevamente para manejarla en un nivel superior
                Console.WriteLine($"Error al registrar el cliente: {ex.Message}");
                throw;
            }
        }



        public void Drop(Customer customer)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("DeletCustomer", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdClient", customer.CustomerID);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
    }
}
