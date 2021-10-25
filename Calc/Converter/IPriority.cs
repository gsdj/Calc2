namespace Calc.Converter
{
   public interface IPriority
   {
      byte GetPriority (string s);
   }

   public class DefaultPriority : IPriority
   {
      public byte GetPriority (string s)
      {
         switch (s)
         {
            case "(":
            case ")":
               return 0;
            case "+":
            case "-":
               return 1;
            case "*":
            case "/":
               return 2;
            default:
               return 3;
         }
      }
   }
}
