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
    [Route("api/student-teacher-project")]
    public class TeacherProjectController : BaseController
    {
        private IWebHostEnvironment _env;
        private ITeacherProjectBusiness _teacherProjectBUS;
        public TeacherProjectController(ICacheProvider redis, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env,
            ITeacherProjectBusiness teacherProjectBUS) : base(redis, configuration, httpContextAccessor)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _teacherProjectBUS = teacherProjectBUS;
        }
        [Route("search")]
        [HttpPost]
        public async Task<ResponseListMessage<List<TeacherProjectModel>>> Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseListMessage<List<TeacherProjectModel>>();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var course_id_rcd = formData.Keys.Contains("selectedSubject") ? Convert.ToString(formData["selectedSubject"]) : "";
                var class_id_rcd = formData.Keys.Contains("class_id_rcd") ? Convert.ToString(formData["class_id_rcd"]) : "";

                long total = 0;
                var data = await Task.FromResult(_teacherProjectBUS.Search(page, pageSize, 
                    out total, course_id_rcd, class_id_rcd));
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