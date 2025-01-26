namespace Task_05_09
{
    //    Дан квадратный массив размерность n* n.Произведите анализ данной матрицы и выясните является ли данная матрица Z-матрицей
    //(это матрица, где все недиагональные элементы меньше нуля)
    //Если данное условие выполняется то вывести данную матрицу с цветовой индикацией главной диагонали.Если не выполняется, то
    //вывести сообщение что данная матрица не является Z-матрицей
}


public class ZMatrixChecker
{
    public static void Main(string[] args)
    {
        //  Пример матрицы (можно заменить на ввод пользователя)
        int[,] matrix = {
        {5, -1, -2},
        {-3, 6, -4},
        {-5, -6, 7}
        };

        int n = matrix.GetLength(0); // Размерность матрицы

        //  Проверка на Z-матрицу
        bool isZMatrix = IsZMatrix(matrix, n);

        // Вывод результатов
        if (isZMatrix)
        {
            Console.WriteLine("Матрица является Z-матрицей:");
            PrintMatrixWithDiagonalHighlight(matrix, n);
        }
        else
        {
            Console.WriteLine("Матрица не является Z-матрицей.");
        }
    }

    //  Функция для проверки, является ли матрица Z-матрицей
    public static bool IsZMatrix(int[,] matrix, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i != j && matrix[i, j] >= 0)
                {
                    return false; 
                }
            }
        }
        return true; 
    }

    //  Функция для вывода матрицы с выделением главной диагонали
    public static void PrintMatrixWithDiagonalHighlight(int[,] matrix, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                {
                    Console.ForegroundColor = ConsoleColor.Green; 
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