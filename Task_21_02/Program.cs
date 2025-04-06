using System.Text.RegularExpressions;

namespace Task_21_02
{
    internal class Program { }

}
//Дан текст. Написать метод, который возвращает словарь, где ключ — слово, а значение —количествоеговхождений в тексте.


public class WordCounter
{
    public static Dictionary<string, int> CountWords(string text)
    {
        // Удаляем знаки пунктуации и приводим к нижнему регистру
        var cleanedText = Regex.Replace(text, @"[^\w\s]", "").ToLower();

        // Разбиваем текст на слова (разделители - пробелы и переносы строк)
        var words = cleanedText.Split(new[] { ' ', '\n', '\r', '\t' },
                              StringSplitOptions.RemoveEmptyEntries);

        // Создаем и заполняем словарь
        var wordCount = new Dictionary<string, int>();

        foreach (var word in words)
        {
            if (wordCount.ContainsKey(word))
                wordCount[word]++;
            else
                wordCount[word] = 1;
        }

        return wordCount;
    }
}

class Program
{
    static void Main()
    {
        string text = "Hello world! World is beautiful. Hello again.";
        var result = WordCounter.CountWords(text);

        // Выводим результат
        foreach (var pair in result.OrderBy(p => p.Key))
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }
}
