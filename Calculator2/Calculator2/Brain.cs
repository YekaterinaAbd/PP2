using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator2
{
    public enum State
    {
        zero, accumulateDigits, operation, result
    }
    public delegate void MyDelegate(string msg);

    class Brain
    {
        MyDelegate myDelegate;
        public string tempNumber, resultNumber, operation;
        public State state = State.zero;
        public TextBox textBox2;
        public Brain(MyDelegate myDelegate, TextBox textBox2)
        {
            this.textBox2 = textBox2;
            this.myDelegate = myDelegate;
            tempNumber = "";
            resultNumber = "";
            operation = "";
        }


        public void Go(string msg)
        {
            // when we type a number
            if (Rules.IsDigit(msg))
            {
                //if we have a result number and start typing another number
                if(state == State.result)
                {
                    resultNumber = tempNumber = "";
                    myDelegate.Invoke(tempNumber);
                }
                state = State.accumulateDigits;

                //if we want to type a number with ,
                if (msg == "," && tempNumber.Contains(",")) { } //if there is a , in number
                else if (msg == "," && tempNumber == "")
                {
                    tempNumber = "0" + msg;
                    myDelegate.Invoke(tempNumber);
                }
                else
                {
                    //if number = pi
                    if (msg == "π")
                    {
                        tempNumber += Math.PI;
                        myDelegate.Invoke(tempNumber);

                    }
                    tempNumber += msg;
                    myDelegate.Invoke(tempNumber);
                }
                //textBox2.Text = tempNumber;

            }

            //if we want to type an operaton or equal sign with no numbers
            if (state == State.zero)
            {
                if (Rules.IsOperation(msg) || Rules.IsEqualSign(msg)) { }
            }

            //when we type a sign
            if (Rules.IsOperation(msg))
            {
                operation = "";

                if (tempNumber != "" || resultNumber != "")
                {
                    state = State.operation;

                    if (operation.Length != 0)
                    {
                        Calculate();
                    }
                    else if(resultNumber == "")
                    {
                        resultNumber = tempNumber;
                    }

                    operation = msg;
                    tempNumber = "";
                    textBox2.Text = resultNumber + operation;
                }
            }

            //when we type equal sign
            if (Rules.IsEqualSign(msg))
            {
                if (Rules.IsOperation(msg) || Rules.IsEqualSign(msg)) { }

                state = State.result;
                Calculate();
                textBox2.Text = "";

                operation = "";
                tempNumber = resultNumber;
            }

            // backspace, delete all text operations
            if (msg == "<")
            {
                if (state != State.operation)
                {
                    if (tempNumber != "")
                    {
                        int cnt = tempNumber.Length - 1;
                        tempNumber = tempNumber.Remove(cnt, 1);
                        myDelegate.Invoke(tempNumber);
                        textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1,1);
                    }
                }
            }
            if (msg == "C")
            {
                state = State.zero;
                operation = tempNumber = resultNumber = "";
                myDelegate.Invoke(tempNumber);
                textBox2.Text = "";
            }

            //operations with one number
            // x!, 1/x, sqrt, change sign
            if (state == State.accumulateDigits)
            {
                if (msg == "x!")
                {
                    if (int.Parse(tempNumber) >= 0)
                    {
                        tempNumber = (Factorial(int.Parse(tempNumber))).ToString();
                    }
                    //if negative number -> error
                    else
                    {
                        tempNumber = "";
                        myDelegate.Invoke("ERROR");
                        state = State.zero;
                    }
                }
                if (msg == "1/x")
                {
                    tempNumber = (1 / double.Parse(tempNumber)).ToString();
                }
                if (msg == "√")
                {
                    tempNumber = Math.Sqrt(double.Parse(tempNumber)).ToString();
                }
                if (msg == "±")
                {
                    tempNumber = (double.Parse(tempNumber) - (2 * double.Parse(tempNumber))).ToString();
                }
                if(tempNumber != "")
                myDelegate.Invoke(tempNumber);
            }
        }


        //operations with 2 numbers
        private void Calculate()
        {
            if (operation == "+")
            {
                resultNumber = (double.Parse(resultNumber) + double.Parse(tempNumber)).ToString();
            }
            else if (operation == "-")
            {
                resultNumber = (double.Parse(resultNumber) - double.Parse(tempNumber)).ToString();
            }
            else if (operation == "×")
            {
                resultNumber = (double.Parse(resultNumber) * double.Parse(tempNumber)).ToString();
            }
            else if (operation == "^")
            {
                resultNumber = Math.Pow(double.Parse(resultNumber), double.Parse(tempNumber)).ToString();
            }

            else if (operation == "÷")
            {
                bool zero = true;

                //if second number is 0
                foreach (char t in tempNumber)
                {
                    if (t != '0') zero = false;
                }

                if (!zero)
                {
                    resultNumber = (double.Parse(resultNumber) / double.Parse(tempNumber)).ToString();
                }
                else
                {
                    resultNumber = tempNumber = "";
                    myDelegate.Invoke("ERROR");
                    state = State.zero;
                }
            }
            if (tempNumber != "")
            {
                //if we type only one digit and then click equal sign
                if (resultNumber == "")
                {
                    myDelegate.Invoke(tempNumber);
                    resultNumber = tempNumber;
                }
                else
                {
                    myDelegate.Invoke(resultNumber);
                }
            }
            /*else
            {
                myDelegate.Invoke("ERROR");
                state = State.zero;
            }*/
            
        }

        //rule for factorial
        private int Factorial(int msg)
        {
            if (msg == 1 || msg == 0) return 1;
            return msg * Factorial(msg - 1);
        }

    }
}





