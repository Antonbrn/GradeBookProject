using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main()
        {
            var book = new Book("Anton's Grade Book");

            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);
            book.AddGrade(105);

            var result = book.GetStatistics();

            Console.WriteLine($"The average grade is: {result.Average}");
            Console.WriteLine($"The highest grade is: {result.High}");
            Console.WriteLine($"The lowest grade is: {result.Low}");

        }
    }
}
