using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.DataAccessLayer;
using System.Linq;
using System.Data;

namespace Library.BusinessLogicLayer
{
    public partial class SubjectBusiness : ISubjectBusiness
    {
        private ISubjectReponsitory _res;
        public SubjectBusiness(ISubjectReponsitory res)
        {
            _res = res;
        }
        public SubjectModel GetById(string course_id_rcd)
        {
            return _res.GetById(course_id_rcd);
        }
        public List<DropdownOptionModel> GetListDropdown(char lang, int student_project_type)
        {
            var result = _res.GetListDropdown(lang, student_project_type);
            return result == null ? null : result;
        }
    }
}