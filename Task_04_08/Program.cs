namespace Task_04_08 { }
//Дан массив, содержащий последовательность 50 случайных чисел.Найти количество пар элементов, значения
//которых равны


class Program
{
    static void Main()
    {
        // Создаем массив из 50 случайных чисел
        Random random = new Random();
        int[] array = new int[50];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(0, 20); 
        }

        // Выводим массив 
        Console.WriteLine("Массив:");
        Console.WriteLine(string.Join(", ", array));

        // Подсчет количества пар
        int pairCount = 0;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] == array[j])
                {
                    pairCount++;
                }
            }
        }

        // Вывод результата
        Console.WriteLine($"Количество пар элементов с равными значениями: {pairCount}");
    }
}
