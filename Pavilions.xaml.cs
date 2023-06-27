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
    /// Логика взаимодействия для Pavilions.xaml
    /// </summary>
    public partial class Pavilions : Window
    {
        public Pavilions()
        {
            InitializeComponent();

            DGridPavilions.ItemsSource = PavilionEntities.GetContext().Pavilions_.ToList();

            var MallsList = PavilionEntities.GetContext().Malls_.ToList();
            MallsList.Insert(0, new Malls_ { MallName = "Все ТЦ" });

            MallsComboBox.ItemsSource = MallsList;
        }

        private void MallsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var currentPavilions = PavilionEntities.GetContext().Pavilions_.ToList();

            if (MallsComboBox.SelectedIndex > 0)
            {
                var selectedMall = MallsComboBox.SelectedItem as Malls_;
                currentPavilions = currentPavilions.Where(m => m.Malls_.MallName.ToLower().Contains(selectedMall.MallName.ToLower())).ToList();
            }
            DGridPavilions.ItemsSource = currentPavilions;
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            var PavilionsToDelete = DGridPavilions.SelectedItems.Cast<Pavilions_>().ToList();

            foreach (var p in PavilionsToDelete)
            {
                p.PavilionStatusId = 3;
            }

            try
            {
                PavilionEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные удалены");
                DGridPavilions.ItemsSource = PavilionEntities.GetContext().Pavilions_.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddPavilion addPavilion = new AddPavilion(null);
            addPavilion.Show();
            Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            AddPavilion addPavilion = new AddPavilion((sender as Button).DataContext as Pavilions_);
            addPavilion.Show();
            Close();
        }

        
    }
}
