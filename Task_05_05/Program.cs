namespace Task_05_05
{
    //    У пользователя в консоли запрашивается числа n и m, генерируется прямоугольный массив целых числе[n * m]. Заполнение
    //случайными числами в диапазоне от -99 до 99 включительно.Осуществите без создания нового массива преобразование текущего
    //по следующему правилу:
    //• Если элемент меньше нуля, то отбрасываем знак и выделяем при выводе зеленым цветом
    //• Если элемент равен нулю, то перезаписываем единицу и выделяем при выводе красным цветом}
    

    public class ArrayTransformation
    {
        public static void Main(string[] args)
        {
            //  Получение размеров массива от пользователя
            Console.Write("Введите количество строк (n): ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов (m): ");
            int m = int.Parse(Console.ReadLine());

            //  Создание и заполнение массива случайными числами
            int[,] array = new int[n, m];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = random.Next(-99, 100); 
                }
            }

            //  Преобразование и вывод массива
            Console.WriteLine("\nПреобразованный массив:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (array[i, j] < 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(Math.Abs(array[i, j]) + "\t"); // Отбрасывание знака и зеленый цвет
                        Console.ResetColor();
                    }
                    else if (array[i, j] == 0)
                    {

                        array[i, j] = 1; 
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(array[i, j] + "\t"); //перезапись 0 на 1 и красный цвет
                        Console.ResetColor();


                    }
                    else
                    {
                        Console.Write(array[i, j] + "\t");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
