namespace Task_21_01
{
    internal class Program { }

}
//Дан список чисел. Создать новый список, содержащий только чётные числа из исходного списка, умноженныена10.


class Program
{
    static void Main()
    {
        // Исходный список чисел
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Создаем новый список с четными числами, умноженными на 10
        List<int> evenNumbersMultipliedBy10 = numbers
            .Where(n => n % 2 == 0)  // Фильтруем только четные числа
            .Select(n => n * 10)      // Умножаем каждое на 10
            .ToList();               // Преобразуем в список

        // Выводим результат
        Console.WriteLine("Исходный список: " + string.Join(", ", numbers));
        Console.WriteLine("Результат: " + string.Join(", ", evenNumbersMultipliedBy10));
    }
}