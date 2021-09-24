using System;

namespace Promocodes.Data.Entities.Shared
{
    public abstract class IdentifiableBase
    {
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            return obj is IdentifiableBase entity &&
                   GetType() == obj.GetType() &&
                   Id == entity.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, GetType());
        }

        public static bool operator ==(IdentifiableBase left, IdentifiableBase right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(IdentifiableBase left, IdentifiableBase right)
        {
            return !(left == right);
        }
    }
}
