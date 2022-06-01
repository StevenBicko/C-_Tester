using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {


            InMemoryBook book = new InMemoryBook("Tommy");
            book.GradeAdded += OnGradeAdded;
           
            Console.WriteLine($"Welcome {book.Name}");
            
           //

            while(true)
            {
                Console.Write("Please enter grade Or Enter 'q' for getting results: ");
                var input = Console.ReadLine();
                if (input !="q")
                {           
                    book.AddGrades(double.Parse(input));
                    Console.WriteLine();
                }
                else  if (input == "q")
                {
                    break;
                }
            }

            var result = book.GetStatistcs();
            Console.WriteLine();
            Console.WriteLine("**** Here is the results ****");
            Console.WriteLine();

            Console.WriteLine($"highest is {result.height}");
            Console.WriteLine($"Lowest is   {result.Lowest}");
            Console.WriteLine($"Average is  {result.Average}");
            Console.WriteLine();
            Console.WriteLine($"The corresponding letter for your average of grades is the letter {result.Letter}");

            Console.ReadLine();
        }

         public static void OnGradeAdded (object sender, EventArgs e)
        {
            Console.WriteLine("A grade is added");
        }
    }
}
       
