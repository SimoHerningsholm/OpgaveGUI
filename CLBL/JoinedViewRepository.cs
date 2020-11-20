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
    public class JoinedViewRepository
    {
        //deklerere joinedview datahandler
        JoinedViewsDataHandler joinedViewDH;
        public JoinedViewRepository()
        {
            //instanciere joinedview datahandler objekt
            joinedViewDH = new JoinedViewsDataHandler();
        }
        public async Task<DataView> ViewEmployeesWithJoinedData()
        {
            //returnere dataview med data for employee joined med alle tabeller
            return await joinedViewDH.ViewEmployeesWithJoinedData();
        }
        public async Task<DataView> ViewEmployeeWithJoinedData(int employeeId)
        {
            //returnere dataview med data for employee på basis af id
            return await joinedViewDH.ViewEmployeeWithJoinedData(employeeId);
        }
    }
}
