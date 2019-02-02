using System;

namespace Task2
{
    class Student
    {
        public string name, id;
        public int year = 1;
        public Student(string name, string id)
        {
            this.name = name;
            this.id = id;

        }
        public void PrintInfo()
        {
            Console.WriteLine("student: " + name);
            Console.WriteLine("id: " + id);
            Console.WriteLine("year of study: " + year);

        }
        public void IncrimentYear()
        {
            Console.WriteLine("new year of study: " +  ++year);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Jack", "18BD001000");
            s.PrintInfo();
            s.IncrimentYear();
           
            


            

        }
    }
}
