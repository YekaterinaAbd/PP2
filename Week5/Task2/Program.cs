using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Task2
{
    [Serializable]
    public class Mark
    {
        public int point;
        public string letter;
        public Mark() { }
        public Mark(int point)
        {
            this.point = point;
            letter = getLetter(point);
        }
        public string getLetter(int point)
        {
            
            string letter = "";

            if (point <= 100 && point >= 90)
            {
                letter = "A";
            }
            else if (point < 90 && point >= 80)
            {
                letter = "B";
            }
            else if (point < 80 && point >= 70)
            {
                letter = "C";
            }
            else if(point < 70 && point >= 60)
            {
                letter = "D";
            }
            else if(point < 60 && point >= 50)
            {
                letter = "E";
            }
            else letter = "F";
            return letter;
        }
        public override string ToString()
        {
            return string.Format("{0} = {1}", point, letter);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            F4();
        }

        //binary deserialize
        private static void F4()
        {
            FileStream fs = new FileStream("marks.txt", FileMode.Open, FileAccess.ReadWrite);
            BinaryFormatter binary = new BinaryFormatter();
            List<Mark> marks = binary.Deserialize(fs) as List<Mark>;
            fs.Close();

            foreach(var mark in marks)
            {
                Console.WriteLine(mark.ToString());
            }
        }

        //binary serialize
        private static void F3()
        {
            Mark m1 = new Mark(22);
            Mark m2 = new Mark(88);
            Mark m3 = new Mark(59);


            List<Mark> marks = new List<Mark>();
            marks.Add(m1);
            marks.Add(m2);
            marks.Add(m3);

            FileStream fs = new FileStream("marks.txt", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(fs, marks);
            fs.Close();
        }

        //xml deserialize
        private static void F2()
        {
            FileStream fs = new FileStream("marks.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xml = new XmlSerializer(typeof(List<Mark>));
            List<Mark> marks = xml.Deserialize(fs) as List<Mark>;
            fs.Close();

            foreach(var mark in marks)
            {
                Console.WriteLine(mark.ToString());
            }
        }

        //xml serialize
        private static void F1()
        {
            Mark m1 = new Mark(90);
            Mark m2 = new Mark(63);
            Mark m3 = new Mark(37);


            List<Mark> marks = new List<Mark>();
            marks.Add(m1);
            marks.Add(m2);
            marks.Add(m3);

            FileStream fs = new FileStream("marks.xml", FileMode.Create, FileAccess.ReadWrite);
            XmlSerializer xml = new XmlSerializer(typeof(List<Mark>));
            xml.Serialize(fs, marks);
            fs.Close();
        }

    }
}
