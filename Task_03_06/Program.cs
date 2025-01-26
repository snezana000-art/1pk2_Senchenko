namespace Task_03_06
{
    internal class Program
    {

        //Написать программу, которая выводит таблицу значений функции: 𝑦=|𝑥|для -4≤x≤4, с шагом h = 0,5







        static void Main()
            {
                // Задаем начальное и конечное значение x
                double startX = -4.0;
                double endX = 4.0;
                double step = 0.5;

                Console.WriteLine("Таблица значений функции y = |x|:");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("   x\t|\ty");
                Console.WriteLine("-----------------------------");

                // Цикл для перебора значений x
                for (double x = startX; x <= endX; x += step)
                {
                    double y = Math.Abs(x); // Вычисляем y = |x|
                    Console.WriteLine($"{x,6:F1}\t|\t{y,6:F1}");
                }
            }
        }
    }


