namespace Task_32_01 { }


public abstract class Animal
{
    public string Name { get; }
    protected Animal(string name) => Name = name;
    public abstract bool CanEat(Kolobok kolobok);
}

public class Obstacle
{
    public string Name { get; }
    public int SpeedPenalty { get; }

    public Obstacle(string name, int speedPenalty)
    {
        Name = name;
        SpeedPenalty = speedPenalty;
    }
}

public class Kolobok
{
    public int Position { get; private set; }
    public int Speed { get; private set; }
    public bool IsAlive { get; private set; }
    private int _initialSpeed;

    public Kolobok()
    {
        Position = 0;
        Speed = 1;
        _initialSpeed = Speed;
        IsAlive = true;
    }

    public void Roll()
    {
        Position += Speed;
        Console.WriteLine($"Колобок катится, текущая позиция: {Position}, скорость: {Speed}");
    }

    public void MeetAnimal(Animal animal)
    {
        if (animal.CanEat(this))
        {
            IsAlive = false;
            Console.WriteLine($"Колобок был съеден {animal.Name}!");
        }
        else
        {
            Console.WriteLine($"Колобок убежал от {animal.Name}!");
        }
    }

    public void MeetObstacle(Obstacle obstacle)
    {
        Speed = Math.Max(0, Speed - obstacle.SpeedPenalty);
        Console.WriteLine($"Колобок встретил {obstacle.Name} и замедлился на {obstacle.SpeedPenalty}. Текущая скорость: {Speed}");
    }

    public void RestoreSpeed()
    {
        Speed = _initialSpeed;
        Console.WriteLine($"Колобок восстановил скорость: {Speed}");
    }
}

// Примеры животных
public class Hare : Animal { public Hare() : base("Заяц") { } public override bool CanEat(Kolobok kolobok) => false; }
public class Wolf : Animal { public Wolf() : base("Волк") { } public override bool CanEat(Kolobok kolobok) => false; }
public class Bear : Animal { public Bear() : base("Медведь") { } public override bool CanEat(Kolobok kolobok) => false; }
public class Fox : Animal { public Fox() : base("Лиса") { } public override bool CanEat(Kolobok kolobok) => true; }

// Примеры препятствий
public class Mud : Obstacle { public Mud() : base("Грязь", 1) { } }
public class Stone : Obstacle { public Stone() : base("Камень", 2) { } }
public class Fence : Obstacle { public Fence() : base("Забор", 3) { } }

class Program
{
    static void Main(string[] args)
    {
        Kolobok kolobok = new Kolobok();
        List<object> obstacles = new List<object>
        {
            new Hare(),
            new Mud(),
            new Wolf(),
            new Stone(),
            new Bear(),
            new Fence(),
            new Fox()
        };

        foreach (var obstacle in obstacles)
        {
            if (!kolobok.IsAlive) break;

            kolobok.Roll();

            if (obstacle is Animal animal)
            {
                kolobok.MeetAnimal(animal);
            }
            else if (obstacle is Obstacle obs)
            {
                kolobok.MeetObstacle(obs);
            }

            // Восстановление скорости после каждого препятствия
            kolobok.RestoreSpeed();
        }

        Console.WriteLine(kolobok.IsAlive
            ? "Колобок сбежал и стал Senior .NET-разработчиком!"
            : "Game Over. Колобок не выжил в этом жестоком ООП-мире.");
    }
}

