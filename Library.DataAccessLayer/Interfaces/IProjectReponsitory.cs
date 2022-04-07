using System;
using System.Collections.Generic;
using Library.DataModel;
namespace Library.DataAccessLayer
{
    public partial interface IProjectReponsitory
    {
        ProjectModel GetProjectInfo(Guid student_project_id);
        ReportModel GetReport(Guid student_project_register_id);
        List<ProjectRegisterModel> Search(int pageIndex, int pageSize
      , out long total, string student_rcd);
        List<ProjectRegisterModel> SearchMember(int pageIndex, int pageSize
     , out long total, Guid student_project_id);
        ProjectRegisterModel GetById(Guid student_project_register_id);
        bool Create(ProjectRegisterModel register);
        bool CreateMember(ProjectRegisterModel register);
        bool Update(ProjectRegisterModel register);
        bool Delete(ProjectRegisterModel register);
    }
}