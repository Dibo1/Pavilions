using System;
using System.IO;
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
using LoaderImages;
using Microsoft.Win32;

namespace Pavilions
{
    /// <summary>
    /// Логика взаимодействия для AddMall.xaml
    /// </summary>
    public partial class AddMall : Window
    {
        private Malls_ _currentMall = new Malls_();
        public AddMall(Malls_ selectedMall)
        {
            InitializeComponent();

            StatusesComboBox.ItemsSource = PavilionEntities.GetContext().MallStatuses_.ToList();
            CitiesComboBox.ItemsSource = PavilionEntities.GetContext().Cities_.ToList();

            if (selectedMall != null)
            {
                _currentMall = selectedMall;
            }

            DataContext = _currentMall;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentMall.MallId == 0)
            {
                PavilionEntities.GetContext().Malls_.Add(_currentMall);
            }
            try
            {
                PavilionEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ChoosePictureButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Images Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                _currentMall.MallPicture = Loaderimages.LoadPhoto(openFileDialog.FileName);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManagerCWindow managerCWindow = new ManagerCWindow();
            managerCWindow.Show();
            Close();
        }
    }
}
