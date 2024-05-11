using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Laboratorio07
{
    /// <summary>
    /// Lógica de interacción para RegisterCustomer.xaml
    /// </summary>
    public partial class RegisterCustomer : Window
    {
        private CustomerBusiness customerBusiness;
        public RegisterCustomer()
        {
            InitializeComponent();
            customerBusiness = new CustomerBusiness();
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            List<Customer> customers = customerBusiness.GetActiveCustomers();
            ListarClientes.ItemsSource = customers;
        }

        private void RegisterClient(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer
            {
                Name = txtName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Active = true
            };

            CustomerBusiness business = new CustomerBusiness();

            business.RegisterCustomer(customer);

            MessageBox.Show("Cliente registrado.");
            LoadCustomerData();


        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            txtCustomerID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        private void DeletClient(object sender, RoutedEventArgs e)
        {
            int customerId;
            // Verificar si se ha ingresado un ID de cliente válido
            if (int.TryParse(txtCustomerID.Text, out customerId))
            {
                // Instanciar la capa de negocios CustomerBusiness
                CustomerBusiness business = new CustomerBusiness();

                Customer customer = new Customer
                {
                    CustomerID = customerId
                };

                business.DeleteCustomer(customer);

                MessageBox.Show("Cliente eliminado.");
                LoadCustomerData();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un ID de cliente válido.");
            }
        }


    }
}
