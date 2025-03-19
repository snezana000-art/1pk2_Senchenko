namespace Task_10_06
{
   

    class Program
    {
        static void Main()
        {
            ArrayGeneration(5); // пример         
        }

        // генерация и вывод
        static void ArrayGeneration(int n)
        {
            int[] array = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = rand.Next(100); //  от 0 до 99
            }
            Console.WriteLine("Сгенерированный массив:");
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
