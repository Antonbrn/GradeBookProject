using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public class Book
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
        
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            return result;
        }

        //Field
        private List<double> grades;
        public string Name;
    }
}
