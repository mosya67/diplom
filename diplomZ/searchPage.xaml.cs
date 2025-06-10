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
    /// Логика взаимодействия для searchPage.xaml
    /// </summary>
    public partial class searchPage : Page
    {
        public static List<Fault> faults;

        public searchPage()
        {
            InitializeComponent();
            for (int i = 0; i < faults.Count; i++)
            {
                searchPage_ListBox.Items.Add(new FaultDTO(faults[i], i));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) // go back
        {
            NavigationService.GoBack();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // сброс сортировки
        {
            search_radioButton_name.IsChecked = false;
            search_radioButton_lastName.IsChecked = false;
            search_radioButton_surname.IsChecked = false;
            search_radioButton_device.IsChecked = false;
            search_radioButton_model.IsChecked = false;
            search_radioButton_createdAt.IsChecked = true;
            search_radioButton_status.IsChecked = false;
            search_radioButton_repairDate.IsChecked = false;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // применить сортировку
        {

        }

        private void searchPage_ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string selectedItem = searchPage_ListBox.SelectedItem.ToString();
        }

        private class FaultDTO
        {
            private Fault fault;
            private int numb;

            public FaultDTO(Fault fault, int numb)
            {
                this.fault = fault ?? throw new ArgumentNullException(nameof(fault));
                this.numb = numb;
            }

            public override string ToString()
            {
                return $"{numb}. {fault.Order.Created_At} {fault.Order.Status.Name}\n"
                        + $"{new string(' ', )}{fault.Order.Customer.LastName} {fault.Order.Customer.FirstName} {fault.Order.Customer.Surname}\n"
                        + $"{new string(' ', )}{fault.Device.Model}";
            }
        }
    }
}
