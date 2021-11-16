using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.EntityFrameworkCore;
using Promocodes.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promocodes.Identity.Validation
{
    public class ResourceOwnerValidator : IResourceOwnerPasswordValidator
    {
        private readonly IdentityServerDbContext _dbContext;

        public ResourceOwnerValidator(IdentityServerDbContext context)
        {
            _dbContext = context;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _dbContext.Users.Where(user => user.UserName == context.UserName)
                                             .FirstOrDefaultAsync();

            if (context.Password != user.PasswordHash)
            {
                throw new Exception("PASSWORD IS INVALID");
            }
        }
    }
}
