using static Task_33_01.Class1;

namespace Task_33_01
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IDrawable triangle = new RightTriangle(5);
                triangle.Draw();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
        
    


