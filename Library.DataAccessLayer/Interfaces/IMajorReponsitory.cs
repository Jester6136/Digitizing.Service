using System;
using System.Collections.Generic;
using Library.DataModel;
namespace Library.DataAccessLayer
{
    public partial interface IMajorReponsitory
    {
        MajorModel GetById(Guid majors_id);
    }
}