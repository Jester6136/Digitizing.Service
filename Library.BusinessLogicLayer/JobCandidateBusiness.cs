using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.DataAccessLayer;
using System.Linq;
using System.Data;

namespace Library.BusinessLogicLayer
{
    public partial class JobCandidateBusiness : IJobCandidateBusiness
    {
        private IJobCandidateReponsitory _res;
        public JobCandidateBusiness(IJobCandidateReponsitory res)
        {
            _res = res;
        }

        public bool Create(JobCandidateModel model)
        {
            return _res.Create(model);
        }

        public bool Update(JobCandidateModel model)
        {
            return _res.Update(model);
        }
    }
}
