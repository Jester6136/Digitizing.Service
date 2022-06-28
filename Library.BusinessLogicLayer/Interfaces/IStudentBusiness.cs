
using System.Collections.Generic;
using Library.DataModel;

namespace Library.BusinessLogicLayer
{
    public partial interface IStudentBusiness
    {
        bool Update(StudentModel model);
        StudentModel GetById(string student_rcd);
        public List<DropdownOptionModel> GetDistricts(char lang, string provinces_rcd);
        public List<DropdownOptionModel> GetProvinces(char lang);
        public List<DropdownOptionModel> GetWards(char lang, string districts_rcd);
    }
}