namespace Task_10_08
{
    

    class Program
    {
        static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            int index = FindElementIndex(numbers, 3); // индекс элемента
        Console.WriteLine($"Индекс элемента: {index}");
        }

        // метод поиска элемента
        static int FindElementIndex(int[] array, int target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    return i;
                }
            }
            return -1; // элемент не найден
        }
    }
}
