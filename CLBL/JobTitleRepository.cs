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
    public class JobTitleRepository
    {
        public async Task<List<JobTitle>> getJobTitles()
        {
            JobTitleDataHandler jobTitleDH = new JobTitleDataHandler();
            return await jobTitleDH.getJobTitles();
        }
    }
}
