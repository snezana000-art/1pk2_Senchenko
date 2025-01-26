namespace Task_04_10
{ }
//    Заполнить массив из 10 элементов случайными числами в интервале[-10..10] и сделать реверс элементов
//отдельно для 1-ой и 2-ой половин массива.Реверс реализовать через цикл.Стандартные методы класса Array
//использовать нельзя.
//Например, исходный массив: [5, 2, -10, 0, 4, -6, 7, 2, 9, -7]
//Результат: [4, 0, -10, 2, 5, -7, 9, 2, 7, -6]}


class Program
{
    static void Main()
    {
        // Создаем массив из 10 элементов
        int[] array = new int[10];
        Random random = new Random();

        // Заполняем массив случайными числами 
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-10, 11);
        }

        // Выводим исходный массив
        Console.WriteLine("Исходный массив:");
        Console.WriteLine(string.Join(", ", array));

        
        for (int i = 0; i < array.Length / 4; i++)
        {
            int temp = array[i];
            array[i] = array[array.Length / 2 - 1 - i];
            array[array.Length / 2 - 1 - i] = temp;
        }

        
        for (int i = array.Length / 2; i < array.Length / 2 + array.Length / 4; i++)
        {
            int temp = array[i];
            array[i] = array[array.Length - 1 - (i - array.Length / 2)];
            array[array.Length - 1 - (i - array.Length / 2)] = temp;
        }

        // Выводим результат
        Console.WriteLine("Массив после реверса половин:");
        Console.WriteLine(string.Join(", ", array));
    }
}
