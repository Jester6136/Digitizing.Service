using System;
using System.Collections.Generic;
using Library.DataModel;
namespace Library.DataAccessLayer
{
    public partial interface ITeacherProjectReponsitory
    {
        List<TeacherProjectModel> Search(int pageIndex, int pageSize
           , out long total, string course_id_rcd, string class_id_rcd);
    }
}