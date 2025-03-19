namespace Task_13_02
{


    class Pet
    {
        public string Name; 
        public double Weight; 
        public int Age; 

        
        public Pet(string name, double weight, int age)
        {
            Name = name;
            Weight = weight;
            Age = age;
        }

        public Pet()
        {
            Name = "Неизвестно";
            Weight = 0.0;
            Age = 0;
        }
        public void ShowInfo()
        {
            Console.WriteLine("Кличка: " + Name);
            Console.WriteLine("Вес: " + Weight + " кг");
            Console.WriteLine("Возраст: " + Age + " лет");
        }
        public void ChangeWeight(double newWeight)
        {
            if (newWeight > 0)
            {
                Weight = newWeight;
                Console.WriteLine("Вес изменен на " + Weight + " кг");
            }
            else
            {
                Console.WriteLine("Ошибка: вес должен быть больше нуля!");
            }
        }
        public void ChangeAge(int newAge)
        {
            if (newAge >= 0)
            {
                Age = newAge;
                Console.WriteLine("Возраст изменен на " + Age + " лет");
            }
            else
            {
                Console.WriteLine("Ошибка: возраст не может быть отрицательным!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Pet myPet = new Pet("Тася", 3, 4);


            Console.WriteLine("Информация о питомце:");
            myPet.ShowInfo();


            Console.WriteLine("\nМеняем вес и возраст:");
            myPet.ChangeWeight(5.0);
            myPet.ChangeAge(8); 

            
            Console.WriteLine("\nОбновленная информация о питомце:");
            myPet.ShowInfo();
        }
    }
}
