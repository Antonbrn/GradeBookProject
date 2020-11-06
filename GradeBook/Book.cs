using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(Object sender, EventArgs args);

    public class Book
    {
        //Constructor
        public Book(string name){
            Name = name;
            grades = new List<double>();
        }

        //Methods

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                case 'D':
                    AddGrade(60);
                    break;

                case 'E':
                    AddGrade(50);
                    break;

                default:
                    AddGrade(0);
                    break;

            }
               
        }

        public void AddGrade(double grade)
        {
            if(grade >= 0 && grade <= 100)
            {
      
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            } else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded;
        
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

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;


                case var d when d >= 50.0:
                    result.Letter = 'E';
                    break;
            }
                

            return result;
        }

        //Field
        private List<double> grades;

        public string Name { get; set; }
        
        
    }
}
