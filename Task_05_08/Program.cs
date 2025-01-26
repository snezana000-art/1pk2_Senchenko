namespace Task_05_08
{
    //    Даны два массива размером 10*10, заполненные целыми числами в диапазоне от 1 до 9 вкл.Создать новый массив, который будет
    //произведением двух предыдущих(перемножить элементы первых двух массивов, стоящие на одинаковых позициях и записать их в
    //результирующий массив)
    //Вывести результирующий массив
}


public class ArrayProduct
{
    public static void Main(string[] args)
    {
        //  Задаем размеры массивов
        int rows = 10;
        int cols = 10;

        //  Создаем и заполняем первый массив
        int[,] array1 = new int[rows, cols];
        Random random = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array1[i, j] = random.Next(1, 10);
            }
        }

        //  Создаем и заполняем второй массив
        int[,] array2 = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                array2[i, j] = random.Next(1, 10); 
            }
        }

        //  Создаем результирующий массив и заполняем его произведениями
        int[,] resultArray = MultiplyArrays(array1, array2, rows, cols);

        // 5. Вывод результирующего массива на экран
        Console.WriteLine("Результирующий массив (произведение элементов):");
        PrintArray(resultArray, rows, cols);
    }


    //   перемножение элементов двух массивов
    public static int[,] MultiplyArrays(int[,] array1, int[,] array2, int rows, int cols)
    {
        int[,] resultArray = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                resultArray[i, j] = array1[i, j] * array2[i, j];
            }
        }
        return resultArray;
    }
    //  вывод массива на экран
    public static void PrintArray(int[,] array, int rows, int cols)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}