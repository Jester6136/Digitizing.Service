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
using System.IO;

namespace Digitizing.Api.Cms.Controllers
{
    [Route("api/project_report")]
    public class ProjectReportController : BaseController
    {
        private IWebHostEnvironment _env;
        private IProjectReportBusiness _projectreportBUS;
        public ProjectReportController(ICacheProvider redis, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env,
            IProjectReportBusiness projectreportBUS) : base(redis, configuration, httpContextAccessor)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _projectreportBUS = projectreportBUS;
        }


        [Route("search")]
        [HttpPost]
        public async Task<ResponseListMessage<List<ProjectReportModel>>> Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseListMessage<List<ProjectReportModel>>();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var student_rcd = CurrentUserName;
                var project_type = formData.Keys.Contains("project_type") ? Convert.ToString(formData["project_type"]) : "";
                long total = 0;
                var data = await Task.FromResult(_projectreportBUS.Search(page, pageSize, out total, project_type,student_rcd));
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


        [Route("create")]
        [HttpPost]
        public async Task<ResponseMessage<ProjectReportModel>> Create([FromBody] ProjectReportModel model)
        {
            var response = new ResponseMessage<ProjectReportModel>();
            try
            {
                model.student_rcd = CurrentUserName;
                model.created_by_user_id = CurrentUserId;
                var resultBUS = await Task.FromResult(_projectreportBUS.Create(model));
                if (resultBUS)
                {
                    response.Data = model;
                    response.MessageCode = MessageCodes.CreateSuccessfully;
                }
                else
                {
                    response.MessageCode = MessageCodes.CreateFail;
                }

            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }

        [Route("update")]
        [HttpPost]
        public async Task<ResponseMessage<ProjectReportModel>> Update([FromBody] ProjectReportModel model)
        {
            var response = new ResponseMessage<ProjectReportModel>();
            try
            {
                model.lu_user_id = CurrentUserId;
                var resultBUS = await Task.FromResult(_projectreportBUS.Update(model));
                if (resultBUS)
                {
                    response.Data = model;
                    response.MessageCode = MessageCodes.CreateSuccessfully;
                }
                else
                {
                    response.MessageCode = MessageCodes.CreateFail;
                }

            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }
        [Route("upload")]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file.Length > 0 && file.FileName.Contains(".doc"))
                {
                    var filename = file.FileName;
                    var webRoot = _env.ContentRootPath;
                    var filePath = Path.Combine(webRoot + "/Upload/", filename);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return Ok(new { MessageCodes.UpdateSuccessfully });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return Ok(new { MessageCodes.UpdateSuccessfully });
            }
        }
    }
}