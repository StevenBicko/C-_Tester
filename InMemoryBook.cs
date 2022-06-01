using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs e);

    public class NamedObject
    {
        public string Name { get; set; }

        public NamedObject(string name)
        {
            Name = name;
        }
    }

    public abstract class Book: NamedObject
    {
        public Book(string name):base( name)
        {

        }
        public abstract void Addgrade(double grade);
       
    }

     public interface IBook
    {

        void AddGrade(double grade);
        //Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

   public class InMemoryBook: NamedObject
    {
        List<double> grades = new List<double> { 80, 90, 10, 60, 70, 20,10,30,10,50};
        
         
    
        public InMemoryBook(string name): base(name)
        {
            Name = name;
        }

        public void AddGrades(double grade)
        {
            if (grade <=100 && grade >= 0)
            grades.Add(grade);

             if (GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }

            // kalla en del av system för att notify att en grade har blivit added
            else
            {
                throw new ArgumentException($"Invalid{nameof(grade)}");
            }
           
        }

        public  void AddLetterGrades(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrades(90);
                    break;

                case 'B':
                    AddGrades(80);
                    break;

                case 'C':
                    AddGrades(70);
                    break;

                case 'D':
                    AddGrades(50);
                    break;

                case 'E':
                    AddGrades(40);
                    break;

                case 'F':
                    AddGrades(20);
                    break;

                default:
                    AddGrades(0);
                    break;                             
            }
        }

         public Result GetStatistcs()
        {

            Result result = new Result();

            result.height = double.MinValue;

            result.Average = 0.0;

            result.Lowest = double.MaxValue;


            foreach( var item in grades)
            {
                result.height = Math.Max(item, result.height);
                result.Lowest = Math.Min(item, result.Lowest);
                result.Average += item;
            }

            result.Average /= grades.Count;


           switch (result.Average)
            {
                case var d when d >= 50.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 40.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 30:
                    result.Letter = 'C';
                    break;


                case var d when d >= 20:
                    result.Letter = 'D';
                    break;

                case var d when d >= 10:
                    result.Letter = 'E';
                    break;

                default:
                    result.Letter = 'F';
                    break;                  
            }   
            return result;
        }

        public event GradeAddedDelegate GradeAdded;
    }
}
