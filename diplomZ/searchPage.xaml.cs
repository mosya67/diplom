using Database.Db;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        {}

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
            List<FaultDTO> dto = new List<FaultDTO>();
            for (int i = 0; i < searchPage_ListBox.Items.Count; i++)
                dto.Add((FaultDTO)searchPage_ListBox.Items[i]);

            if ((bool)search_radioButton_name.IsChecked)
            {
                dto = dto.OrderBy(e => e.fault.Order.Customer.FirstName).ToList();
            }
            else if ((bool)search_radioButton_lastName.IsChecked)
            {
                dto = dto.OrderBy(e => e.fault.Order.Customer.LastName).ToList();
            }
            else if ((bool)search_radioButton_surname.IsChecked)
            {
                dto = dto.OrderBy(e => e.fault.Order.Customer.Surname).ToList();
            }
            else if ((bool)search_radioButton_model.IsChecked)
            {
                dto = dto.OrderBy(e => e.fault.Device.Model).ToList();
            }
            else if ((bool)search_radioButton_device.IsChecked)
            {
                dto = dto.OrderBy(e => e.fault.Device.Name).ToList();
            }
            else if ((bool)search_radioButton_createdAt.IsChecked)
            {
                dto = dto.OrderBy(e => e.fault.Order.Created_At).ToList();
            }
            else if ((bool)search_radioButton_repairDate.IsChecked)
            {
                dto = dto.OrderBy(e => e.fault.Solution != null ? e.fault.Solution.DateResolved : e.fault.Order.Created_At).ToList();
            }
            else if ((bool)search_radioButton_status.IsChecked)
            {
                dto = dto.OrderBy(e => e.fault.Order.Status.Name).ToList();
            }

            for (int i = 0; i < dto.Count; i++)
                dto[i].numb = i;

            searchPage_ListBox.Items.Clear();
            for (int i = 0; i < dto.Count; i++)
            {
                searchPage_ListBox.Items.Add(dto[i]);
            }
        }

        private void searchPage_ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (searchPage_ListBox.SelectedItem != null) {
                FaultInfo.fault = ((FaultDTO)searchPage_ListBox.SelectedItem).fault;
                NavigationService.Navigate(new FaultInfo());
            }
        }

        private class FaultDTO
        {
            public Fault fault;
            public int numb;

            public FaultDTO(Fault fault, int numb)
            {
                this.fault = fault ?? throw new ArgumentNullException(nameof(fault));
                this.numb = numb;
            }

            public override string ToString()
            {
                int spacecount = numb.ToString().Length + 3;
                

                return $"{numb+1}. {fault.Order.Created_At} {fault.Order.Status.Name}\n"
                        + $"{new string(' ', spacecount)}{fault.Order.Customer.LastName} {fault.Order.Customer.FirstName} {fault.Order.Customer.Surname}\n"
                        + $"{new string(' ', spacecount)}{fault.Device.Model}";
            }
        }
    }
}
