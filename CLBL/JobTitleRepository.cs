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
        //deklerere jobtiteldatahandler variabel
        JobTitleDataHandler jobTitleDH;
        public JobTitleRepository()
        {
            //instanciere jobtiteldatahandler objekt
            jobTitleDH = new JobTitleDataHandler();
        }
        public async Task<List<JobTitle>> getJobTitles()
        {
            //kalder metode fra jobtitledatahandlerobjekt der returnere liste af jobtitler
            return await jobTitleDH.getJobTitles();
        }
        public async Task<JobTitle> getJobTitle(int jobTitleId)
        {
            //kalder metode fra jobtitledatahandler objekt der returnere jobtitel på basis af id
            return await jobTitleDH.GetJobTitle(jobTitleId);
        }
    }
}
