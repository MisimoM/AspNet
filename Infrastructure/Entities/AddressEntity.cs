namespace Infrastructure.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; }
        public string StreetLine_1 { get; set; } = null!;
        public string? StreetLine_2 { get; set; }
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public ICollection<UserEntity> Users { get; set; } = [];
    }
}
