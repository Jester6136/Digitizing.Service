using System;
using System.Collections.Generic;
using Library.DataModel;

namespace Library.BusinessLogicLayer
{
    public partial interface ISubjectBusiness
    {
        List<DropdownOptionModel> GetListDropdown(char lang, int student_project_type);
        SubjectModel GetById(string course_id_rcd);

    }
}