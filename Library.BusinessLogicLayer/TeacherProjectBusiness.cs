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
           , out long total, string course_id_rcd, string class_id_rcd)
        {
            return _res.Search(pageIndex, pageSize, out total, course_id_rcd, class_id_rcd);
        }
    }
}