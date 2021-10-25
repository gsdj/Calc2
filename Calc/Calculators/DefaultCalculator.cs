using System;

namespace Calc.Calculators
{
   public class DefaultCalculator : Calculator, IBinaryOperations
   {
      public override void Calc (string op, decimal a, decimal b)
      {
         _result = 0;
         switch (op)
         {
            case "+":
               Add(a, b);
               break;
            case "-":
               Subtract(a, b);
               break;
            case "*":
               Multiply(a, b);
               break;
            case "/":
               Divide(a, b);
               break;
            default:
               break;
         }
      }

      public void Add (decimal a, decimal b)
      {
         _result = a + b;
      }

      public void Divide (decimal a, decimal b)
      {
         if (a != 0 && b != 0)
         {
            _result = b / a;
         }
         else
         {
            Console.WriteLine("Деление на ноль недопустимо.");
         }

      }

      public void Multiply (decimal a, decimal b)
      {
         _result = b * a;
      }

      public void Subtract (decimal a, decimal b)
      {
         _result = b - a;
      }
   }
}
