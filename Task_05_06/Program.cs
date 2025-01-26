namespace Task_05_06
{ }
//    Осуществить генерация двумерного[10 * 5] массива по следующему правилу:
//• 1 столбец содержит нули
//• 2 столбце содержит числа кратные 2
//• 3 столбец содержит числа кратные 3
//• 4 столбец содержит числа кратные 4
//• 5 столбец содержит числа кратные 5
//


public class ArrayGenerator
{
    public static void Main(string[] args)
    {
        //  Задаем размеры массива
        int rows = 10;
        int cols = 5;

        //  Создаем двумерный массив
        int[,] array = new int[rows, cols];

        //  Заполняем массив по правилам
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (j == 0)
                {
                    array[i, j] = 0; 
                }
                else if (j == 1)
                {
                    array[i, j] = (i + 1) * 2; 
                }
                else if (j == 2)
                {
                    array[i, j] = (i + 1) * 3; 
                }
                else if (j == 3)
                {
                    array[i, j] = (i + 1) * 4; 
                }
                else
                {
                    array[i, j] = (i + 1) * 5; 
                }
            }
        }

        //  Выводbv массив на экран
        Console.WriteLine("Сгенерированный массив:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(array[i, j] + "\t"); // Вывод элементов 
            }
            Console.WriteLine();
        }
    }
}

