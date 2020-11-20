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
    public class ZipCodeRepository
    {
        public async Task<List<ZipCode>> getZipCodes()
        {
            //Laver object af datahandler og kalder metode der skal anvendes for at modtage zipcodes
            ZipCodeDataHandler zipCodeDH = new ZipCodeDataHandler();
            return await zipCodeDH.getZipCodes();
        }
    }
}
