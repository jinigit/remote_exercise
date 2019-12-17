using System;
using System.Collections.Generic;

namespace GradeBook{

    public delegate void GradeAddedEventHandler(object sender, EventArgs args);

    public class Book{

        private List<double> grades;
        private string name;
        public string Name{
            get{
                return name;
            }
            set{

                if(!String.IsNullOrEmpty(value)){
                     name = value;
                }
               
            }
        }

        public event GradeAddedEventHandler GradeAdded;

        public void AddLetterGarde(char letter){
            switch(letter){
                case 'A' :
                    AddGrade(90);
                    break;
                case 'B' :
                    AddGrade(80);
                    break;
                case 'C' :
                    AddGrade(70);
                    break;
                default : 
                    AddGrade(0);
                    break;
            }
        }
        public void AddGrade(double grade){

            if(grade >= 0 && grade <= 100){
                 grades.Add(grade);

                 OnGradeAdded();
            }else{
                throw new ArgumentException($"Invalid grade: {grade}");
            }
           
        }

        protected virtual void OnGradeAdded(){
            if (GradeAdded != null){

                //invoke event
                GradeAdded(this, new EventArgs());
            }

        }
        public Statistics GetStatistics(){

            var stat = new Statistics();
            stat.Average= 0.0;
            stat.High = double.MinValue;
            stat.Low = double.MaxValue;

            
            // foreach(var grade in grades){
            //     stat.Average += grade;
            //     stat.High = Math.Max(stat.High, grade);
               
            //     stat.Low  = Math.Min(stat.Low, grade);
    
            // }
           // int index = 0;
           // while (index < grades.Count){
            for(int i = 0; i <grades.Count; i++){
                stat.Average += grades[i];
                stat.High = Math.Max(stat.High, grades[i]);
                stat.Low  = Math.Min(stat.Low, grades[i]);
            }
           //result /= grades.Count;
           stat.Average /= grades.Count;

           switch (stat.Average){
               case var d when d >= 90.0:
                    stat.Letter = 'A';
                    break;
                case var d when d >= 80.0 :
                    stat.Letter = 'B';
                    break;
                case var d when d >= 70.0 :
                    stat.Letter = 'C';
                    break;
                case var d when d >= 60.0:
                    stat.Letter = 'D';
                    break;
                default:
                    stat.Letter = 'F';
                    break;
           }    

           return stat;

            // Console.WriteLine($"Highest grade: {highGrade}");
            // Console.WriteLine($"Lowest grade: {lowGrade}");
            // Console.WriteLine($"Average:  {result:N1}");
        }

        public Book(string name){
            grades = new List<double>();
            Name = name;
        }
    }

}