using System;

namespace Promocodes.Data.Core.Exceptions
{
    class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string entityName, string idValue) : base($"Entity {entityName} with ID {idValue} was not found")
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}
