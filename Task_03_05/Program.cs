namespace Task_03_05
{
    ////    Написать программу, которая выводит на экран таблицу соответствия температуры в градусах Цельсия и
    //Фаренгейта(F = C * 1,8 + 32). Диапазон изменения температуры в градусах Цельсия и шаг должны вводиться во
    //время работы программы






    }





class Program
    {
        static void Main()
        {
            // Ввод начальной температуры
            Console.Write("Введите начальную температуру в градусах Цельсия: ");
            double startTemp = Convert.ToDouble(Console.ReadLine());

            // Ввод конечной температуры
            Console.Write("Введите конечную температуру в градусах Цельсия: ");
            double endTemp = Convert.ToDouble(Console.ReadLine());

            // Ввод шага изменения температуры
            Console.Write("Введите шаг изменения температуры: ");
            double step = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nТаблица соответствия температур:");
            Console.WriteLine("Цельсий\tФаренгейт");
            Console.WriteLine("--------------------");

            // Вывод таблицы
            for (double celsius = startTemp; celsius <= endTemp; celsius += step)
            {
                double fahrenheit = celsius * 1.8 + 32; // Формула перевода Цельсия в Фаренгейт
                Console.WriteLine($"{celsius}\t{fahrenheit:F2}");
            }
        }
    }

