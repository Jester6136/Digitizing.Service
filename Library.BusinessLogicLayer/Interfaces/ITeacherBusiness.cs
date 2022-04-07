using System;
using System.Collections.Generic;
using Library.DataModel;

namespace Library.BusinessLogicLayer
{
    public partial interface ITeacherBusiness
    {
        TeacherModel GetById(string teacher_rcd);
    }
}