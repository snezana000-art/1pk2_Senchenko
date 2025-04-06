namespace Task_24_07
{
    internal class Program { }

}
//Реализуйте функцию, которая ищет заданное слово в текстовом файле и возвращает все строки, содержащиеэтослово (регистронезависимо).


class FileWordSearcher
{
    public static List<string> FindLinesWithWord(string filePath, string searchWord)
    {
        var matchingLines = new List<string>();

        try
        {
            // Читаем все строки файла
            var lines = File.ReadAllLines(filePath);

            // Ищем строки, содержащие искомое слово (без учета регистра)
            matchingLines = lines
                .Where(line => line.IndexOf(searchWord, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Файл не найден: {filePath}");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Нет доступа к файлу: {filePath}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }

        return matchingLines;
    }

    static void Main()
    {
        // Пример использования
        string filePath = @"C:\example\text.txt";
        string searchWord = "пример";

        var result = FindLinesWithWord(filePath, searchWord);

        if (result.Count > 0)
        {
            Console.WriteLine($"Найдено {result.Count} строк, содержащих слово '{searchWord}':");
            foreach (var line in result)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine($"Слово '{searchWord}' не найдено в файле.");
        }
    }
}
