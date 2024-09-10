using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public delegate T Formula<T>(T txtBoxInput1, T txtBoxInput2);
    class Calculator
    {
        public Formula<double> formula;
        public event Formula<double> CalculateEvent;

        public double GetSum(double txtBoxInput1,  double txtBoxInput2)
        {
            return txtBoxInput1 + txtBoxInput2;
        }
        
        public double GetDiff(double txtBoxInput1, double txtBoxInput2)
        {
            return txtBoxInput1 - txtBoxInput2;
        }

        public double GetProd(double txtBoxInput1, double txtBoxInput2)
        {
            return txtBoxInput1 * txtBoxInput2;
        }

        public double GetQout(double txtBoxInput1, double txtBoxInput2)
        {
            return (txtBoxInput1 / txtBoxInput2);
        }
        public event Formula<double> calculateEvent
        {
            add
            {
                Console.WriteLine(" Added the Delegate");
            }
            remove
            {
                Console.WriteLine(" Remove the Delegate");
            }
        }
    }
}

