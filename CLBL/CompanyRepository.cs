using System;
using CLDB;
using CLModels;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using CLValidator;

namespace CLBL
{
    public class CompanyRepository
    {
        private CompanyDataHandler companyDH;
        public CompanyRepository()
        {
            companyDH = new CompanyDataHandler();
        }
        public async Task<List<Company>> getCompanies()
        {
            return await companyDH.getCompanies();
        }
        public async Task<Company> getCompany(int companyId)
        {
            return await companyDH.GetCompany(companyId);
        }
        public async Task<bool> CreateCompany(Company inComp)
        {
            return await companyDH.CreateCompany(inComp);
        }
    }
}
