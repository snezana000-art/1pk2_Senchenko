namespace Task_10_07
{
    

    class Program
    {
        static void Main()
        {
            char[,] charArray = GenerateCharArray(); // генерация массива
            PrintCharArray(charArray); // вывод массива
        }

        //  символьный двумерного массива
        static char[,] GenerateCharArray()
        {
            char[,] array = new char[3, 3];
            char startChar = 'А'; // нач.симв.
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    array[i, j] = startChar++;
                }
            }
            return array;
        }

        // метод вывода массива
        static void PrintCharArray(char[,] array)
        {
            Console.WriteLine("Символьный массив:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
