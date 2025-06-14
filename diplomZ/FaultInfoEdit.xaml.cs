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
        }

        private void Button_Click(object sender, RoutedEventArgs e) // назад
        {
            NavigationService.GoBack();
        }
    }
}
