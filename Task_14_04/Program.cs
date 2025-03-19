namespace Task_14_04 { }

class User
{

    public static User CurrentUser { get; private set; }

    
    public string Username { get; } 
    public int Age { get; } 

    // Конструктор
    public User(string username, int age)
    {
        Username = username;
        Age = age;
    }

   
    public static void SetCurrentUser(User user)
    {
        if (user == null)
        {
            Console.WriteLine("Ошибка: пользователь не может быть пустым.");
            return;
        }

        CurrentUser = user;
        Console.WriteLine($"Текущий пользователь изменен: {user.Username}");
    }

    // Метод для вывода информации о пользователе
    public void DisplayInfo()
    {
        Console.WriteLine($"Имя пользователя: {Username}");
        Console.WriteLine($"Возраст: {Age} лет");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем пользователей
        User user1 = new User("Снежана", 16);
        User user2 = new User("Наташа", 16);

        // Устанавливаем текущего пользователя
        User.SetCurrentUser(user1);

        // Выводим информацию о текущем пользователе
        Console.WriteLine("\nИнформация о текущем пользователе:");
        if (User.CurrentUser != null)
        {
            User.CurrentUser.DisplayInfo();
        }

        // Меняем текущего пользователя
        User.SetCurrentUser(user2);

        // Выводим информацию о новом текущем пользователе
        Console.WriteLine("\nИнформация о текущем пользователе:");
        if (User.CurrentUser != null)
        {
            User.CurrentUser.DisplayInfo();
        }

        // Попытка установить текущего пользователя как null
        User.SetCurrentUser(null);
    }
} 
