using System;
using System.Collections.Generic;
using Library.DataModel;

namespace Library.DataAccessLayer
{
    public partial interface IJobCandidateReponsitory
    {
        bool Create(JobCandidateModel model);
        bool Update(JobCandidateModel model);
    }
}
