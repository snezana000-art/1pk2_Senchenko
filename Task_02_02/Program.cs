namespace Task_02_02 { }
internal class Program {

public class MathCalculations
{
    public static void Main(string[] args)
    {
     

        
        double a2 = 8;
        double b2 = 14;
        double c2 = Math.PI / 4;
        double result2 = CalculateExpression2(a2, b2, c2);
        Console.WriteLine($"Результат выражения 2: {result2}");

        
    }


    

    }


    
    public static double CalculateExpression2(double a, double b, double c)
    {
        double sqrtB = Math.Sqrt(b);
        double cuberootA = Math.Pow(a, 1.0 / 3.0);
        double sinSquaredC = Math.Pow(Math.Sin(c), 2);
        double tanC = Math.Tan(c);
        double absA_minus_B = Math.Abs(a - b);

        double numerator = Math.Sqrt(Math.Sqrt(b) + Math.Pow(a, 1.0 / 3.0) - 1);
        double denominator = absA_minus_B * (sinSquaredC + tanC);

        if (denominator == 0)
        {
            Console.WriteLine("Division by zero detected");
            return double.NaN;
        }

        return numerator / denominator;
    }

  
        }
    
