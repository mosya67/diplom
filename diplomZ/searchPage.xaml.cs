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

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
