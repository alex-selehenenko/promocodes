using System;

namespace Promocodes.Data.Core.Common
{
    public abstract class EntityBase<TKey>
    {
        public TKey Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is EntityBase<TKey> another &&
                   another.GetType() == another.GetType() &&
                   Id.Equals(another.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, GetType());
        }

        public static bool operator ==(EntityBase<TKey> left, EntityBase<TKey> right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EntityBase<TKey> left, EntityBase<TKey> right)
        {
            return !(left == right);
        }
    }
}
