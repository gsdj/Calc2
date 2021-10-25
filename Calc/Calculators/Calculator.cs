namespace Calc.Calculators
{
   public abstract class Calculator
   {
      protected decimal _result = 0;
      public abstract void Calc (string op, decimal a, decimal b);

      public decimal GetResult()
      {
         return _result;
      }
   }
}
