using System.Windows;
using System.Windows.Media.Imaging;
using MadkDE.Models;

namespace MadkDE.Views
{
    public partial class MainWindow : Window
    {
        private readonly User _user;

        public MainWindow(User user)
        {
            InitializeComponent();
            _user = user;
            this.Title = "Управление Материалами";
            this.Icon = new BitmapImage(new Uri("pack://application:,,,/Resources/AppIcon.ico"));
            LoadMaterials();
        }

        private void LoadMaterials()
        {
            using var db = new MadkContext();
            var materials = db.Materials.Include(m => m.MaterialType).ToList();
            MaterialsGrid.ItemsSource = materials;
        }

        private void OpenSuppliers_Click(object sender, RoutedEventArgs e)
        {
            var win = new SuppliersWindow();
            win.ShowDialog();
        }

        private void EditMaterial_Click(object sender, RoutedEventArgs e)
        {
            if (_user.Role != "Администратор")
            {
                MessageBox.Show("Доступ запрещён: только для администратора.");
                return;
            }

            var selectedMaterial = MaterialsGrid.SelectedItem as Material;
            if (selectedMaterial != null)
            {
                var editor = new EditMaterialWindow(selectedMaterial);
                editor.ShowDialog();
                LoadMaterials();
            }
            else
            {
                MessageBox.Show("Выберите материал для редактирования.");
            }
        }
    }
}
