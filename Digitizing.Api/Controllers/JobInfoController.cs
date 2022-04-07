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
    [Route("api/student-job-info")]
    public class JobInfoController : BaseController
    {
        private IWebHostEnvironment _env;
        private IJobInfoBusiness _jobInfoBUS;
        public JobInfoController(ICacheProvider redis, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env,
            IJobInfoBusiness jobInfoBUS) : base(redis, configuration, httpContextAccessor)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _jobInfoBUS = jobInfoBUS;
        }
        [Route("search")]
        [HttpPost]
        public async Task<ResponseListMessage<List<JobInfoModel>>> Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseListMessage<List<JobInfoModel>>();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var keyword = formData.Keys.Contains("keyword") ? Convert.ToString(formData["keyword"]) : "";
                var provinces_rcd = formData.Keys.Contains("provinces_rcd") ? Convert.ToString(formData["provinces_rcd"]) : "";

                long total = 0;
                var data = await Task.FromResult(_jobInfoBUS.Search(page, pageSize, 
                    CurrentLanguage, out total, keyword, provinces_rcd));
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
    }
}