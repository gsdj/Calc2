using Calc.Calculators;
using System;
using System.Collections.Generic;

namespace Calc
{
   public class StackMachine
   {
      private Calculator Calculator;
      private List<string> _operators;
      public StackMachine(Calculator c, List<string> op)
      {
         Calculator = c;
         _operators = op;
      }

      public decimal Result (string[] PostfixNotation)
      {
         Stack<string> stack = new Stack<string>();
         Queue<string> queue = new Queue<string>(PostfixNotation);
         string str = queue.Dequeue();
         while (queue.Count >= 0)
         {
            if (!_operators.Contains(str))
            {
               stack.Push(str);
               str = queue.Dequeue();
            }
            else
            {
               try
               {
                  decimal a = Convert.ToDecimal(stack.Pop());
                  decimal b = Convert.ToDecimal(stack.Pop());
                  Calculator.Calc(str, a, b);
               }
               catch (Exception ex)
               {
                  Console.WriteLine(ex.Message);
               }
               stack.Push(Calculator.GetResult().ToString());
               if (queue.Count > 0)
                  str = queue.Dequeue();
               else
                  break;
            }

         }
         return Convert.ToDecimal(stack.Pop());
      }
   }
}
