using System;
using System.Collections.Generic;
using Library.DataModel;
namespace Library.DataAccessLayer
{
    public partial interface IJobInfoReponsitory
    {
        List<JobInfoModel> Search(int pageIndex, int pageSize, char lang
           , out long total, string keyword, string provinces_rcd);
    }
}