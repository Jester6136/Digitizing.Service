using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.DataAccessLayer;
using System.Linq;
using System.Data;

namespace Library.BusinessLogicLayer
{
    public partial class ProjectRegisterBusiness : IProjectRegisterBusiness
    {
        private IProjectRegisterReponsitory _res;
        public ProjectRegisterBusiness(IProjectRegisterReponsitory res)
        {
            _res = res;
        }
        public bool Create(ProjectRegisterModel model)
        {
            return _res.Create(model);
        }
        public bool Update(ProjectRegisterModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(ProjectRegisterModel model)
        {
            return _res.Delete(model);
        }
        public ProjectRegisterModel GetById(string student_rcd, int project_type)
        {
            return _res.GetById(student_rcd,project_type);
        }
    }
}
