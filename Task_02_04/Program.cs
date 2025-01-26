namespace Task_02_04
{
    internal class Program { }
//    Программа эмулирует регистрацию в системе.Пользователь выбирает действие среди доступных:
//1. Зарегистрироваться
//2. Сменить логин
//3. Сменить пароль
//4. Удалить учетку
//В зависимости от выбранного режима произвести соответствующие действия с пользовательскими данными и
//выведите соответствующие сообщения



    class Progra
    {
        static void Main()
        {
            // Ввод данных пользователем
            Console.WriteLine("Введите год рождения:");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите месяц рождения:");
            int month = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите день рождения:");
            int day = int.Parse(Console.ReadLine());

            // Создание объекта DateTime для даты рождения
            DateTime birthDate = new DateTime(year, month, day);

            // Получение текущей даты
            DateTime currentDate = DateTime.Today;

            // Вычисление возраста
            int age = currentDate.Year - birthDate.Year;

            // Проверка, был ли уже день рождения в этом году
            if (birthDate > currentDate.AddYears(-age))
            {
                age--;
            }

            // Проверка совершеннолетия
            if (age >= 18)
            {
                Console.WriteLine("Пользователь совершеннолетний.");
            }
            else
            {
                Console.WriteLine("Пользователь несовершеннолетний.");
            }
        }
    }
}