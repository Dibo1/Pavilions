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

namespace Pavilions
{
    /// <summary>
    /// Логика взаимодействия для AddPavilion.xaml
    /// </summary>
    public partial class AddPavilion : Window
    {

        private Pavilions_ _currentPavilion = new Pavilions_();

        public AddPavilion(Pavilions_ selectedPavilion)
        {
            InitializeComponent();
            MallsComboBox.ItemsSource = PavilionEntities.GetContext().Malls_.ToList();
            PavilionStatusesComboBox.ItemsSource = PavilionEntities.GetContext().PavilionStatuses_.ToList();

            if (selectedPavilion != null)
            {
                _currentPavilion = selectedPavilion;
            }
            DataContext = _currentPavilion;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            Malls_ currentMall = MallsComboBox.SelectedItem as Malls_;
            int currentPavilionsCount = PavilionEntities.GetContext().Pavilions_.Where(p => p.MallId == currentMall.MallId).Count() + 1;

            if (currentPavilionsCount >= currentMall.PavilionsCount)
                errors.AppendLine("В этом тц больше нет места под павильоны");
            if (_currentPavilion.LevelNumber > currentMall.LevelsCount)
                errors.AppendLine("Вы указали этаж которого нет в ТЦ");
            if (string.IsNullOrWhiteSpace(_currentPavilion.PavilionNumber))
                errors.AppendLine("Вы не ввели номер павильона");
            if (_currentPavilion.Malls_ == null)
                errors.AppendLine("Вы не выбрали ТЦ");
            if (_currentPavilion.PavilionStatuses_ == null)
                errors.AppendLine("Вы не выбрали статус павильона");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentPavilion.PavilionId == 0)
            {
                PavilionEntities.GetContext().Pavilions_.Add(_currentPavilion);
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
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Pavilions pavilions12 = new Pavilions();
            pavilions12.Show();
            Close();
        }
    }
}
