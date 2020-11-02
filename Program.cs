using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new double[3] { 10.2, 24.3, 53.5 };

            var result = 0.0;

            foreach(double num in numbers)
            {
                result = result + num + 1;
            }

            Console.WriteLine(result);

            if(args.Length > 0)
            {
                Console.WriteLine($"Hello {args[0]}!");
            } else
            {
                Console.WriteLine("Hello!");
            }
        }
    }
}
