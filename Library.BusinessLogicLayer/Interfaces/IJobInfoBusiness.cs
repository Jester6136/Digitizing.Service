using System;
using System.Collections.Generic;
using Library.DataModel;

namespace Library.BusinessLogicLayer
{
    public partial interface IJobInfoBusiness
    {
        List<JobInfoModel> Search(int pageIndex, int pageSize, char lang
        , out long total, string keyword, string provinces_rcd);

    }
}