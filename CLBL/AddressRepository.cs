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
        public async Task<int> CreateAddress(Address inAddr)
        {
            //Der sendes en ny employee ind i datalaget. Her skal der laves validering
            AddressDataHandler addr = new AddressDataHandler();
            return await addr.CreateAddress(inAddr);
        }
        public async Task<Address> getAddressFromId(int addressId)
        {
            //Modtager gadenavn på en valgt adresse i updatemodul
            AddressDataHandler addr = new AddressDataHandler();
            return await addr.getAddressFromId(addressId);
        }
    }
}
