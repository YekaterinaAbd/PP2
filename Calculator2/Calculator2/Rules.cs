using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2
{
    class Rules
    {
        public static bool IsDigit(string c)
        {
            string[] arr = new string [] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", ",", "π" };
            return arr.Contains(c);
        }

        public static bool IsZero(string c)
        {
            string[] arr = new string[] { "0"};
            return arr.Contains(c);
        }

        public static bool IsNonzeroDIgit(string c)
        {
            string[] arr = new string [] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "π" };
            return arr.Contains(c);
        }

        public static bool IsOperation(string c)
        {
            string[] arr = new string[]{ "+","-", "×", "÷", "^" };
            return arr.Contains(c);
        }

   

        public static bool IsEqualSign(string c)
        {
            string[] arr = new string[] { "=" };
            return arr.Contains(c);
        }
    }
}
