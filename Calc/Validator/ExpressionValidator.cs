using System.Text.RegularExpressions;

namespace Calc.Validator
{
   public class ExpressionValidator : IValidator
   {
      Regex Ver1 = new Regex(@"\(\)");
      Regex Ver2 = new Regex(@"\(");
      Regex Ver3 = new Regex(@"\)");
      Regex Ver4 = new Regex(@"\+\+|\-\-|\*\*|\/\/|\+\-|\-\+|\-\*|\-\/|\*\/|\/\*|\+\*|\+\/");
      Regex Ver5 = new Regex(@"\d+(?:[\,\.]\d+)?\(");
      public bool IsValid (string s)
      {
         if (!Ver1.IsMatch(s) && !Ver4.IsMatch(s) && !Ver5.IsMatch(s) && (Ver2.Matches(s).Count == Ver3.Matches(s).Count))
         {
            return true;
         }

         return false;
      }
   }
}
