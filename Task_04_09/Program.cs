namespace Task_04_09
{
    //В массиве найти элементы, которые в нем встречаются только один раз, и вывести их на экран.То есть найти и
    //вывести уникальные элементы массива. (LINQ использовать нельзя)

    class Program
    {
        static void Main()
        {
            // Создаем массив с данными
            int[] array = { 1, 2, 3, 4, 5, 2, 3, 6, 7, 8, 1, 9, 10 };

            // Выводим  массив
            Console.WriteLine("Исходный массив:");
            Console.WriteLine(string.Join(", ", array));

            
            Dictionary<int, int> countMap = new Dictionary<int, int>();

            // Подсчет количества вхождений каждого элемента
            foreach (int num in array)
            {
                if (countMap.ContainsKey(num))
                {
                    countMap[num]++;
                }
                else
                {
                    countMap[num] = 1;
                }
            }

            // Выводим элементы, которые встречаются один раз
            Console.WriteLine("Уникальные элементы:");
            foreach (var entry in countMap)
            {
                if (entry.Value == 1)
                {
                    Console.Write(entry.Key + " ");
                }
            }
        }
    }
}
