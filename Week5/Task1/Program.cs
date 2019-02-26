using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Task1
{
    public class Complex
    {
        public double a;
        public double b;
        public Complex() { }
       
        public void PrintInfo()
        {
            Console.WriteLine(string.Format("{0} + {1}i", a, b));
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            F1();
            
        }
        public static void F1()
        {
            Complex c1 = new Complex();
            c1.a = 3;
            c1.b = 5;
            c1.PrintInfo();
            FileStream fs = new FileStream("complex.txt", FileMode.Create, FileAccess.Write);
            XmlSerializer xml = new XmlSerializer(typeof(Complex));
            xml.Serialize(fs, c1);
            fs.Close();
        }
        public static void F2()
        {
            FileStream fs2 = new FileStream("complex.txt", FileMode.Open, FileAccess.Read);
            XmlSerializer xml2 = new XmlSerializer(typeof(Complex));
            Complex s = xml2.Deserialize(fs2) as Complex;
            s.PrintInfo();
            fs2.Close();

        }
    }
}
