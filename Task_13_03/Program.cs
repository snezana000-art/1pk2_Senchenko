namespace Task_13_03
{

    class Car
    {

        public string Number;
        public string Brand;
        public string Color;
        public int CurrentSpeed;
        public int MaxAllowedSpeed;


        public Car(string number, string brand, string color, int maxAllowedSpeed)
        {
            Number = number;
            Brand = brand;
            Color = color;
            CurrentSpeed = 0;
            MaxAllowedSpeed = maxAllowedSpeed;
        }


        public Car()
        {
            Number = "Неизвестно";
            Brand = "Неизвестно";
            Color = "Неизвестно";
            CurrentSpeed = 0;
            MaxAllowedSpeed = 199;
        }


        public void Drive(int speedIncrease)
        {
            if (speedIncrease > 0)
            {
                CurrentSpeed += speedIncrease;
                Console.WriteLine("Скорость увеличена до " + CurrentSpeed + " км/ч.");
            }
            else
            {
                Console.WriteLine("Ошибка: ускорение должно быть больше нуля.");
            }


            if (CurrentSpeed > MaxAllowedSpeed)
            {
                Console.WriteLine("Скорость превышена! Автомобиль остановлен.");
                CurrentSpeed = 0;
            }
        }


        public void ShowInfo()
        {
            Console.WriteLine("Номер: " + Number);
            Console.WriteLine("Марка: " + Brand);
            Console.WriteLine("Цвет: " + Color);
            Console.WriteLine("Текущая скорость: " + CurrentSpeed + " км/ч");
            Console.WriteLine("Максимально допустимая скорость: " + MaxAllowedSpeed + " км/ч");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Car myCar = new Car("Е777ВХ197", "Mercedes-Benz ", "Белый", 199);


            Console.WriteLine("Информация об автомобиле:");
            myCar.ShowInfo();


            Console.WriteLine("\nЕдем с ускорением:");
            myCar.Drive(90);
            myCar.Drive(100);
            myCar.Drive(90);


            Console.WriteLine("\nОбновленная информация об автомобиле:");
            myCar.ShowInfo();

           
        }
    }
}