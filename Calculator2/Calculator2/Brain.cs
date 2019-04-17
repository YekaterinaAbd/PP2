using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Brain(MyDelegate myDelegate)
        {
            this.myDelegate = myDelegate;
            tempNumber = "";
            resultNumber = "";
            operation = "";

        }
        //myDelegate.Invoke(tempNumber);


        public void Go(string msg)
        {
            // when we type a number
            if (Rules.IsDigit(msg))
            {
                if(state == State.result)
                {
                    resultNumber = tempNumber = "";
                    myDelegate.Invoke(tempNumber);

                }
                state = State.accumulateDigits;
                if (msg == "," && tempNumber.Contains(",")) { }
                else if (msg == "," && tempNumber == "")
                {
                    tempNumber = "0" + msg;
                    myDelegate.Invoke(tempNumber);
                }
                else
                {
                    if (msg == "π")
                    {
                        tempNumber += Math.PI;
                        myDelegate.Invoke(tempNumber);

                    }
                    //state = State.accumulateDigits;
                    tempNumber += msg;

                    /*if(tempNumber[0] == '0')
                    {
                        if (tempNumber.Length > 1)
                        {
                            if (tempNumber[1] == ',') { }
                            else tempNumber.Remove(0, 1);
                        }
                    }*/
                    myDelegate.Invoke(tempNumber);
                }

            }

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
                }
            }

            //when we type equal sign
            if (Rules.IsEqualSign(msg))
            {
                if (Rules.IsOperation(msg) || Rules.IsEqualSign(msg)) { }
                state = State.result;
                Calculate();

                operation = "";
                tempNumber = resultNumber;
            }

            // backspace, sqrt, sign change, 1/x operations


            if (msg == "<")
            {
                if (state != State.operation)
                {
                    if (tempNumber != "")
                    {
                        int cnt = tempNumber.Length - 1;
                        tempNumber = tempNumber.Remove(cnt, 1);
                        myDelegate.Invoke(tempNumber);
                    }

                }
            }
            if (msg == "C")
            {
                state = State.zero;
                operation = tempNumber = resultNumber = "";
                myDelegate.Invoke(tempNumber);
            }


            if (state == State.accumulateDigits)
            {
                if (msg == "x!")
                {

                    if (int.Parse(tempNumber) >= 0)
                        tempNumber = (Factorial(int.Parse(tempNumber))).ToString();
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
                    //myDelegate.Invoke(tempNumber);
                }

                if (msg == "√")
                {
                    tempNumber = Math.Sqrt(double.Parse(tempNumber)).ToString();
                    //myDelegate.Invoke(tempNumber);

                }
                if (msg == "±")
                {
                    tempNumber = (double.Parse(tempNumber) - (2 * double.Parse(tempNumber))).ToString();
                    //myDelegate.Invoke(tempNumber);
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

                foreach (char t in tempNumber)
                {
                    if (t != '0') zero = false;
                }

                if (!zero)
                {
                    resultNumber = (double.Parse(resultNumber) / double.Parse(tempNumber)).ToString();
                }
                else resultNumber = tempNumber = "";

            }
            if (tempNumber != "")
            {
                if (resultNumber == "")
                {
                    myDelegate.Invoke(tempNumber);
                    resultNumber = tempNumber;

                }
                else
                {
                    myDelegate.Invoke(resultNumber);
                }
                //state = State.operation;

            }
            else
            {
                myDelegate.Invoke("ERROR");
                state = State.zero;
            }
            
        }

        private int Factorial(int msg)
        {
            if (msg == 1 || msg == 0) return 1;
            return msg * Factorial(msg - 1);
        }

    }
}





