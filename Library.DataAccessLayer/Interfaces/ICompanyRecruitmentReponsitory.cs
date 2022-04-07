using System;
using System.Collections.Generic;
using Library.DataModel;

namespace Library.DataAccessLayer
{
    public partial interface ICompanyRecruitmentReponsitory
    {
        List<PreCompanyRecruitmentModel> Search(int pageIndex, int pageSize
            , out long total, string company_rcd, string recruitment_job,string recruitment_title);
        List<DropdownOptionModel> GetListDropdown();

        CompanyRecruitmentModel GetById(Guid id);
    }
}
