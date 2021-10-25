using Calc.Converter;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
   public class ConverterTests
   {
      List<string> operators = new List<string>(new string[] { "(", ")", "+", "-", "*", "/" });
      IPriority pr = new DefaultPriority();

      [Fact]
      public void Test1 ()
      {
         PostfixNotationConverter psn = new PostfixNotationConverter(pr, operators);

         string[] expected = new string[] { "2", "3", "+" };
         string[] result = psn.Convert("2+3");
         Assert.Equal(expected, result);
      }

      [Fact]
      public void Test2 ()
      {
         PostfixNotationConverter psn = new PostfixNotationConverter(pr, operators);

         string[] expected = new string[] { "2", "3", "-" };
         string[] result = psn.Convert("2-3");
         Assert.Equal(expected, result);
      }

      [Fact]
      public void Test3 ()
      {
         PostfixNotationConverter psn = new PostfixNotationConverter(pr, operators);

         string[] expected = new string[] { "2", "3", "4", "*", "-" };
         string[] result = psn.Convert("2-3*4");
         Assert.Equal(expected, result);
      }

      [Fact]
      public void Test4 ()
      {
         PostfixNotationConverter psn = new PostfixNotationConverter(pr, operators);

         string[] expected = new string[] { "2", "3", "4", "*", "2", "/", "-" };
         string[] result = psn.Convert("2-3*4/2");
         Assert.Equal(expected, result);
      }

      [Fact]
      public void Test5 ()
      {
         PostfixNotationConverter psn = new PostfixNotationConverter(pr, operators);

         string[] expected = new string[] { "2", "3", "-", "4", "*", "2", "/"};
         string[] result = psn.Convert("(2-3)*4/2");
         Assert.Equal(expected, result);
      }
   }
}
