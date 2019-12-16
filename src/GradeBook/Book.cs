using System;
using System.Collections.Generic;

namespace GradeBook{

    public class Book{

        private List<double> grades;
        private string name;
        public void AddGrade(double grade){
            grades.Add(grade);
        }
        public Statistics GetStatistics(){

            var stat = new Statistics();
            stat.Average= 0.0;
            stat.High = double.MinValue;
            stat.Low = double.MaxValue;
            foreach(var grade in grades){
                stat.Average += grade;
                stat.High = Math.Max(stat.High, grade);
               
                stat.Low  = Math.Min(stat.Low, grade);
    
            }
           //result /= grades.Count;
           stat.Average /= grades.Count;

           return stat;

            // Console.WriteLine($"Highest grade: {highGrade}");
            // Console.WriteLine($"Lowest grade: {lowGrade}");
            // Console.WriteLine($"Average:  {result:N1}");
        }

        public Book(string name){
            grades = new List<double>();
            this.name = name;
        }
    }

}