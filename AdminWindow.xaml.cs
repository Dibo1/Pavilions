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

namespace Pavilions
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            DGridEmployees.ItemsSource = PavilionEntities.GetContext().Employees_.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee(null);
            addEmployee.Show();
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var EmployeesToDelete = DGridEmployees.SelectedItems.Cast<Employees_>().ToList();

            foreach (var emp in EmployeesToDelete)
            {
                emp.RoleId = 4;
            }

            try
            {
                PavilionEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные удалены");
                DGridEmployees.ItemsSource = PavilionEntities.GetContext().Employees_.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchEmpTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var EmployeesList = PavilionEntities.GetContext().Employees_.ToList();

            EmployeesList = EmployeesList.Where(emp => emp.Surname.ToLower().Contains(SearchEmpTextBox.Text.ToLower())).ToList();
            DGridEmployees.ItemsSource = EmployeesList;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee((sender as Button).DataContext as Employees_);
            addEmployee.Show();
            Close();
        }
    }
}
