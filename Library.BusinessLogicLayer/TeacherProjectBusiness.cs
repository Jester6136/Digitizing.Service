using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.DataAccessLayer;
using System.Linq;
using System.Data;

namespace Library.BusinessLogicLayer
{
    public partial class TeacherProjectBusiness : ITeacherProjectBusiness
    {
        private ITeacherProjectReponsitory _res;
        public TeacherProjectBusiness(ITeacherProjectReponsitory res)
        {
            _res = res;
        }
        public List<TeacherProjectModel> Search(int pageIndex, int pageSize
            , out long total, string student_rcd, int project_type)
        {
            return _res.Search(pageIndex, pageSize, out total, student_rcd,project_type);
        }
    }
}