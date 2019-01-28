using System;

namespace Task2
{
    class Student
    {
        public string name;
        public string id;
        public Student(string name, string id)
        {
            this.name = name;
            this.id = id;

        }
        public void PrintInfo()
        {
            Console.WriteLine("student name: " + name);
            Console.WriteLine("student id: " + id);


        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Jack", "18BD001000");
            s.PrintInfo();
            Console.Write("define year of study: ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("year of study: " + ++year);

        }
    }
}
