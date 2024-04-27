using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CustomerBusiness
    {
        public List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>();
            CustomerData data = new CustomerData();
            customers = data.GetCustomer();
            return customers;
        }

        public List<Customer> GetCustomerByName(string name)
        {
            CustomerData data = new CustomerData();
            List<Customer> customers = data.GetCustomer();

            List<Customer> customersByName = new List<Customer>();
            ///Permite realizar la busqueda por cualquier letra que este dentro del nombre .Contains
            ///Claro, puedes convertir el bucle foreach y la condición if en una expresión lambda utilizando el método Where de LINQ
            customersByName = customers.Where(customer => customer.Name.Contains(name)).ToList();
            return customersByName;
        }
    }
}
