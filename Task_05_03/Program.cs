namespace Task_05_03
{
    //    Даны два массива, заполненные символами английского алфавита размером 3*3. Проверить, являются ли матрицы равными, если
    //да, то вывести сообщение о том, что они равны, если нет, то вывести повторно матрицы с цветовой индикацией только тех
    //элементов, которые равны. (матрицы считаются равными, если их соответствующие элементы равны.}
    

    public class MatrixEquality
    {
        public static void Main(string[] args)
        {
            // Инициализация массивов 
            char[,] matrix1 = {
            {'f', 'h', 'h'},
            {'w', 'g', 'k'},
            {'a', 'f', 'j'}
        };

            char[,] matrix2 = {
            {'f', 'c', 'h'},
            {'m', 'g', 'z'},
            {'a', 'o', 'd'}
        };

            // Проверка на равенство матриц
            bool isEqual = AreMatricesEqual(matrix1, matrix2);

            if (isEqual)
            {
                Console.WriteLine("Матрицы равны.");
            }
            else
            {
                Console.WriteLine("Матрицы не равны. Вывод с цветовой индикацией:");
                PrintMatricesWithColor(matrix1, matrix2);
            }
        }

        // проверкa равенства матриц
        public static bool AreMatricesEqual(char[,] matrix1, char[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);
            int rows2 = matrix2.GetLength(0);
            int cols2 = matrix2.GetLength(1);

            if (rows1 != rows2 || cols1 != cols2)
                return false;

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols1; j++)
                {
                    if (matrix1[i, j] != matrix2[i, j])
                        return false;
                }
            }
            return true;
        }

        // вывод матриц с цветовой индикацией
        public static void PrintMatricesWithColor(char[,] matrix1, char[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);

            Console.WriteLine("Матрица 1:        Матрица 2:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix1[i, j] == matrix2[i, j])
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Зеленый цвет для равных элементов
                        Console.Write(matrix1[i, j] + " ");
                        Console.ResetColor(); // Возврат к стандартному цвету
                    }
                    else
                    {
                        Console.Write(matrix1[i, j] + " ");
                    }
                }
                Console.Write("     ");
                for (int j = 0; j < cols; j++)
                {
                    if (matrix1[i, j] == matrix2[i, j])
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Зеленый цвет для равных элементов
                        Console.Write(matrix2[i, j] + " ");
                        Console.ResetColor(); // Возврат к стандартному цвету
                    }
                    else
                    {
                        Console.Write(matrix2[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
