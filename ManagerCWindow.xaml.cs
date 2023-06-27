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
    /// Логика взаимодействия для ManagerCWindow.xaml
    /// </summary>
    public partial class ManagerCWindow : Window
    {
        public ManagerCWindow()
        {
            InitializeComponent();

            var MallsList1 = PavilionEntities.GetContext().Malls_.ToList();
            MallsLV.ItemsSource = MallsList1;

            var StatusesList = PavilionEntities.GetContext().MallStatuses_.ToList();
            StatusesList.Insert(0, new MallStatuses_ { MallStatus = "Все статусы" });

            CBFilter.ItemsSource = StatusesList;
            CBFilter.SelectedIndex = 0;

            var CitiesList = PavilionEntities.GetContext().Cities_.ToList();
            CitiesList.Insert(0, new Cities_ { CityName = "Все города" });

            CBFilterCity.ItemsSource = CitiesList;
            CBFilterCity.SelectedIndex = 0;

            /* MallsLV.ItemsSource = PavilionEntities.GetContext().MallsList.ToList();
             CBFilter.ItemsSource = PavilionEntities.GetContext().MallsList.Select(x => x.MallStatus).ToList();
             CBFilterCity.ItemsSource = PavilionEntities.GetContext().MallsList.Select(x => x.CityName).ToList();*/
        }


        private void CBFilter_DataContextChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentMalls = PavilionEntities.GetContext().Malls_.ToList();

            if (CBFilter.SelectedIndex > 0)
            {
                var selectedStatus = CBFilter.SelectedItem as MallStatuses_;
                currentMalls = currentMalls.Where(m => m.MallStatuses_.MallStatus.ToLower().Contains(selectedStatus.MallStatus.ToLower())).ToList();
            }
            MallsLV.ItemsSource = currentMalls;
        }

        private void CBFilterCity_DataContextChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentMalls = PavilionEntities.GetContext().Malls_.ToList();

            if (CBFilterCity.SelectedIndex > 0)
            {
                var selectedCities = CBFilterCity.SelectedItem as Cities_;
                currentMalls = currentMalls.Where(m => m.Cities_.CityName.ToLower().Contains(selectedCities.CityName.ToLower())).ToList();
            }
            MallsLV.ItemsSource = currentMalls;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddMall addMall = new AddMall(null);
            addMall.Show();
            Close();
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            var MallsToDelete = MallsLV.SelectedItems.Cast<Malls_>().ToList();

            foreach (var m in MallsToDelete)
            {
                m.MallStatusId = 4;
            }

            try
            {
                PavilionEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные удалены");
                MallsLV.ItemsSource = PavilionEntities.GetContext().Cities_.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void PavilionButton_Click(object sender, RoutedEventArgs e)
        {
            Pavilions pavilions = new Pavilions();
            pavilions.Show();
            Close();
        }

        /* private void EditButton_Click(object sender, RoutedEventArgs e)
         {
             NavigationService.Navigate(new AddMallPage((sender as Button).DataContext as Malls));
         }*/
        /* private void CBFilter_DataContextChanged(object sender, SelectionChangedEventArgs e)
         {
             ComboBox comboBox = (ComboBox)sender;
             string selectedValue = comboBox.SelectedItem.ToString();
             MallsLV.ItemsSource = PavilionEntities.GetContext().MallsList.Where(x => x.MallStatus == selectedValue).ToList();
         }

         private void CBFilterCity_DataContextChanged(object sender, SelectionChangedEventArgs e)
         {
             ComboBox comboBox = (ComboBox)sender;
             string selectedValue = comboBox.SelectedItem.ToString();
             MallsLV.ItemsSource = PavilionEntities.GetContext().MallsList.Where(x => x.CityName == selectedValue).ToList();
         }

         private void DelButton_Click(object sender, RoutedEventArgs e)
         {
             var selectPavilion = MallsLV.SelectedItem as MallsList;
             if (selectPavilion != null)
             {
                 var Del = PavilionEntities.GetContext().Malls_.FirstOrDefault(x => x.MallId == selectPavilion.MallId);
                 if (Del != null)
                 {
                     Del.MallStatusId = 4;
                     PavilionEntities.GetContext().SaveChanges();
                     PavilionEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                 }
                 MallsLV.ItemsSource = PavilionEntities.GetContext().MallsList.ToList();
             }
         }

         private void AddButton_Click(object sender, RoutedEventArgs e)
         {
             AddMall addMall = new AddMall();
             addMall.Show();
             Close();
         }*/
    }
}

