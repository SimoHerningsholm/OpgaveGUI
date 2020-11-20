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
        //deklerere companydatahandler variabel
        private CompanyDataHandler companyDH;
        public CompanyRepository()
        {
            //instanciere companydatahandler objekt
            companyDH = new CompanyDataHandler();
        }
        public async Task<List<Company>> getCompanies()
        {
            //kalder getcompanies metoden på companydh objektet for at modtage company liste
            return await companyDH.getCompanies();
        }
        public async Task<Company> getCompany(int companyId)
        {
            //kalder getcompany metoden der returenre et company objekt på basis af company id
            return await companyDH.GetCompany(companyId);
        }
        public async Task<Company> getCompanyFromDepartmentId(int departmentId)
        {
            //kalder getcompany metoden der returenre et company objekt på basis af department id
            return await companyDH.GetCompanyFromDepartmentId(departmentId);
        }
        public async Task<bool> CreateCompany(Company inComp)
        {
            //sender et company objekt ind i datalaget med henblik på at blive oprettet
            return await companyDH.CreateCompany(inComp);
        }
    }
}
