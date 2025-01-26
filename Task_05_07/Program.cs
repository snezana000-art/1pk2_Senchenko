namespace Task_05_07
{
    //    У пользователя в консоли запрашивается число n, генерируется квадратный массив целых числе[n * n]. Заполнение случайными
    //числами в диапазоне от 10 до 99 включительно.
    //Найти и вывести отдельно минимальный элемент в матрице(LINQ под запретом) Осуществить умножение матрицы на ее
    //минимальный элемент, при выводе цветом выделить пять максимальных значений в массиве
}


public class MatrixOperations
{
    public static void Main(string[] args)
    {
        // Получение размера матрицы от пользователя
        Console.Write("Введите размер квадратной матрицы (n): ");
        int n = int.Parse(Console.ReadLine());

        //  Создание и заполнение матрицы случайными числами
        int[,] matrix = new int[n, n];
        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = random.Next(10, 100); // Заполнение случайными числами от 10 до 99
            }
        }

        //  Поиск минимального элемента
        int minElement = FindMinElement(matrix, n);
        Console.WriteLine($"\nМинимальный элемент в матрице: {minElement}");

        //  Умножение матрицы на минимальный элемент
        int[,] multipliedMatrix = MultiplyMatrixByScalar(matrix, minElement, n);

        // Вывод преобразованной матрицы с выделением 5 максимальных
        Console.WriteLine("\nПреобразованная матрица с выделением 5 максимальных элементов:");
        PrintMatrixWithMaxHighlight(multipliedMatrix, n);
    }


    //  Функция для поиска минимального элемента в матрице
    public static int FindMinElement(int[,] matrix, int n)
    {
        int min = matrix[0, 0];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }
            }
        }
        return min;
    }

    //  Функция для умножения матрицы на скаляр (минимальный элемент)
    public static int[,] MultiplyMatrixByScalar(int[,] matrix, int scalar, int n)
    {
        int[,] resultMatrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                resultMatrix[i, j] = matrix[i, j] * scalar;
            }
        }
        return resultMatrix;
    }

    // Функция для вывода матрицы с выделением 5 максимальных значений
    public static void PrintMatrixWithMaxHighlight(int[,] matrix, int n)
    {
        //список для хранения всех элементов
        List<int> elements = new List<int>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                elements.Add(matrix[i, j]);
            }
        }

        //сортируем элементы по убыванию
        elements.Sort((x, y) => y.CompareTo(x));

        //берем 5 максимальных значений
        HashSet<int> maxElements = new HashSet<int>(elements.Take(5));


        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (maxElements.Contains(matrix[i, j]))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(matrix[i, j] + "\t");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(matrix[i, j] + "\t");
                }
            }
            Console.WriteLine();
        }
    }
}
