using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.DataAccessLayer;
using System.Linq;
using System.Data;

namespace Library.BusinessLogicLayer
{
    public partial class ProjectBusiness : IProjectBusiness
    {
        private IProjectReponsitory _res;
        public ProjectBusiness(IProjectReponsitory res)
        {
            _res = res;
        }
        public ReportModel GetReport(Guid student_project_register_id)
        {
            return _res.GetReport(student_project_register_id);
        }
        public ProjectModel GetProjectInfo(Guid student_project_id)
        {
            return _res.GetProjectInfo(student_project_id);
        }
        public List<ProjectRegisterModel> Search(int pageIndex, int pageSize
           , out long total, string student_rcd)
        {
            return _res.Search(pageIndex, pageSize, out total, student_rcd);
        }
        public List<ProjectRegisterModel> SearchMember(int pageIndex, int pageSize
      , out long total, Guid student_project_id)
        {
            return _res.SearchMember(pageIndex, pageSize, out total, student_project_id);
        }
        public ProjectRegisterModel GetById(Guid student_project_register_id)
        {
            return _res.GetById(student_project_register_id);
        }
        public bool Create(ProjectRegisterModel register)
        {
            return _res.Create(register);
        }
        public bool CreateMember(ProjectRegisterModel register)
        {
            return _res.CreateMember(register);
        }
        public bool Update(ProjectRegisterModel register)
        {
            return _res.Update(register);
        }
        public bool Delete(ProjectRegisterModel register)
        {
            return _res.Delete(register);
        }
        
    }
}