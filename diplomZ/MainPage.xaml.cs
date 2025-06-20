﻿using Database;
using Database.Db;
using Database.dto;
using Database.GetFunc;
using Database.model;
using Database.WriteFunc;
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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        IGetFunc<List<Fault>, SearchFilterDTO> getFaults;
        IWriteFunc<Order> addOrder;
        IWriteFunc<Fault> addFault;
        Context context = new Context();
        public MainPage()
        {
            InitializeComponent();

            if (context.Statuses.Count() == 0)
            {
                context.Statuses.Add(new Status { Name = "В работе"});
                context.Statuses.Add(new Status { Name = "Готово" });
                context.SaveChanges();
            }

            var devices = context.Devices;
            var deviceGroup = devices.Select(e => e.Name).Distinct().ToList();
            var modelGroup = devices.Select(e => e.Model).Distinct().ToList();
            _newOrder_ComboBox_device.ItemsSource = deviceGroup;
            _newOrder_ComboBox_model.ItemsSource = modelGroup;

            getFaults = new GetFaults(context);
            addFault = new AddFault(context);
            addOrder = new AddOrder(context, addFault);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // оформить заказ
        {
            bool flag = false;
            if (string.IsNullOrEmpty(_newOrder_name.Text))
            {
                flag = true;
                newOrder_errorName.Text = "* обязательное поле";
            }
            if (string.IsNullOrEmpty(_newOrder_about.Text))
            {
                flag = true;
                newOrder_errorAbout.Text = "* обязательное поле";
            }

            if (flag) return;

            Order o = new Order();
            o.Created_At = DateTime.Now;
            o.Customer = new Customer
            {
                FirstName = _newOrder_name.Text,
                LastName = _newOrder_lastName.Text,
                Surname = _newOrder_surname.Text,
            };
            o.Fault = new Fault
            {
                Description = _newOrder_about.Text,
                Order = o,
                Device = new Device
                {
                    Model = _newOrder_model.Text,
                    Name = _newOrder_device.Text,
                }
            };

            addOrder.Write(o);

            ClearAddOrder();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // очистить поиск
        {
            _search_createDateFirst.Text = null;
            _search_createDateLast.Text = null;
            _search_device.Text = null;
            _search_name.Text = null;
            _search_lastName.Text = null;
            _search_surname.Text = null;
            _search_model.Text = null;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // поиск
        {
            SearchFilterDTO filter = new SearchFilterDTO();
            if (!string.IsNullOrEmpty(_search_createDateFirst.Text)) filter.createDateFirst = DateTime.Parse(_search_createDateFirst.Text);
            if (!string.IsNullOrEmpty(_search_createDateLast.Text)) filter.createDateLast = DateTime.Parse(_search_createDateLast.Text);
            filter.device = new() { Name = _search_device.Text, Model = _search_model.Text };
            filter.firstName = _search_name.Text;
            filter.lastName = _search_lastName.Text;
            filter.surname = _search_surname.Text;

            var results = getFaults.Get(filter);
            searchPage.faults = results;

            NavigationService.Navigate(new searchPage());
        }

        private void ClearAddOrder() // очистка
        {
            _newOrder_name.Text = null;
            _newOrder_lastName.Text = null;
            _newOrder_surname.Text = null;
            _newOrder_about.Text = null;
            _newOrder_model.Text = null;
            _newOrder_device.Text = null;

            newOrder_errorName.Text = "";
            newOrder_errorAbout.Text = "";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_newOrder_ComboBox_device.SelectedItem is string selectedItem)
            {
                _newOrder_device.Text = selectedItem;
                _newOrder_ComboBox_device.SelectionChanged -= ComboBox_SelectionChanged;
                _newOrder_ComboBox_device.SelectedIndex = -1;
                _newOrder_ComboBox_device.SelectionChanged += ComboBox_SelectionChanged;
            }
        }

        private void _newOrder_ComboBox_model_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_newOrder_ComboBox_model.SelectedItem is string selectedItem)
            {
                _newOrder_model.Text = selectedItem;
                _newOrder_ComboBox_model.SelectionChanged -= _newOrder_ComboBox_model_SelectionChanged;
                _newOrder_ComboBox_model.SelectedIndex = -1;
                _newOrder_ComboBox_model.SelectionChanged += _newOrder_ComboBox_model_SelectionChanged;
            }
        }

        private void _search_ComboBox_device_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_search_ComboBox_device.SelectedItem is string selectedItem)
            {
                _search_device.Text = selectedItem;
                _search_ComboBox_device.SelectionChanged -= _search_ComboBox_device_SelectionChanged;
                _search_ComboBox_device.SelectedIndex = -1;
                _search_ComboBox_device.SelectionChanged += _search_ComboBox_device_SelectionChanged;
            }
        }

        private void _search_ComboBox_model_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_search_ComboBox_model.SelectedItem is string selectedItem)
            {
                _search_model.Text = selectedItem;
                _search_ComboBox_model.SelectionChanged -= _search_ComboBox_model_SelectionChanged;
                _search_ComboBox_model.SelectedIndex = -1;
                _search_ComboBox_model.SelectionChanged += _search_ComboBox_model_SelectionChanged;
            }
        }

        private void _newOrder_ComboBox_device_DropDownOpened(object sender, EventArgs e) // device
        {
            var devices = context.Devices;
            if (!string.IsNullOrEmpty(_newOrder_device.Text))
            {
                var a = devices.Where(e => e.Name.Contains(_newOrder_device.Text)).Select(e => e.Name).Distinct().ToList();
                _newOrder_ComboBox_device.ItemsSource = a;
            }
            else
            {
                var a = devices.Select(e => e.Name).Distinct().ToList();
                _newOrder_ComboBox_device.ItemsSource = a;
            }
        }
        
        private void _newOrder_ComboBox_model_DropDownOpened(object sender, EventArgs e) // model
        {
            var devices = context.Devices;
            if (!string.IsNullOrEmpty(_newOrder_model.Text))
            {
                var a = devices.Where(e => e.Model.Contains(_newOrder_model.Text) && !string.IsNullOrEmpty(_newOrder_device.Text) ? e.Name == _newOrder_device.Text : true).Select(e => e.Model).Distinct().ToList();
                _newOrder_ComboBox_model.ItemsSource = a;
            }
            else
            {
                var a = devices.Where(e => !string.IsNullOrEmpty(_newOrder_device.Text) ? e.Name == _newOrder_device.Text : true).Select(e => e.Model).Distinct().ToList();
                _newOrder_ComboBox_model.ItemsSource = a;
            }
        }

        private void _search_ComboBox_device_DropDownOpened(object sender, EventArgs e) // device
        {
            var devices = context.Devices;
            if (!string.IsNullOrEmpty(_search_device.Text))
            {
                var a = devices.Where(e => e.Name.Contains(_search_device.Text)).Select(e => e.Name).Distinct().ToList();
                _search_ComboBox_device.ItemsSource = a;
            }
            else
            {
                var a = devices.Select(e => e.Name).Distinct().ToList();
                _search_ComboBox_device.ItemsSource = a;
            }
        }

        private void _search_ComboBox_model_DropDownOpened(object sender, EventArgs e) // model
        {
            var devices = context.Devices;
            if (!string.IsNullOrEmpty(_search_model.Text))
            {
                var a = devices.Where(e => e.Model.Contains(_search_model.Text) && !string.IsNullOrEmpty(_search_device.Text) ? e.Name == _search_device.Text : true).Select(e => e.Model).Distinct().ToList();
                _search_ComboBox_model.ItemsSource = a;
            }
            else
            {
                var a = devices.Where(e => !string.IsNullOrEmpty(_search_device.Text) ? e.Name == _search_device.Text : true).Select(e => e.Model).Distinct().ToList();
                _search_ComboBox_model.ItemsSource = a;
            }
        }

        private void _button_clearNewOrder_Click(object sender, RoutedEventArgs e)
        {
            ClearAddOrder();
        }
    }
}
