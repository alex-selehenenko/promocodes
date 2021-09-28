namespace Promocodes.Data.Core.Common
{
    public abstract class IdentityBase<TKey>
    {
        public TKey Key { get; set; }
    }
}
