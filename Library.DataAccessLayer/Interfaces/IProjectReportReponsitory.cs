using System;
using System.Collections.Generic;
using Library.DataModel;

namespace Library.DataAccessLayer
{
    public partial interface IProjectReportReponsitory
    {
        List<ProjectReportModel> Search(int pageIndex, int pageSize
            , out long total,string project_type,string student_rcd);

        bool Create(ProjectReportModel model);

        bool Update(ProjectReportModel model);
    }
}
