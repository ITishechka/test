using System;
using System.Linq;
using System.Windows;
using MadkDE.Models;

namespace MadkDE
{
    public partial class EditMaterialWindow : Window
    {
        private readonly Material _material;
        private readonly bool _isEdit;

        public EditMaterialWindow(Material material)
        {
            InitializeComponent();

            _isEdit = material != null;

            using var context = new MadkContext();
            TypeBox.ItemsSource = context.MaterialTypes.ToList();

            if (_isEdit)
            {
                _material = context.Materials.First(m => m.MaterialId == material.MaterialId);
                Title = "Редактирование материала";

                NameBox.Text = _material.Name;
                TypeBox.SelectedValue = _material.MaterialTypeId;
                PriceBox.Text = _material.UnitPrice.ToString();
                StockBox.Text = _material.QuantityInStock.ToString();
                MinQtyBox.Text = _material.MinQuantity.ToString();
                PackQtyBox.Text = _material.QuantityPerPackage?.ToString() ?? "";
                UnitBox.Text = _material.Unit;
            }
            else
            {
                _material = new Material();
                Title = "Добавление материала";
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(PriceBox.Text, out var price) ||
                !decimal.TryParse(StockBox.Text, out var stock) ||
                !decimal.TryParse(MinQtyBox.Text, out var minQty))
            {
                MessageBox.Show("Проверьте правильность введенных числовых значений.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            decimal? qtyPerPack = null;
            if (!string.IsNullOrWhiteSpace(PackQtyBox.Text))
            {
                if (decimal.TryParse(PackQtyBox.Text, out var val))
                    qtyPerPack = val;
                else
                {
                    MessageBox.Show("Неверный формат упаковки.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }

            if (string.IsNullOrWhiteSpace(NameBox.Text) || TypeBox.SelectedValue == null || string.IsNullOrWhiteSpace(UnitBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _material.Name = NameBox.Text;
            _material.MaterialTypeId = (int)TypeBox.SelectedValue;
            _material.UnitPrice = price;
            _material.QuantityInStock = stock;
            _material.MinQuantity = minQty;
            _material.QuantityPerPackage = qtyPerPack;
            _material.Unit = UnitBox.Text;

            using var context = new MadkContext();
            if (_isEdit)
            {
                context.Materials.Update(_material);
            }
            else
            {
                context.Materials.Add(_material);
            }

            context.SaveChanges();
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
