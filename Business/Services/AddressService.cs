using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Business.Services
{
    public class AddressService(AddressRepository addressRepository)
    {
        private readonly AddressRepository _addressRepository = addressRepository;

        public async Task<AddressEntity> CreateAddressAsync(AddressEntity addressEntity)
        {
            try
            {
                var newAddress = await _addressRepository.AddAsync(addressEntity);

                if (newAddress is not null)
                {
                    return newAddress;
                }
                
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

            return null!;
        }

        public async Task<AddressEntity> GetAddressAsync(int? addressId)
        {
            try
            {
                var getAddress = await _addressRepository.GetAsync(address => address.Id == addressId);

                if(getAddress is not null)
                    return getAddress;
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

            return null!;
        }


    }
}
