using System;
using System.Collections.Generic;
using Library.DataModel;
namespace Library.BusinessLogicLayer
{
    public partial interface IProjectReportBusiness
    {
        List<ProjectReportModel> Search(int pageIndex, int pageSize
                  , out long total, string project_type, string student_rcd);

        bool Create(ProjectReportModel model);
        bool Update(ProjectReportModel model);
    }
}
