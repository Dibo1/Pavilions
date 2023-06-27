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
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {

        private static string GenerateCaptcha()
        {
            const string chars = "abcdefghiklmnopqrstuvwxyzABCDEFGHIKLMNOPQRSTUVWXYZ";

            Random rnd = new Random();
            string randomString = new string(Enumerable.Repeat(chars, 6).Select(s => s[rnd.Next(s.Length)]).ToArray());
            return randomString;
        }

        public Captcha()
        {
            InitializeComponent();
            CatchaLabel.Content = GenerateCaptcha();
        }
        private void CheckCaptcha_Click(object sender, RoutedEventArgs e)
        {
            if (CaptchaTextBox.Text == CatchaLabel.Content.ToString())
            {
                DialogResult = true;
                MessageBox.Show("Успешно");
                this.Close();
            }
            else
            {
                MessageBox.Show("Попробуйте еще раз");
                CatchaLabel.Content = GenerateCaptcha();
            }
        }
    }
}
