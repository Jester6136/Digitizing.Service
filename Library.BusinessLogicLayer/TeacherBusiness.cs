using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.DataAccessLayer;
using System.Linq;
using System.Data;

namespace Library.BusinessLogicLayer
{
    public partial class TeacherBusiness : ITeacherBusiness
    {
        private ITeacherReponsitory _res;
        public TeacherBusiness(ITeacherReponsitory res)
        {
            _res = res;
        }
        public TeacherModel GetById(string teacher_rcd)
        {
            return _res.GetById(teacher_rcd);
        }
    }
}