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
    [Route("api/subject")]
    public class SubjectController : BaseController
    {
        private IWebHostEnvironment _env;
        private ISubjectBusiness _subjectBUS;
        public SubjectController(ICacheProvider redis, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env,
            ISubjectBusiness subjectBUS) : base(redis, configuration, httpContextAccessor)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _subjectBUS = subjectBUS;
        }
        [Route("get-dropdown/{student_project_type}")]
        [HttpGet]
        public async Task<ResponseMessage<IList<DropdownOptionModel>>> GetListDropdown(int student_project_type)
        {
            var response = new ResponseMessage<IList<DropdownOptionModel>>();
            try
            {
                response.Data = await Task.FromResult(_subjectBUS.GetListDropdown(CurrentLanguage, student_project_type));
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }
    }
}