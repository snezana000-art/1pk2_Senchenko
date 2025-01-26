namespace Task_04_06
{

    //    Заполнить массив случайными положительными и отрицательными числами таким образом, чтобы все числа по
    //модулю были разными.Это значит, что в массиве не может быть ни только двух равных чисел, но не может быть
    //двух равных по модулю.В полученном массиве найти наибольшее по модулю число.
    

    class Program
    {
        static void Main()
        {
            // Размер массива
            int size = 20; 
            int[] array = new int[size];

            // Генератор случайных чисел
            Random random = new Random();

            // Множество для хранения уникальных модулей
            HashSet<int> uniqueModuli = new HashSet<int>();

            // Заполнение массива
            for (int i = 0; i < size; i++)
            {
                int number;
                do
                {
                    // Генерация случайного числа 
                    number = random.Next(-200, 201);
                } while (uniqueModuli.Contains(Math.Abs(number))); 

                // Добавление числа в массив и его модуля в множество
                array[i] = number;
                uniqueModuli.Add(Math.Abs(number));
            }

            // Вывод массива
            Console.WriteLine("Сгенерированный массив:");
            Console.WriteLine(string.Join(", ", array));

            // Нахождение наибольшего по модулю числа
            int maxAbsoluteValue = array.Max(x => Math.Abs(x));
            int numberWithMaxAbsoluteValue = array.First(x => Math.Abs(x) == maxAbsoluteValue);

            // Вывод результата
            Console.WriteLine($"Наибольшее по модулю число: {numberWithMaxAbsoluteValue} (модуль: {maxAbsoluteValue})");
        }
    }
}