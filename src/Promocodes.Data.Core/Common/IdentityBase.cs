using System;

namespace Promocodes.Data.Core.Common
{
    public abstract class IdentityBase<TKey>
    {
        public TKey Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is IdentityBase<TKey> another &&
                   another.GetType() == another.GetType() &&
                   Id.Equals(another.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, GetType());
        }

        public static bool operator ==(IdentityBase<TKey> left, IdentityBase<TKey> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(IdentityBase<TKey> left, IdentityBase<TKey> right)
        {
            return !(left == right);
        }
    }
}
