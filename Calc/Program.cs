using Calc.Calculators;
using Calc.Converter;
using Calc.Validator;
using System;
using System.Collections.Generic;

namespace Calc
{
   class Program
   {
      static void Main (string[] args)
      {
         bool endApp = false;

         List<string> operators = new List<string>(new string[] { "(", ")", "+", "-", "*", "/" });
         Calculator c = new DefaultCalculator();
         IPriority pr = new DefaultPriority();
         IValidator validator = new ExpressionValidator();

         PostfixNotationConverter psn = new PostfixNotationConverter(pr, operators);
         StackMachine sm = new StackMachine(c, operators);

         while (!endApp)
         {
            Console.Write("Expression: ");
            string s = Console.ReadLine();
            if (validator.IsValid(s))
            {
               string[] pNotation = psn.Convert(s);
               decimal result = sm.Result(pNotation);

               Console.WriteLine($"{s} = {result}");
            }
            else
            {
               Console.WriteLine("Expression is not valid.");
            }


            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n");
         }
      }
   }
}
