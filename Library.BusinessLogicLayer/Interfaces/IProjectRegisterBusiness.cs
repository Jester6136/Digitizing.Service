using System;
using System.Collections.Generic;
using Library.DataModel;

namespace Library.BusinessLogicLayer
{
    public partial interface IProjectRegisterBusiness
    {
        bool Create(ProjectRegisterModel model);
        bool Update(ProjectRegisterModel model);
        bool Delete(ProjectRegisterModel model);
        ProjectRegisterModel GetById(string student_rcd, int project_type);
    }
}