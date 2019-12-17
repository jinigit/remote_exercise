using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook{

    public delegate void GradeAddedEventHandler(object sender, EventArgs args);

    public class NamedObject {
        public NamedObject(string name){
            Name = name;
        }
        public string Name { get; set;}
    }

    public abstract class Book : NamedObject, IBook
    {
        public Book(string name):base(name){

        }

        public abstract event GradeAddedEventHandler GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get;}
        event GradeAddedEventHandler GradeAdded;

    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name){

        }
        public override void AddGrade(double grade)
        {
            using (var write = File.AppendText($"{Name}.txt")){
                write.WriteLine(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }
            }
        }
        public override event GradeAddedEventHandler GradeAdded;
        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
    public class InMemoryBook : Book
    {

        private List<double> grades;

        public override event GradeAddedEventHandler GradeAdded;

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
        public override void AddGrade(double grade){

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
        public override Statistics GetStatistics(){

            var stat = new Statistics();
            
            for(int i = 0; i <grades.Count; i++){
               stat.Add(grades[i]);
            }
           
           return stat;

            // Console.WriteLine($"Highest grade: {highGrade}");
            // Console.WriteLine($"Lowest grade: {lowGrade}");
            // Console.WriteLine($"Average:  {result:N1}");
        }

        public InMemoryBook(string name)  : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
    }

}