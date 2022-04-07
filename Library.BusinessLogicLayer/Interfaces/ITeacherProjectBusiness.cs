using System;
using System.Collections.Generic;
using Library.DataModel;

namespace Library.BusinessLogicLayer
{
    public partial interface ITeacherProjectBusiness
    {
        List<TeacherProjectModel> Search(int pageIndex, int pageSize
           , out long total, string course_id_rcd, string class_id_rcd);
    }
}