using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.DataAccessLayer;
using System.Linq;
using System.Data;

namespace Library.BusinessLogicLayer
{
    public partial class EnterpriseBusiness : IEnterpriseBusiness
    {
        private IEnterpriseReponsitory _res;
        public EnterpriseBusiness(IEnterpriseReponsitory res)
        {
            _res = res;
        }
        public EnterpriseModel GetById(Guid? id)
        {
            return _res.GetById(id);
        }
    }
}