using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.DataAccessLayer;
using System.Linq;
using System.Data;

namespace Library.BusinessLogicLayer
{
    public partial class JobInfoBusiness : IJobInfoBusiness
    {
        private IJobInfoReponsitory _res;
        public JobInfoBusiness(IJobInfoReponsitory res)
        {
            _res = res;
        }
        public List<JobInfoModel> Search(int pageIndex, int pageSize, char lang
            , out long total, string keyword, string provinces_rcd)
        {
            return _res.Search(pageIndex, pageSize, lang, out total, keyword, provinces_rcd);
        }
    }
}