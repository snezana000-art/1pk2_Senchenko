namespace Task_04_05 { }
//В массиве хранятся сведения о количестве осадков за месяц(30 дней). Необходимо определить общее
//количество осадков, выпавших за каждую декаду месяца, вывести день с самыми сильными осадками за месяц и
//отдельно вывести дни без осадков.Массив с осадками заполнятся с помощью рандома в диапазоне от 0 – нет
//осадков, до 300 мм выпавших осадков.


class Program
{
    static void Main()
    {
        // Генерация массива с осадками за 30 дней
        Random random = new Random();
        int[] precipitation = new int[30];
        for (int i = 0; i < precipitation.Length; i++)
        {
            precipitation[i] = random.Next(0, 301); // От 0 до 300 мм
        }

        // Вычисление общего количества осадков за каждую декаду
        int decade1 = precipitation.Take(10).Sum();
        int decade2 = precipitation.Skip(10).Take(10).Sum();
        int decade3 = precipitation.Skip(20).Take(10).Sum();

        // Нахождение дня с самыми сильными осадками
        int maxPrecipitation = precipitation.Max();
        int maxPrecipitationDay = Array.IndexOf(precipitation, maxPrecipitation) + 1; // +1, так как дни нумеруются с 1

        // Нахождение дней без осадков
        var noPrecipitationDays = precipitation
            .Select((value, index) => new { Value = value, Day = index + 1 })
            .Where(x => x.Value == 0)
            .Select(x => x.Day)
            .ToList();

        // Вывод результатов
        Console.WriteLine("Осадки за месяц: " + string.Join(", ", precipitation));
        Console.WriteLine("Общее количество осадков за первую декаду: " + decade1);
        Console.WriteLine("Общее количество осадков за вторую декаду: " + decade2);
        Console.WriteLine("Общее количество осадков за третью декаду: " + decade3);
        Console.WriteLine("День с самыми сильными осадками: " + maxPrecipitationDay);
        Console.WriteLine("Дни без осадков: " + string.Join(", ", noPrecipitationDays));
    }
}




