using Infrastructure.Contexts;
using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public class AddressRepository(UserDbContext dbContext) : BaseRepository<AddressEntity>(dbContext)
    {

    }
}
