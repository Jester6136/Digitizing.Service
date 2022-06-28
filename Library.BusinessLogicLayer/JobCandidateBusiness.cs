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
        public bool Delete(JobCandidateModel model)
        {
            return _res.Delete(model);
        }
        public JobCandidateModel GetById(string student_rcd)
        {
            return _res.GetById(student_rcd);
        }

        public bool UpdateReportSrc(JobCandidateModel model)
        {
            return _res.UpdateReportSrc(model);
        }
    }
}
