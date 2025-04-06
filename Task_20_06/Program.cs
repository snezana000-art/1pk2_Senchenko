namespace Task_20_06
{
    internal class Program { }

}
//Создайте программу, имитирующую работу светофора, используя перечисление TrafficLightColor:
//• Red
//• Yellow
//• Green
//Реализуйте автоматическое переключение цветов (каждые 3 секунды).
//При смене цвета выводите его в консоль (можно с задержкой Thread.Sleep).
//Добавьте возможность ручного переключения (например, по нажатию клавиши).


namespace TrafficLightSimulator
{
    // Перечисление цветов светофора
    public enum TrafficLightColor
    {
        Red,
        Yellow,
        Green
    }

    class Program
    {
        private static TrafficLightColor currentColor = TrafficLightColor.Red;
        private static bool isRunning = true;
        private static bool autoMode = true;
        private static readonly object lockObject = new object();

        static void Main(string[] args)
        {
            Console.WriteLine("Симулятор светофора");
            Console.WriteLine("Автоматический режим (переключение каждые 3 секунды)");
            Console.WriteLine("Нажмите:");
            Console.WriteLine("  R - переключить на Красный");
            Console.WriteLine("  Y - переключить на Желтый");
            Console.WriteLine("  G - переключить на Зеленый");
            Console.WriteLine("  A - включить автоматический режим");
            Console.WriteLine("  ESC - выход\n");

            // Запускаем поток для автоматического переключения
            Thread autoSwitchThread = new Thread(AutoSwitchColors);
            autoSwitchThread.Start();

            // Основной цикл обработки ввода пользователя
            while (isRunning)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    HandleKeyPress(key);
                }
            }

            autoSwitchThread.Join();
        }

        // Метод для автоматического переключения цветов
        private static void AutoSwitchColors()
        {
            while (isRunning)
            {
                if (autoMode)
                {
                    lock (lockObject)
                    {
                        // Переключаем цвет в определенном порядке
                        currentColor = currentColor switch
                        {
                            TrafficLightColor.Red => TrafficLightColor.Yellow,
                            TrafficLightColor.Yellow => TrafficLightColor.Green,
                            TrafficLightColor.Green => TrafficLightColor.Red,
                            _ => currentColor
                        };

                        Console.ForegroundColor = GetConsoleColor(currentColor);
                        Console.WriteLine($"Светофор: {currentColor}");
                        Console.ResetColor();
                    }
                }
                Thread.Sleep(3000); // Задержка 3 секунды
            }
        }

        // Обработка нажатий клавиш
        private static void HandleKeyPress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.R:
                    ChangeColorManually(TrafficLightColor.Red);
                    break;
                case ConsoleKey.Y:
                    ChangeColorManually(TrafficLightColor.Yellow);
                    break;
                case ConsoleKey.G:
                    ChangeColorManually(TrafficLightColor.Green);
                    break;
                case ConsoleKey.A:
                    autoMode = true;
                    Console.WriteLine("Включен автоматический режим");
                    break;
                case ConsoleKey.Escape:
                    isRunning = false;
                    Console.WriteLine("Завершение работы...");
                    break;
            }
        }

        // Ручное переключение цвета
        private static void ChangeColorManually(TrafficLightColor newColor)
        {
            lock (lockObject)
            {
                autoMode = false;
                currentColor = newColor;
                Console.ForegroundColor = GetConsoleColor(currentColor);
                Console.WriteLine($"Ручное переключение: {currentColor}");
                Console.ResetColor();
            }
        }

        // Получение цвета консоли для отображения
        private static ConsoleColor GetConsoleColor(TrafficLightColor color)
        {
            return color switch
            {
                TrafficLightColor.Red => ConsoleColor.Red,
                TrafficLightColor.Yellow => ConsoleColor.Yellow,
                TrafficLightColor.Green => ConsoleColor.Green,
                _ => ConsoleColor.White
            };
        }
    }
}
