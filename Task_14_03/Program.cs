namespace Task_14_03
{
   

    class MathUtils
    {
        // Статический метод для вычисления факториала
        public static int Factorial(int n)
        {
            // Проверка на отрицательное число
            if (n < 0)
            {
                throw new ArgumentException("Факториал определен только для неотрицательных чисел.");
            }

            // Факториал 0 и 1 равен 1
            if (n == 0 || n == 1)
            {
                return 1;
            }

            // Вычисление факториала
            int result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Примеры использования метода Factorial
                Console.WriteLine("Факториал 0: " + MathUtils.Factorial(0)); // 1
                Console.WriteLine("Факториал 1: " + MathUtils.Factorial(1)); // 1
                Console.WriteLine("Факториал 5: " + MathUtils.Factorial(5)); // 120
                Console.WriteLine("Факториал 10: " + MathUtils.Factorial(10)); // 3628800

                // Попытка вычислить факториал отрицательного числа
                Console.WriteLine("Факториал -3: " + MathUtils.Factorial(-3)); // Ошибка
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }
}
    
