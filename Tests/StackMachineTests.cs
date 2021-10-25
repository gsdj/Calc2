using Calc;
using Calc.Calculators;
using Calc.Converter;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
   public class StackMachineTests
   {
      List<string> operators = new List<string>(new string[] { "(", ")", "+", "-", "*", "/" });
      IPriority pr = new DefaultPriority();
      Calculator c = new DefaultCalculator();

      [Fact]
      public void Test1()
      {
         PostfixNotationConverter psn = new PostfixNotationConverter(pr, operators);
         StackMachine sm = new StackMachine(c, operators);
         string[] pNotation = psn.Convert("2+2*3-1+3");
         decimal expected = 10;
         decimal result = sm.Result(pNotation);
         Assert.Equal(expected, result);
      }

      [Fact]
      public void Test2 ()
      {
         PostfixNotationConverter psn = new PostfixNotationConverter(pr, operators);
         StackMachine sm = new StackMachine(c, operators);
         string[] pNotation = psn.Convert("2+2*3-(1+3)");
         decimal expected = 4;
         decimal result = sm.Result(pNotation);
         Assert.Equal(expected, result);
      }
   }
}
