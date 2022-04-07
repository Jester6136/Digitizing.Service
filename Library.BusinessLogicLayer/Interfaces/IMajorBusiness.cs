using System;
using System.Collections.Generic;
using Library.DataModel;

namespace Library.BusinessLogicLayer
{
    public partial interface IMajorBusiness
    {
        MajorModel GetById(Guid majors_id);
    }
}