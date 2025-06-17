using Database.model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace diplomZ
{
    /// <summary>
    /// Логика взаимодействия для FaultInfoEdit.xaml
    /// </summary>
    public partial class FaultInfoEdit : Page
    {
        public static Fault fault;
        public FaultInfoEdit()
        {
            InitializeComponent();

            _FaultInfoEdit_CreatedAt.Text = fault.Order.Created_At.ToString();
            _FaultInfoEdit_status.Text = fault.Order.Status.Name;
            _FaultInfoEdit_Name.Text = fault.Order.Customer.FirstName;
            _FaultInfoEdit_LastName.Text = fault.Order.Customer.LastName;
            _FaultInfoEdit_Surname.Text = fault.Order.Customer.Surname;
            _FaultInfoEdit_Device.Text = fault.Device.Name;
            _FaultInfoEdit_Model.Text = fault.Device.Model;
            _FaultInfoEdit_About.Text = fault.Description;
        }

        private void Button_Click(object sender, RoutedEventArgs e) // назад
        {
            NavigationService.GoBack();
        }

        private void _FaultInfoEdit_Button_save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _FaultInfoEdit_Button_AddSolution_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
