using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(Object sender, EventArgs args);

    public class NamedObject
    {

        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }


    public interface Ibook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }


    public abstract class Book : NamedObject, Ibook 
        {

        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }


    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {

            var writer = File.AppendText($"{Name}.txt");
            writer.WriteLine(grade);
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }


    public class InMemoryBook : Book
    {
        //Constructor - base() is accessing the constructor from the base class.
        // since Book takes in the name when initialized i can pass it in to the base();

        public InMemoryBook(string name) : base(name)
        {
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

        public override void AddGrade(double grade)
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

        public override event GradeAddedDelegate GradeAdded;
        
        public override Statistics GetStatistics()
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
        
    }
}
