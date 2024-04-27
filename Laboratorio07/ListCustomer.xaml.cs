using Business;
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
    /// Lógica de interacción para ListCustomer.xaml
    /// </summary>
    public partial class ListCustomer : Window
    {
        private CustomerBusiness customerBusiness;
        public ListCustomer()
        {
            InitializeComponent();
            customerBusiness = new CustomerBusiness();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            dgCustomer1.ItemsSource = customerBusiness.GetCustomerByName(name);
        }
    }
}
