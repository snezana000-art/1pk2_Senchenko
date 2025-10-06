using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Schooll
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private List<Student> students = new List<Student>();
        private const string DataFileName = "students.json";

        public int StudentsCount => students.Count;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadStudentsFromFile();
            RefreshList();
        }

        // Загрузка данных из файла
        private void LoadStudentsFromFile()
        {
            try
            {
                if (File.Exists(DataFileName))
                {
                    string json = File.ReadAllText(DataFileName);
                    students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
                }
                else
                {
                    LoadSampleData(); // Загрузка тестовых данных если файла нет
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Schooll - Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                LoadSampleData();
            }
        }

        // Сохранение данных в файл
        private void SaveStudentsToFile()
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                string json = JsonSerializer.Serialize(students, options);
                File.WriteAllText(DataFileName, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения данных: {ex.Message}", "Schooll - Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadSampleData()
        {
            students.Add(new Student
            {
                FullName = "Иванов Иван Иванович",
                BirthDate = "15.05.2010",
                Class = "5А",
                ParentName = "Иванова Мария Петровна",
                ParentPhone = "+7-912-345-67-89"
            });

            students.Add(new Student
            {
                FullName = "Петрова Анна Сергеевна",
                BirthDate = "22.08.2011",
                Class = "4Б",
                ParentName = "Петров Сергей Иванович",
                ParentPhone = "+7-923-456-78-90"
            });

            students.Add(new Student
            {
                FullName = "Сидоров Алексей Дмитриевич",
                BirthDate = "03.12.2009",
                Class = "6В",
                ParentName = "Сидорова Елена Викторовна",
                ParentPhone = "+7-934-567-89-01"
            });

            SaveStudentsToFile(); // Сохраняем тестовые данные
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО ученика!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Student student = new Student
            {
                FullName = txtFullName.Text,
                BirthDate = txtBirthDate.Text,
                Class = txtClass.Text,
                ParentName = txtParentName.Text,
                ParentPhone = txtParentPhone.Text
            };

            students.Add(student);

            // Очищаем поля
            txtFullName.Text = "";
            txtBirthDate.Text = "";
            txtClass.Text = "";
            txtParentName.Text = "";
            txtParentPhone.Text = "";

            RefreshList();
            SaveStudentsToFile(); // Сохраняем после добавления
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StudentsCount)));

            MessageBox.Show("Ученик успешно добавлен!", "Schooll - Успех", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RefreshList_Click(object sender, RoutedEventArgs e)
        {
            RefreshList();
        }

        private void RefreshList()
        {
            studentsListView.ItemsSource = null;
            studentsListView.ItemsSource = students;
        }

        private void SearchStudent_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearch.Text;

            if (string.IsNullOrWhiteSpace(searchText) || searchText == "Введите ФИО для поиска...")
            {
                MessageBox.Show("Введите ФИО для поиска!", "Schooll - Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var results = students.Where(s =>
                s.FullName.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();

            searchResultsListView.ItemsSource = results;

            if (results.Count == 0)
            {
                MessageBox.Show("Ученики не найдены!", "Schooll - Результат поиска", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Автосохранение при закрытии окна
        protected override void OnClosed(EventArgs e)
        {
            SaveStudentsToFile();
            base.OnClosed(e);
        }
    }

    public class Student
    {
        public string FullName { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string ParentName { get; set; } = string.Empty;
        public string ParentPhone { get; set; } = string.Empty;
    }
}