using System.Xml.Linq;

namespace Task_03_04
{
//    Пользователь вводить в консоли произвольный текст.После каждого ввода консоль очищается. Когда
//пользователь вводить слово «exit» или пустую строку – ввод останавливается и выводиться количество строк
//введенных пользователем.

}






class Program
{
    static void Main()
    {
        int lineCount = 0;
        string input;

        while (true)
        {
            Console.WriteLine("Введите текст (или 'exit' для завершения):");
            input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
            {
                break;
            }

            lineCount++;
            Console.Clear(); // Очистка консоли после каждого ввода
        }

        Console.WriteLine($"Количество введенных строк: {lineCount}");
    }
}