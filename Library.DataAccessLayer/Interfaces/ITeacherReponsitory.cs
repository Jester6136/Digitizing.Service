using System;
using System.Collections.Generic;
using Library.DataModel;
namespace Library.DataAccessLayer
{
    public partial interface ITeacherReponsitory
    {
        TeacherModel GetById(string teacher_rcd);
    }
}