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
using PasswordChecker;

namespace Pavilions
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        private Employees_ _currentEmployee = new Employees_();
        public AddEmployee(Employees_ selectedEmployee)
        {
            InitializeComponent();
            RolesComboBox.ItemsSource = PavilionEntities.GetContext().Roles_.ToList();

            if (selectedEmployee != null)
            {
                _currentEmployee = selectedEmployee;
            }
            DataContext = _currentEmployee;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentEmployee.Surname))
                errors.AppendLine("Вы не ввели фамилию");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Name))
                errors.AppendLine("Вы не ввели имя");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Patronymic))
                errors.AppendLine("Вы не ввели отчество");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Login))
                errors.AppendLine("Вы не ввели логин");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Password))
                errors.AppendLine("Вы не ввели пароль");
            if (_currentEmployee.Password.Length < 8 || _currentEmployee.Password.Length > 20)
                errors.AppendLine("Пароль должен быть от 8 до 20 символов");
            if (string.IsNullOrWhiteSpace(_currentEmployee.Gender))
                errors.AppendLine("Вы не ввели пол");
            if (string.IsNullOrWhiteSpace(_currentEmployee.PhoneNumber))
                errors.AppendLine("Вы не ввели номер телефона");
            if (_currentEmployee.Roles_ == null)
                errors.AppendLine("Вы не выбрали роль");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            try
            {
                if (_currentEmployee.EmployeeId == 0)
                {
                    PavilionEntities.GetContext().Employees_.Add(_currentEmployee);
                }
                PavilionEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SafenessChecker.CheckSafeness(PasswordTextBox.Text) == 1 || SafenessChecker.CheckSafeness(PasswordTextBox.Text) == 0)
            {
                SafenessTextBlock.Text = "Пароль не надежен";
            }
            if (SafenessChecker.CheckSafeness(PasswordTextBox.Text) == 2)
            {
                SafenessTextBlock.Text = "Пароль средней наджености";
            }
            if (SafenessChecker.CheckSafeness(PasswordTextBox.Text) == 3)
            {
                SafenessTextBlock.Text = "Пароль надежный";
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            Close();
        }
    }
}
