using System.Diagnostics;

namespace Task_20_04
{
    internal class Program { }
}
//        Создайте программу для учета транспортных средств.Используйте перечисление VehicleType:
//• Car
//• Bike
//• Bus
//• Truck
//• Motorcycle
//Храните список транспортных средств (можно просто List<VehicleType>).
//Добавьте метод для подсчёта транспорта определённого типа(например, сколько грузовиков).
//Реализуйте поиск по типу и вывод информации


namespace VehicleInventory
{
    // Перечисление типов транспортных средств
    public enum VehicleType
    {
        Car,        // Легковой автомобиль
        Bike,       // Велосипед
        Bus,        // Автобус
        Truck,      // Грузовик
        Motorcycle  // Мотоцикл
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаём список транспортных средств
            List<VehicleType> vehicles = new List<VehicleType>();

            // Добавляем несколько транспортных средств
            vehicles.Add(VehicleType.Car);
            vehicles.Add(VehicleType.Bike);
            vehicles.Add(VehicleType.Truck);
            vehicles.Add(VehicleType.Car);
            vehicles.Add(VehicleType.Bus);
            vehicles.Add(VehicleType.Motorcycle);
            vehicles.Add(VehicleType.Truck);
            vehicles.Add(VehicleType.Car);

            // Выводим весь список
            Console.WriteLine("Все транспортные средства:");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
            Console.WriteLine();

            // Подсчитываем количество грузовиков
            int truckCount = CountVehicles(vehicles, VehicleType.Truck);
            Console.WriteLine($"Количество грузовиков: {truckCount}");

            // Ищем все автомобили и выводим их
            Console.WriteLine("\nВсе автомобили (Car):");
            var cars = FindVehicles(vehicles, VehicleType.Car);
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        // Метод для подсчёта транспорта определённого типа
        static int CountVehicles(List<VehicleType> vehicles, VehicleType type)
        {
            return vehicles.Count(v => v == type);
        }

        // Метод для поиска транспорта по типу
        static List<VehicleType> FindVehicles(List<VehicleType> vehicles, VehicleType type)
        {
            return vehicles.Where(v => v == type).ToList();
        }
    }
}
