using Calc.Calculators;
using Xunit;

namespace Tests
{
   public class CalculatorTests
   {
      Calculator calc;

      [Fact]
      public void AddTest ()
      {
         calc = new DefaultCalculator();
         calc.Calc("+", 2 , 4);
         decimal result = calc.GetResult();
         decimal expected = 6;
         Assert.Equal(expected, result);
      }

      [Fact]
      public void SubtractTest ()
      {
         calc = new DefaultCalculator();
         calc.Calc("-", 2, 4);
         decimal result = calc.GetResult();
         decimal expected = 2;
         Assert.Equal(expected, result);
      }

      [Fact]
      public void MultiplyTest ()
      {
         calc = new DefaultCalculator();
         calc.Calc("*", 2, 4);
         decimal result = calc.GetResult();
         decimal expected = 8;
         Assert.Equal(expected, result);
      }

      [Fact]
      public void DivideTest ()
      {
         calc = new DefaultCalculator();
         calc.Calc("/", 4, 2);
         decimal result = calc.GetResult();
         decimal expected = 0.5m;
         Assert.Equal(expected, result);
      }

      [Fact]
      public void DivideTestWithZero ()
      {
         calc = new DefaultCalculator();
         calc.Calc("/", 4, 0);
         decimal result = calc.GetResult();
         decimal expected = 0;
         Assert.Equal(expected, result);
      }
      [Fact]
      public void DivideTestWithZero2 ()
      {
         calc = new DefaultCalculator();
         calc.Calc("/", 0, 3);
         decimal result = calc.GetResult();
         decimal expected = 0;
         Assert.Equal(expected, result);
      }
      [Fact]
      public void DivideTestWithZero3 ()
      {
         calc = new DefaultCalculator();
         calc.Calc("/", 0, 0);
         decimal result = calc.GetResult();
         decimal expected = 0;
         Assert.Equal(expected, result);
      }
   }
}
