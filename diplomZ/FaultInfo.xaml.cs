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
    /// Логика взаимодействия для FaultInfo.xaml
    /// </summary>
    public partial class FaultInfo : Page
    {
        public static Fault fault;
        public FaultInfo()
        {
            InitializeComponent();
            _FaultInfo_info.Text =
                $"""
                Дата обращения: {fault.Order.Created_At}
                Статус заказа: {fault.Order.Status.Name}
                Имя: {fault.Order.Customer.FirstName}
                Фамилия: {fault.Order.Customer.LastName}
                Отчество: {fault.Order.Customer.Surname}
                Тип устройства: {fault.Device.Name}
                Модель устройства: {fault.Device.Model}
                Описание проблемы: {fault.Description}
                """;

            if (fault.Solution != null)
            {
                _FaultInfo_solution.Text =
                $"""
                Дата окончания ремонта: {fault.Solution?.DateResolved}
                Причина поломки: {fault.Solution.causeFailure}
                Комментарий: {fault.Solution?.Description}
                """;
            }
            else
            {
                _FaultInfo_solution.Text = "Информации о решении нет";
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void _FaultInfo_Button_Edit_Click(object sender, RoutedEventArgs e) // отредактировать
        {
            FaultInfoEdit.fault = fault;
            NavigationService.Navigate(new FaultInfoEdit());
        }
    }
}
