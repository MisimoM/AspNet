using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class UserDbContext(DbContextOptions options) : IdentityDbContext(options)
    {
        public DbSet<AddressEntity> Address { get; set; }
    }
}
