using System.Linq;
using System.Windows;
using MadkDE.Models;
using Microsoft.EntityFrameworkCore;

namespace MadkDE
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMaterials();
        }

        private void LoadMaterials()
        {
            using var context = new MadkContext();
            MaterialsGrid.ItemsSource = context.Materials
                .Include(m => m.MaterialType)
                .ToList();
        }

        private void OpenSuppliers_Click(object sender, RoutedEventArgs e)
        {
            // Здесь можно открыть новое окно для поставщиков
            MessageBox.Show("Окно поставщиков пока не реализовано.");
        }

        private void AddMaterial_Click(object sender, RoutedEventArgs e)
        {
            var window = new EditMaterialWindow(null)
            {
                Owner = this
            };

            if (window.ShowDialog() == true)
                LoadMaterials();
        }

        private void EditMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialsGrid.SelectedItem is Material selected)
            {
                var window = new EditMaterialWindow(selected)
                {
                    Owner = this
                };

                if (window.ShowDialog() == true)
                    LoadMaterials();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите материал для редактирования.");
            }
        }
    }
}
