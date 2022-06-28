using System;
using System.Collections.Generic;
using Library.DataModel;

namespace Library.DataAccessLayer
{
    public partial interface IJobCandidateReponsitory
    {
        bool Create(JobCandidateModel model);
        bool Update(JobCandidateModel model);
        bool Delete(JobCandidateModel model);
        bool UpdateReportSrc(JobCandidateModel model);
        JobCandidateModel GetById(string student_rcd);
    }
}
