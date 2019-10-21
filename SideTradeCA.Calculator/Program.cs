using System;

namespace SideTradeCA.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            Console.WriteLine("What is the value of x?");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("What is the value of y?");
            int y = int.Parse(Console.ReadLine());

            int result = calculator.Add(x, y);
            string output = $"{x.ToString()} + {y.ToString()} = {result.ToString()}";
            Console.WriteLine(output);
        }
        static int Add(int x, int y)
        {
            return x + y;
        }
    }
}