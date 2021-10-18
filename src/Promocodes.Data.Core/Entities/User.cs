using Promocodes.Data.Core.Common;
using Promocodes.Data.Core.Common.Types;

namespace Promocodes.Data.Core.Entities
{
    public abstract class User : EntityBase<int>, IEntity
    {
        public string UserName { get; set; }

        public string Phone { get; set; }

        public Role Role { get; set; }
    }
}
