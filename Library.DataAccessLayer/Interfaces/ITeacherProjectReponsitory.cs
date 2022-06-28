using System;
using System.Collections.Generic;
using Library.DataModel;
namespace Library.DataAccessLayer
{
    public partial interface ITeacherProjectReponsitory
    {
        List<TeacherProjectModel> Search(int pageIndex, int pageSize
            , out long total, string student_rcd,  int project_type);
    }
}