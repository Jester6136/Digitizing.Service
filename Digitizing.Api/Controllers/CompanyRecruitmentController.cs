using System;
using Library.Common.Response;
using Library.Common.Message;
using Library.Common.Helper;
using Microsoft.AspNetCore.Mvc;
using Library.DataModel;
using Library.BusinessLogicLayer;
using Microsoft.AspNetCore.Hosting;
using Library.Common.Caching;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Digitizing.Api.Cms.Controllers
{
    [Route("api/company-recruitment")]
    public class CompanyRecruitmentController : BaseController
    {
        private IWebHostEnvironment _env;
        private ICompanyRecruitmentBusiness _companyrecruitmentBUS;
        public CompanyRecruitmentController(ICacheProvider redis, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env,
            ICompanyRecruitmentBusiness companyrecruitmentBUS) : base(redis, configuration, httpContextAccessor)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _companyrecruitmentBUS = companyrecruitmentBUS;
        }

        [Route("search")]
        [HttpPost]
        public async Task<ResponseListMessage<List<PreCompanyRecruitmentModel>>> Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseListMessage<List<PreCompanyRecruitmentModel>>();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var student_rcd = CurrentUserName;
                var company_rcd = formData.Keys.Contains("company_rcd") ? Convert.ToString(formData["company_rcd"]) : "";
                var recruitment_job = formData.Keys.Contains("recruitment_job") ? Convert.ToString(formData["recruitment_job"]) : "";
                long total = 0;
                var data = await Task.FromResult(_companyrecruitmentBUS.Search(page, pageSize, out total,student_rcd, company_rcd, recruitment_job));
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;

            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }

        [Route("get-dropdown")]
        [HttpGet]
        public async Task<ResponseMessage<IList<DropdownOptionModel>>> GetListDropdown()
        {
            var response = new ResponseMessage<IList<DropdownOptionModel>>();
            try
            {
                response.Data = await Task.FromResult(_companyrecruitmentBUS.GetListDropdown());
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<ResponseMessage<CompanyRecruitmentModel>> GetById(Guid id)
        {
            var response = new ResponseMessage<CompanyRecruitmentModel>();
            try
            {
                response.Data = await Task.FromResult(_companyrecruitmentBUS.GetById(id));
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }
    }
}
