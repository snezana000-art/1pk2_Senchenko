// MainWindow.xaml.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace StudentRecords
{
    public partial class MainWindow : Window
    {
        private List<Student> students = new List<Student>();
        private const string DataFilePath = "students.json";

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
            UpdateStudentList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                dpBirthDate.SelectedDate == null)
            {
                MessageBox.Show("Заполните обязательные поля (Фамилия, Имя, Дата рождения)");
                return;
            }

            var student = new Student
            {
                LastName = txtLastName.Text,
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                Group = txtGroup.Text,
                Gender = (cmbGender.SelectedItem as ComboBoxItem)?.Content.ToString(),
                BirthDate = dpBirthDate.SelectedDate.Value
            };

            students.Add(student);
            UpdateStudentList();
            ClearFields();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstStudents.SelectedIndex != -1)
            {
                students.RemoveAt(lstStudents.SelectedIndex);
                UpdateStudentList();
            }
        }

        private void UpdateStudentList()
        {
            lstStudents.Items.Clear();
            foreach (var student in students)
            {
                lstStudents.Items.Add($"{student.LastName} {student.FirstName} {student.MiddleName}, {student.Group}");
            }
        }

        private void ClearFields()
        {
            txtLastName.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtGroup.Clear();
            cmbGender.SelectedIndex = -1;
            dpBirthDate.SelectedDate = null;
        }

        private void LoadData()
        {
            if (File.Exists(DataFilePath))
            {
                try
                {
                    string jsonString = File.ReadAllText(DataFilePath);
                    students = JsonSerializer.Deserialize<List<Student>>(jsonString) ?? new List<Student>();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
                }
            }
        }

        private void SaveData()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(students, options);
                File.WriteAllText(DataFilePath, jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveData();
        }
    }

    public class Student
    {
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Group { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}