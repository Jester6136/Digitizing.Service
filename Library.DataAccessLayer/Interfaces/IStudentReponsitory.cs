using System;
using System.Collections.Generic;
using Library.DataModel;
namespace Library.DataAccessLayer
{
    public partial interface IStudentReponsitory
    {
        StudentModel GetById(string student_rcd);
        bool Update(StudentModel model);
        public List<DropdownOptionModel> GetDistricts(char lang, string provinces_rcd);
        public List<DropdownOptionModel> GetWards(char lang, string districts_rcd);

    }
}