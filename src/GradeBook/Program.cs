using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //var numbers = new[] {12.7, 10.3, 6.11, 4.1};
            var grades = new List<double>{12.7, 10.3, 6.11, 4.1};
            var book = new Book("Scott's Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5); 
            book.AddGrade(77.5);

            //show statistics
            var result = book.GetStatistics();

            Console.WriteLine($"Highest grade: {result.High}");
            Console.WriteLine($"Lowest grade: {result.Low}");
            Console.WriteLine($"Average:  {result.Average:N1}");
           
            
        }
    }
}