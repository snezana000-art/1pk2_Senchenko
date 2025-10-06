using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolPortal
{
    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            Console.WriteLine("=== ШКОЛЬНЫЙ ПОРТАЛ ===");

            while (true)
            {
                Console.WriteLine("\n1. Добавить ученика");
                Console.WriteLine("2. Показать всех учеников");
                Console.WriteLine("3. Найти ученика");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        ShowAllStudents();
                        break;
                    case "3":
                        FindStudent();
                        break;
                    case "4":
                        Console.WriteLine("До свидания!");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Console.WriteLine("\n--- Добавление ученика ---");

            Student student = new Student();

            Console.Write("ФИО: ");
            student.FullName = Console.ReadLine();

            Console.Write("Дата рождения (дд.мм.гггг): ");
            student.BirthDate = Console.ReadLine();

            Console.Write("Класс: ");
            student.Class = Console.ReadLine();

            Console.Write("ФИО родителя: ");
            student.ParentName = Console.ReadLine();

            Console.Write("Телефон родителя: ");
            student.ParentPhone = Console.ReadLine();

            students.Add(student);
            Console.WriteLine("Ученик добавлен!");
        }

        static void ShowAllStudents()
        {
            Console.WriteLine("\n--- Список всех учеников ---");

            if (students.Count == 0)
            {
                Console.WriteLine("Учеников нет!");
                return;
            }

            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i]}");
            }
        }

        static void FindStudent()
        {
            Console.Write("\nВведите ФИО ученика для поиска: ");
            string searchName = Console.ReadLine();

            var foundStudents = students.Where(s =>
                s.FullName.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList();

            if (foundStudents.Count == 0)
            {
                Console.WriteLine("Ученики не найдены!");
                return;
            }

            Console.WriteLine($"\nНайдено {foundStudents.Count} учеников:");
            foreach (var student in foundStudents)
            {
                Console.WriteLine(student);
            }
        }
    }

    class Student
    {
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public string Class { get; set; }
        public string ParentName { get; set; }
        public string ParentPhone { get; set; }

        public override string ToString()
        {
            return $"{FullName}, {BirthDate}, класс: {Class}, родитель: {ParentName} ({ParentPhone})";
        }
    }
}
