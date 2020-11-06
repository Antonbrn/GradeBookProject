using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main()
        {

            var book = new Book("Anton's Grade Book");
            book.GradeAdded += OnGradeAdded;


            while(true)
            {
                Console.WriteLine("Enter a grade or Q to quit!");
                var input = Console.ReadLine();

                if(input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
             
            }

            var stats = book.GetStatistics();
            book.Name = "";
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The average grade is: {stats.Average}");
            Console.WriteLine($"The highest grade is: {stats.High}");
            Console.WriteLine($"The lowest grade is: {stats.Low}");
            Console.WriteLine($"The letter grade is: {stats.Letter}");

        }

        static void OnGradeAdded(Object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }
    }
}
