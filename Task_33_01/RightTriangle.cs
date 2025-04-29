using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_33_01
{
    internal class Class1
    {
        internal interface IDrawable
        {
            void Draw();
        }

        internal class RightTriangle : IDrawable
        {
            private int legsLength;
            public int LegsLength
            {
                get => legsLength;
                set
                {
                    if (value > 1)
                        legsLength = value;
                    else
                        throw new ArgumentException("Длина катетов не должна быть меньше или равна 1");
                }
            }

            public RightTriangle(int legsLength)
            {
                LegsLength = legsLength;
            }

            public void Draw()
            {
                Console.WriteLine();
                for (int i = 0; i < LegsLength; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        Console.Write('*');
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
