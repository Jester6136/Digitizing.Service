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
    [Route("api/student-recruitment-report-weekly")]
    public class StudentRecruitmentReportController : BaseController
    {
        private IWebHostEnvironment _env;
        private IStudentRecruitmentReportBusiness _studentrecruitmentreportBUS;
        public StudentRecruitmentReportController(ICacheProvider redis, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env,
            IStudentRecruitmentReportBusiness studentrecruitmentreportBUS) : base(redis, configuration, httpContextAccessor)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _studentrecruitmentreportBUS = studentrecruitmentreportBUS;
        }

        [Route("search")]
        [HttpPost]
        public async Task<ResponseListMessage<List<StudentRecruitmentReportModel>>> Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseListMessage<List<StudentRecruitmentReportModel>>();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var student_rcd = CurrentUserName;
                var report_week = formData.Keys.Contains("report_week") ? Convert.ToString(formData["report_week"]) : "";
                if(report_week == "")
                {
                    report_week = "1";
                }
                long total = 0;
                var data = await Task.FromResult(_studentrecruitmentreportBUS.Search(page, pageSize, out total, student_rcd, report_week));
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
                response.Data = await Task.FromResult(_studentrecruitmentreportBUS.GetListDropdown());
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<ResponseMessage<StudentRecruitmentReportModel>> GetById(int report_week, int report_day)
        {
            var response = new ResponseMessage<StudentRecruitmentReportModel>();
            var student_rcd = CurrentUserName;
            try
            {
                response.Data = await Task.FromResult(_studentrecruitmentreportBUS.GetById(student_rcd, report_week, report_day));
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("get-internship-process-evaluate-by-id")]
        public async Task<ResponseMessage<InternshipProcessEvaluateModel>> GetInternshipProcessEvaluateById(int report_week)
        {
            var response = new ResponseMessage<InternshipProcessEvaluateModel>();
            var student_rcd = CurrentUserName;
            try
            {
                response.Data = await Task.FromResult(_studentrecruitmentreportBUS.GetInternshipProcessEvaluateById(student_rcd, report_week));
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }

        [HttpGet]
        [Route("get-student-recruitment-report-by-id")]
        public async Task<ResponseMessage<StudentRecruitmentReportModel>> GetStudentRecuitmentReportById()
        {
            var response = new ResponseMessage<StudentRecruitmentReportModel>();
            var student_rcd = CurrentUserName;
            try
            {
                response.Data = await Task.FromResult(_studentrecruitmentreportBUS.GetStudentRecuitmentReportById(student_rcd));
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }

        [Route("update")]
        [HttpPost]
        public async Task<ResponseMessage<StudentRecruitmentReportModel>> Update([FromBody] StudentRecruitmentReportModel model)
        {
            var response = new ResponseMessage<StudentRecruitmentReportModel>();
            try
            {
                model.lu_user_id = CurrentUserId;
                var resultBUS = await Task.FromResult(_studentrecruitmentreportBUS.Update(model));
                if (resultBUS)
                {
                    response.Data = model;
                    response.MessageCode = MessageCodes.UpdateSuccessfully;
                }
                else
                {
                    response.MessageCode = MessageCodes.UpdateFail;
                }
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }

        [Route("update-report")]
        [HttpPost]
        public async Task<ResponseMessage<StudentRecruitmentReportModel>> UpdateReport([FromBody] StudentRecruitmentReportModel model)
        {
            var response = new ResponseMessage<StudentRecruitmentReportModel>();
            try
            {
                model.lu_user_id = CurrentUserId;
                var resultBUS = await Task.FromResult(_studentrecruitmentreportBUS.UpdateReport(model));
                if (resultBUS)
                {
                    response.Data = model;
                    response.MessageCode = MessageCodes.UpdateSuccessfully;
                }
                else
                {
                    response.MessageCode = MessageCodes.UpdateFail;
                }
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ResponseMessage<StudentRecruitmentReportModel>> Create([FromBody] StudentRecruitmentReportModel model)
        {
            var response = new ResponseMessage<StudentRecruitmentReportModel>();
            try
            {
                model.student_rcd = CurrentUserName;
                model.created_by_user_id = CurrentUserId;
                var resultBUS = await Task.FromResult(_studentrecruitmentreportBUS.Create(model));
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
                if (file.Length > 0)
                {
                    if (file.FileName.Contains(".doc"))
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
                else
                {
                    return Ok(new { MessageCodes.UpdateFail });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { MessageCodes.UpdateFail });
            }
        }
    }
}
