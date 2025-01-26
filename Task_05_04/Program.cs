namespace Task_05_04
{
    //    Дан квадратный массив размерность n* n.Произведите анализ данной матрицы и выясните является ли данная матрица
    //диагональной (все элементы вне главной диагонали равны нулю)
    //Если матрица является диагональной, то вывести ее повторно с цветовым выделением главной диагонали.Если нет, то вывеси
    //сообщение что матрица не является диагональной.}
    

    public class DiagonalMatrixChecker
    {
        public static void Main(string[] args)
        {
            // Пример матрицы
            int[,] matrix = {
            {1, 0, 0, 0},
            {0, 2, 0, 0},
            {0, 0, 3, 0},
            {0, 0, 0, 4}
        
           
        };

            int n = matrix.GetLength(0); // Размерность матрицы

            // Проверка на диагональность
            bool isDiagonal = IsDiagonal(matrix, n);

            if (isDiagonal)
            {
                Console.WriteLine("Матрица является диагональной:");
                PrintMatrixWithDiagonalHighlight(matrix, n);
            }
            else
            {
                Console.WriteLine("Матрица не является диагональной.");
            }
        }

        // проверка диагональной матрицы
        public static bool IsDiagonal(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j && matrix[i, j] != 0)
                    {
                        return false; 
                    }
                }
            }
            return true; 
        }

        // Функция для вывода матрицы с выделением главной диагонали
        public static void PrintMatrixWithDiagonalHighlight(int[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Выделяем главную диагональ зеленым цветом
                        Console.Write(matrix[i, j] + "\t");
                        Console.ResetColor(); // Сбрасываем цвет
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
}