namespace Promocodes.Data.CoreTests.Helpers
{
    public class EntityContainer<T> where T : class
    {
        public T Entity { get; set; }

        public string CaseName { get; set; }

        public override string ToString()
        {
            return CaseName ?? base.ToString();
        }
    }
}
