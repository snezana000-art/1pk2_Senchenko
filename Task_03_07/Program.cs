namespace Task_03_07
{
//    Написать программу, которая выводит таблицу скорости(через каждые 0,5с) свободно падающего тела v = g t ,
//где 2 g = 9,8 м/с2 – ускорение свободного падения.




class Program
    {
        static void Main()
        {
            // Ускорение свободного падения
            double g = 9.8;

            // Время начала и конца, шаг
            double startTime = 0.0;
            double endTime = 10.0; // Например, 10 секунд
            double step = 0.5;

            Console.WriteLine("Таблица скорости свободно падающего тела:");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(" Время (с)\tСкорость (м/с)");
            Console.WriteLine("----------------------------------------");

            // Цикл для перебора времени
            for (double t = startTime; t <= endTime; t += step)
            {
                double v = g * t; // Вычисление скорости по формуле v = g * t
                Console.WriteLine($"{t,8:F1}\t{v,12:F2}");
            }
        }
    }
}
    
