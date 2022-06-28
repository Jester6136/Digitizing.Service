using System.Collections.Generic;
using Library.DataModel;
namespace Library.BusinessLogicLayer
{
    public partial interface IJobCandidateBusiness
    {
        bool Create(JobCandidateModel model);
        bool Update(JobCandidateModel model);
        bool Delete(JobCandidateModel model);
        bool UpdateReportSrc(JobCandidateModel model);
        JobCandidateModel GetById(string student_rcd);
    }
}
