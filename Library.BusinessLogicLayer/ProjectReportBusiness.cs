using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.DataAccessLayer;
using System.Linq;
using System.Data;

namespace Library.BusinessLogicLayer
{
    public partial class ProjectReportBusiness : IProjectReportBusiness
    {
        private IProjectReportReponsitory _res;
        public ProjectReportBusiness(IProjectReportReponsitory res)
        {
            _res = res;
        }

        public bool Create(ProjectReportModel model)
        {
            return _res.Create(model);
        }

        public List<ProjectReportModel> Search(int pageIndex, int pageSize
                  , out long total, string project_type, string student_rcd)
        {
            return _res.Search(pageIndex, pageSize, out total,project_type,student_rcd);
        }

        public bool Update(ProjectReportModel model)
        {
            return _res.Update(model);
        }
    }
}
