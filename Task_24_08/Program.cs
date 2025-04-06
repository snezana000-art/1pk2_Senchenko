using System.Text;

namespace Task_24_08
{
    internal class Program { }

}
//реализуйте функцию, осуществляющую поиск текста в файле и его замену на значения, введенныепользователем


class TextReplacer
{
    public static void ReplaceTextInFile(string filePath, string searchText, string replaceText)
    {
        try
        {
            // Проверяем существование файла
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл не найден: {filePath}");
                return;
            }

            // Читаем весь текст из файла
            string content = File.ReadAllText(filePath, Encoding.UTF8);

            // Заменяем текст (без учета регистра)
            string newContent = content.Replace(searchText, replaceText, StringComparison.OrdinalIgnoreCase);

            // Если изменения были сделаны
            if (!content.Equals(newContent, StringComparison.Ordinal))
            {
                // Записываем измененный текст обратно в файл
                File.WriteAllText(filePath, newContent, Encoding.UTF8);
                Console.WriteLine($"Успешно заменено '{searchText}' на '{replaceText}' в файле {filePath}");
            }
            else
            {
                Console.WriteLine($"Текст '{searchText}' не найден в файле.");
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Нет доступа к файлу: {filePath}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ошибка ввода-вывода: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
        }
    }

    static void Main()
    {
        Console.WriteLine("=== Программа замены текста в файле ===");

        // Запрос параметров у пользователя
        Console.Write("Введите путь к файлу: ");
        string filePath = Console.ReadLine();

        Console.Write("Введите текст для поиска: ");
        string searchText = Console.ReadLine();

        Console.Write("Введите текст для замены: ");
        string replaceText = Console.ReadLine();

        // Вызов функции замены
        ReplaceTextInFile(filePath, searchText, replaceText);
    }
}
