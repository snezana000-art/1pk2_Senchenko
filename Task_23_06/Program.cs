namespace Task_23_06
{
    internal class Program { }

}
//Напишите программу со следующими функциями:
//1.Выведите информации о всех дисках в системе
//2. Выведите содержимое каталога C:\Users(названия папок)
//3.Создайте на диске D папку “work” и всю дальнейшую работу проводите в ней
//a) Создание вложенного каталога “temp”
//b) Вывод информации о текущем каталоге (имя, родитель и тд)
//c) Вывод информации о вложенном каталоге
//4. Переместите каталог “temp” по пути “D:\work\newTemp”
//a) Реализуйте вывод информационного сообщения об успешном (или нет)
//перемещении
//5. Удалите каталог “D:\work\temp” и выведите сообщение об успешном (или нет)
//удалении.


class FileSystemOperations
{
    static void Main()
    {
        // 1. Вывод информации о всех дисках в системе
        Console.WriteLine("1. Информация о дисках:");
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        foreach (DriveInfo d in allDrives)
        {
            Console.WriteLine($"  Диск {d.Name}");
            Console.WriteLine($"    Тип: {d.DriveType}");
            if (d.IsReady)
            {
                Console.WriteLine($"    Файловая система: {d.DriveFormat}");
                Console.WriteLine($"    Доступно места: {d.AvailableFreeSpace / (1024 * 1024 * 1024)} GB из {d.TotalSize / (1024 * 1024 * 1024)} GB");
            }
            Console.WriteLine();
        }

        // 2. Вывод содержимого каталога C:\Users (названия папок)
        Console.WriteLine("\n2. Содержимое каталога C:\\Users:");
        string usersPath = @"C:\Users";
        if (Directory.Exists(usersPath))
        {
            string[] userDirs = Directory.GetDirectories(usersPath);
            foreach (string dir in userDirs)
            {
                Console.WriteLine($"  {Path.GetFileName(dir)}");
            }
        }
        else
        {
            Console.WriteLine("  Каталог C:\\Users не существует!");
        }

        // 3. Создание папки "work" на диске D и работа с ней
        Console.WriteLine("\n3. Работа с каталогом D:\\work:");
        string workPath = @"D:\work";

        try
        {
            // Создаем папку work, если её нет
            if (!Directory.Exists(workPath))
            {
                Directory.CreateDirectory(workPath);
                Console.WriteLine("  Каталог D:\\work создан");
            }
            else
            {
                Console.WriteLine("  Каталог D:\\work уже существует");
            }

            // 3a. Создаем вложенный каталог "temp"
            string tempPath = Path.Combine(workPath, "temp");
            Directory.CreateDirectory(tempPath);
            Console.WriteLine("  Вложенный каталог temp создан");

            // 3b. Вывод информации о текущем каталоге
            Console.WriteLine("\n3b. Информация о текущем каталоге:");
            DirectoryInfo workDir = new DirectoryInfo(workPath);
            Console.WriteLine($"  Имя: {workDir.Name}");
            Console.WriteLine($"  Полный путь: {workDir.FullName}");
            Console.WriteLine($"  Родительский каталог: {workDir.Parent}");
            Console.WriteLine($"  Время создания: {workDir.CreationTime}");
            Console.WriteLine($"  Атрибуты: {workDir.Attributes}");

            // 3c. Вывод информации о вложенном каталоге
            Console.WriteLine("\n3c. Информация о вложенном каталоге temp:");
            DirectoryInfo tempDir = new DirectoryInfo(tempPath);
            Console.WriteLine($"  Имя: {tempDir.Name}");
            Console.WriteLine($"  Полный путь: {tempDir.FullName}");
            Console.WriteLine($"  Родительский каталог: {tempDir.Parent.Name}");
            Console.WriteLine($"  Время создания: {tempDir.CreationTime}");

            // 4. Перемещение каталога "temp" в "D:\work\newTemp"
            Console.WriteLine("\n4. Перемещение каталога temp:");
            string newTempPath = @"D:\work\newTemp";

            if (Directory.Exists(newTempPath))
            {
                Console.WriteLine("  Ошибка: Каталог D:\\work\\newTemp уже существует!");
            }
            else
            {
                Directory.Move(tempPath, newTempPath);
                Console.WriteLine("  Каталог успешно перемещен в D:\\work\\newTemp");
            }

            // 5. Попытка удаления каталога "D:\work\temp" (которого уже нет)
            Console.WriteLine("\n5. Попытка удаления каталога D:\\work\\temp:");
            if (Directory.Exists(tempPath))
            {
                Directory.Delete(tempPath);
                Console.WriteLine("  Каталог D:\\work\\temp успешно удален");
            }
            else
            {
                Console.WriteLine("  Ошибка: Каталог D:\\work\\temp не существует (уже был перемещен)");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  Ошибка: {ex.Message}");
        }
    }
}