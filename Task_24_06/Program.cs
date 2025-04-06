namespace Task_24_06
{
    internal class Program { }


}
//Напишите метод, который принимает путь к файлу и возвращает количество строк в нем. ИспользуйтеStreamReader.


class FileLineCounter
{
    public static int CountLinesInFile(string filePath)
    {
        int lineCount = 0;

        try
        {
            // Используем StreamReader в блоке using для автоматического освобождения ресурсов
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Читаем файл построчно до конца
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Файл не найден: {filePath}");
            return -1; // Возвращаем -1 как индикатор ошибки
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Нет доступа к файлу: {filePath}");
            return -1;
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
            return -1;
        }

        return lineCount;
    }

    static void Main()
    {
        // Пример использования
        string filePath = @"C:\example\test.txt";
        int count = CountLinesInFile(filePath);

        if (count >= 0)
        {
            Console.WriteLine($"Количество строк в файле: {count}");
        }
    }
}
