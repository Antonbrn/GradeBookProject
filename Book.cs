using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    class Book
    {
        //Constructor
        public Book(string name){
            Name = name;
            grades = new List<double>();
        }


        //Methods
        public void AddGrade(double grade)
        {
            if(grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
        }
        
        public void ShowGrades()
        {
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;
            var averageGrade = 0.0;
            foreach(var grade in grades)
            {
                highGrade = Math.Max(grade, highGrade);
                lowGrade = Math.Min(grade, lowGrade);
                averageGrade += grade / grades.Count;
            }

            Console.WriteLine($"Highest grade:{highGrade}");
            Console.WriteLine($"Lowest grade:{lowGrade}");
            Console.WriteLine($"Average grade:{averageGrade}");
        }

        //Field
        private List<double> grades;
        private string Name;
    }
}
