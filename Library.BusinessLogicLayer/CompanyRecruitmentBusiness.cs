using System;
using System.Collections.Generic;
using Library.DataModel;
using Library.DataAccessLayer;
using System.Linq;
using System.Data;

namespace Library.BusinessLogicLayer
{
    public partial class CompanyRecruitmentBusiness: ICompanyRecruitmentBusiness
    {
        private ICompanyRecruitmentReponsitory _res;
        public CompanyRecruitmentBusiness(ICompanyRecruitmentReponsitory res)
        {
            _res = res;
        }

        public List<PreCompanyRecruitmentModel> Search(int pageIndex, int pageSize, out long total,string student_rcd, string company_rcd, string recruitment_job)
        {
            return _res.Search(pageIndex, pageSize, out total,student_rcd, company_rcd, recruitment_job);
        }
        public List<DropdownOptionModel> GetListDropdown()
        {
            var result = _res.GetListDropdown();
            return result == null ? null : result;
        }
        public CompanyRecruitmentModel GetById(Guid id)
        {
            return _res.GetById(id);
        }
    }
}
