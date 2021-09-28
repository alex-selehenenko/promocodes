namespace Promocodes.Data.CoreTests.Helpers
{
    public class ValidatorTestCase<T> where T : class
    {
        public T Entity { get; set; }

        public int ExpectedErrors { get; set; }

        public string DisplayMessage { get; set; }

        public override string ToString()
        {
            return DisplayMessage ?? base.ToString();
        }

        public ValidatorTestCase()
        {
            ExpectedErrors = 1;
        }
    }
}
