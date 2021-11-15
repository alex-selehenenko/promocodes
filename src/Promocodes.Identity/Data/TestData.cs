using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Promocodes.Identity.Data
{
    public static class TestData
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole()
                {
                    Id = "ShopAdmin",
                    Name = "ShopAdmin"
                },
                new IdentityRole()
                {
                    Id = "Customer",
                    Name = "Customer"
                });

            builder.Entity<IdentityUser>()
                .HasData(
                new IdentityUser()
                {
                    Id = "698306d9-4478-4a58-8b38-b547e85e2289",
                    UserName = "Alex"
                },
                new IdentityUser()
                {
                    Id = "82b4753f-8f7f-43d1-a67d-13b531d9512b",
                    UserName = "Jack"
                },
                new IdentityUser()
                {
                    Id = "e71a1ef0-fcdc-4069-87bb-2b38bdde23ac",
                    UserName = "Electron"
                });
        }
    }
}
