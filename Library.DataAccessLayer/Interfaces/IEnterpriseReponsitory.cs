using System;
using System.Collections.Generic;
using Library.DataModel;
namespace Library.DataAccessLayer
{
    public partial interface IEnterpriseReponsitory
    {
        EnterpriseModel GetById(Guid? id);

    }
}