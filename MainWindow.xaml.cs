using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Pavilions
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private int errorsCount = 0;
        private void BtnSingIn_Click(object sender, RoutedEventArgs e)
        {
            var currentAdmin = PavilionEntities.GetContext().Employees_.Where(s => s.Login == TxbLogin.Text & s.Password == TxbPassword.Password && s.RoleId == 1).FirstOrDefault();
            var currentManagerA = PavilionEntities.GetContext().Employees_.Where(u => u.Login == TxbLogin.Text && u.Password == TxbPassword.Password && u.RoleId == 2).FirstOrDefault();
            var currentManagerC = PavilionEntities.GetContext().Employees_.Where(m => m.Login == TxbLogin.Text && m.Password == TxbPassword.Password && m.RoleId == 3).FirstOrDefault();
            if (currentManagerA == null && currentAdmin != null && currentManagerC == null)
            {
                AdminWindow Adminwindow = new AdminWindow();
                Adminwindow.Show();
                Close();
            }
            else if (currentManagerC != null && currentAdmin == null && currentManagerA == null)
            {
                ManagerCWindow managerCWindow = new ManagerCWindow();
                managerCWindow.Show();
                Close();
            }
            else if (currentManagerA != null && currentAdmin == null && currentManagerC == null)
            {
                ManagerAWindow1 managerAWindow1 = new ManagerAWindow1();
                managerAWindow1.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка, попробуйте еще раз");
                errorsCount++;

                if (errorsCount == 3)
                {
                    Captcha captcha = new Captcha();
                    if (captcha.ShowDialog() == true)
                    {
                        errorsCount = 0;

                    }
                }
                return;
            }
        }

        private void TxbLogin_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled |= true;
        }

        private void TxbPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled |= true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

