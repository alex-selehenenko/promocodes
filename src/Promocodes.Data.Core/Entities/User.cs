using Promocodes.Data.Core.Common;

namespace Promocodes.Data.Core.Entities
{
    public abstract class User : EntityBase<int>, IEntity
    {
        public string UserName { get; set; }

        public string Phone { get; set; }
    }
}
