using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.DataAccessLayer;
using System.Linq;
using System.Data;

namespace Library.BusinessLogicLayer
{
    public partial class StudentBusiness : IStudentBusiness
    {
        private IStudentReponsitory _res;
        public StudentBusiness(IStudentReponsitory res)
        {
            _res = res;
        }
        public bool Update(StudentModel student)
        {
            return _res.Update(student);
        }
        public StudentModel GetById(string student_rcd)
        {
            return _res.GetById(student_rcd);
        }
        public List<DropdownOptionModel> GetDistricts(char lang, string provinces_rcd)
        {
            return _res.GetDistricts(lang, provinces_rcd);
        }
        public List<DropdownOptionModel> GetProvinces(char lang)
        {
            return _res.GetProvinces(lang);
        }
        public List<DropdownOptionModel> GetWards(char lang, string districts_rcd)
        {
            return _res.GetWards(lang, districts_rcd);
        }
    }
}