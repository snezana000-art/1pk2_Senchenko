namespace Task_04_07
{
    //    В массиве на 30 элементов содержатся данные по росту учеников в классе.Рост мальчиков условно задан
    //отрицательными значениями.Вычислить и вывести количество мальчиков и девочек в классе и средний рост для
    //мальчиков и девочек. При выводе избавиться от отрицательных значений.}
    

    class Program
    {
        static void Main()
        {
            // Создаем массив  с ростом учеников
            int[] heights = { 160, -170, 155, -180, 165, -175, 150, -165, 168, -172,
                          158, -178, 162, -168, 157, -173, 163, -167, 159, -176,
                          161, -169, 164, -174, 166, -171, 152, -177, 153, -179 };

            // Подсчет количества мальчиков и девочек
            int boysCount = heights.Count(h => h < 0);
            int girlsCount = heights.Length - boysCount;

            // Вычисление среднего роста для мальчиков и девочек
            double boysAverageHeight = heights.Where(h => h < 0).Average(h => Math.Abs(h));
            double girlsAverageHeight = heights.Where(h => h >= 0).Average(h => h);

            // Вывод результатов
            Console.WriteLine($"Количество мальчиков: {boysCount}");
            Console.WriteLine($"Количество девочек: {girlsCount}");
            Console.WriteLine($"Средний рост мальчиков: {boysAverageHeight:F2} см");
            Console.WriteLine($"Средний рост девочек: {girlsAverageHeight:F2} см");
        }
    }
}