using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities
{
    public class UserEntity : IdentityUser
    {
        public string ProfileImage { get; set; } = "profile-image.png";

        public string? Bio {  get; set; }

        [ProtectedPersonalData]
        public string FirstName { get; set; } = null!;
        
        [ProtectedPersonalData]
        public string LastName { get; set;} = null!;

        public int? AddressId { get; set; }
        public AddressEntity? Address { get; set; }
    }
}
