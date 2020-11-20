using System;
using System.Collections.Generic;
using System.Text;
using CLDB;
using System.Threading;
using System.Threading.Tasks;
using CLModels;
using CLValidator;
using System.Data;

namespace CLBL
{
    public class AddressRepository
    {
        private AddressDataHandler addrDH;
        public AddressRepository()
        {
            addrDH = new AddressDataHandler();
        }
        public async Task<int> CreateAddress(Address inAddr)
        {
            //Der sendes en ny address ind i datalaget.
            return await addrDH.CreateAddress(inAddr);
        }
        public async Task<Address> getAddressFromId(int addressId)
        {
            //Modtager addresse id på en valgt adresse i updatemodul
            return await addrDH.getAddressFromId(addressId);
        }
        public async Task<Address> getAddressZipCodeAndStreet(int zipCode, string street)
        {
            //Modtager addresse id på en valgt adresse i updatemodul
            return await addrDH.getAddressFromZipCodeAndStreet(zipCode, street);
        }
        public async Task<bool> updateAddress(Address inAddr)
        {
            return await addrDH.updateAddress(inAddr);
        }
    }
}
