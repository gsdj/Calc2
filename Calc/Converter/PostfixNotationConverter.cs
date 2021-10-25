using System;
using System.Collections.Generic;

namespace Calc.Converter
{
   public class PostfixNotationConverter 
   {
      private List<string> _operators;
      private IPriority Priority;

      public PostfixNotationConverter(IPriority priority, List<string> operators)
      {
         Priority = priority;
         _operators = operators;
      }
      private IEnumerable<string> Separate (string input)
      {
         int pos = 0;
         while (pos < input.Length)
         {
            string s = string.Empty + input[pos];
            if (!_operators.Contains(input[pos].ToString()))
            {
               if (Char.IsDigit(input[pos]))
               {
                  for (int i = pos + 1; i < input.Length && (Char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                  {
                     s += input[i];
                  }
                     
               }
               else if (Char.IsLetter(input[pos]))
               {
                  for (int i = pos + 1; i < input.Length && (Char.IsLetter(input[i]) || Char.IsDigit(input[i])); i++)
                  {
                     s += input[i];
                  }
                     
               }
            }
            yield return s;
            pos += s.Length;
         }
      }

      private byte GetPriority (string s)
      {
         return Priority.GetPriority(s);
      }

      public string[] Convert (string input)
      {
         List<string> outputSeparated = new List<string>();
         Stack<string> stack = new Stack<string>();
         foreach (string c in Separate(input))
         {
            if (_operators.Contains(c))
            {
               if (stack.Count > 0 && !c.Equals("("))
               {
                  if (c.Equals(")"))
                  {
                     string s = stack.Pop();
                     while (s != "(")
                     {
                        outputSeparated.Add(s);
                        s = stack.Pop();
                     }
                  }
                  else if (GetPriority(c) > GetPriority(stack.Peek()))
                     stack.Push(c);
                  else
                  {
                     while (stack.Count > 0 && GetPriority(c) <= GetPriority(stack.Peek()))
                        outputSeparated.Add(stack.Pop());
                     stack.Push(c);
                  }
               }
               else
                  stack.Push(c);
            }
            else
               outputSeparated.Add(c);
         }
         if (stack.Count > 0)
            foreach (string c in stack)
               outputSeparated.Add(c);

         return outputSeparated.ToArray();
      }
   }
}
