using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.DataAccessLayer;
using System.Linq;
using System.Data;

namespace Library.BusinessLogicLayer
{
    public partial class MajorBusiness : IMajorBusiness
    {
        private IMajorReponsitory _res;
        public MajorBusiness(IMajorReponsitory res)
        {
            _res = res;
        }
        public MajorModel GetById(Guid majors_id)
        {
            return _res.GetById(majors_id);
        }
    }
}