using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace ShoppingList
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> products = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            lstProducts.ItemsSource = products;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProduct.Text))
            {
                products.Add(txtProduct.Text);
                txtProduct.Clear();
                txtProduct.Focus();
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lstProducts.SelectedIndex != -1)
            {
                products.RemoveAt(lstProducts.SelectedIndex);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            products.Clear();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Title = "Сохранить список покупок";

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    File.WriteAllLines(saveFileDialog.FileName, products);
                    MessageBox.Show("Список успешно сохранен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            openFileDialog.Title = "Загрузить список покупок";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string[] loadedProducts = File.ReadAllLines(openFileDialog.FileName);
                    products.Clear();
                    foreach (var product in loadedProducts)
                    {
                        products.Add(product);
                    }
                    MessageBox.Show("Список успешно загружен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}