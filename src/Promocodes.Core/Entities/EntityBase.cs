using System;

namespace Promocodes.Core.Entities
{
    public abstract class EntityBase
    {
        public long Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is EntityBase entity &&
                   GetType() == obj.GetType() &&
                   Id == entity.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, GetType());
        }

        public static bool operator ==(EntityBase left, EntityBase right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EntityBase left, EntityBase right)
        {
            return !(left == right);
        }
    }
}
