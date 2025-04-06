namespace Task_20_05
{
    internal class Program { }

}
//Напишите программу, имитирующую систему авторизации с использованием перечисления AccessLevel:
//• Guest(только чтение)
//• User(чтение + комментарии)
//• Moderator(удаление контента)
//• Admin(полный доступ)
//Создайте метод, который проверяет, может ли пользователь выполнить действие (например, удалитьпост).На основе уровня доступа выводите сообщение (например,
//"Ошибка: Недостаточно прав!").


namespace AuthorizationSystem
{
    // Перечисление уровней доступа
    public enum AccessLevel
    {
        Guest,      // Только чтение
        User,       // Чтение + комментарии
        Moderator,  // Удаление контента
        Admin       // Полный доступ
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Примеры проверки доступа для разных пользователей
            CheckAccess(AccessLevel.Guest, "delete_post");
            CheckAccess(AccessLevel.User, "add_comment");
            CheckAccess(AccessLevel.Moderator, "delete_post");
            CheckAccess(AccessLevel.Admin, "ban_user");
            CheckAccess(AccessLevel.User, "edit_settings");
        }

        // Метод для проверки прав доступа
        static void CheckAccess(AccessLevel userLevel, string action)
        {
            Console.WriteLine($"Пользователь с уровнем доступа {userLevel} пытается выполнить действие: {action}");

            switch (action)
            {
                case "read_content":
                    Console.WriteLine("Успешно: Чтение разрешено всем!");
                    break;

                case "add_comment":
                    if (userLevel >= AccessLevel.User)
                        Console.WriteLine("Успешно: Комментарий добавлен.");
                    else
                        Console.WriteLine("Ошибка: Недостаточно прав! Требуется уровень User или выше.");
                    break;

                case "delete_post":
                    if (userLevel >= AccessLevel.Moderator)
                        Console.WriteLine("Успешно: Пост удален.");
                    else
                        Console.WriteLine("Ошибка: Недостаточно прав! Требуется уровень Moderator или выше.");
                    break;

                case "edit_settings":
                case "ban_user":
                    if (userLevel == AccessLevel.Admin)
                        Console.WriteLine("Успешно: Действие выполнено (только для Admin).");
                    else
                        Console.WriteLine("Ошибка: Недостаточно прав! Требуется уровень Admin.");
                    break;

                default:
                    Console.WriteLine("Ошибка: Неизвестное действие.");
                    break;
            }

            Console.WriteLine(); // Пустая строка для разделения сообщений
        }
    }
}
