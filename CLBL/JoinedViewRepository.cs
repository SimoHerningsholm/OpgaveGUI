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
        JoinedViewsDataHandler joinedViewDH;
        public JoinedViewRepository()
        {
            joinedViewDH = new JoinedViewsDataHandler();
        }
        public async Task<DataView> ViewEmployeesWithJoinedData()
        {
            return await joinedViewDH.ViewEmployeesWithJoinedData();
        }
    }
}
