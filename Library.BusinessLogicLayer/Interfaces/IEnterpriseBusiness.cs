using System;
using System.Collections.Generic;
using Library.DataModel;

namespace Library.BusinessLogicLayer
{
    public partial interface IEnterpriseBusiness
    {
        EnterpriseModel GetById(Guid? id);
    }
}