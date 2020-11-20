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
        JobTitleDataHandler jobTitleDH;
        public JobTitleRepository()
        {
            jobTitleDH = new JobTitleDataHandler();
        }
        public async Task<List<JobTitle>> getJobTitles()
        {
            return await jobTitleDH.getJobTitles();
        }
        public async Task<JobTitle> getJobTitle(int jobTitleId)
        {
            return await jobTitleDH.GetJobTitle(jobTitleId);
        }
    }
}
