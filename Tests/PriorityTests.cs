using Calc.Converter;
using Xunit;

namespace Tests
{
   public class PriorityTests
   {
      IPriority Priority;

      [Fact]
      public void Test1()
      {
         Priority = new DefaultPriority();
         byte result = Priority.GetPriority("(");
         byte expected = 0;
         Assert.Equal(expected, result);
      }
      [Fact]
      public void Test2 ()
      {
         Priority = new DefaultPriority();
         byte result = Priority.GetPriority(")");
         byte expected = 0;
         Assert.Equal(expected, result);
      }
      [Fact]
      public void Test3 ()
      {
         Priority = new DefaultPriority();
         byte result = Priority.GetPriority("+");
         byte expected = 1;
         Assert.Equal(expected, result);
      }
      [Fact]
      public void Test4 ()
      {
         Priority = new DefaultPriority();
         byte result = Priority.GetPriority("-");
         byte expected = 1;
         Assert.Equal(expected, result);
      }
      [Fact]
      public void Test5 ()
      {
         Priority = new DefaultPriority();
         byte result = Priority.GetPriority("*");
         byte expected = 2;
         Assert.Equal(expected, result);
      }
      [Fact]
      public void Test6 ()
      {
         Priority = new DefaultPriority();
         byte result = Priority.GetPriority("/");
         byte expected = 2;
         Assert.Equal(expected, result);
      }
   }
}
