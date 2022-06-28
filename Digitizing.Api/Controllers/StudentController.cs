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
    [Route("api/student")]
    public class StudentController : BaseController
    {
        private IWebHostEnvironment _env;
        private IStudentBusiness _studentBUS;
        public StudentController(ICacheProvider redis, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env,
            IStudentBusiness studentBUS) : base(redis, configuration, httpContextAccessor)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _studentBUS = studentBUS;
        }
        [Route("update")]
        [HttpPost]
        public async Task<ResponseMessage<StudentModel>> UpdateStudent([FromBody] StudentModel model)
        {
            var response = new ResponseMessage<StudentModel>();
            try
            {
                model.lu_user_id = CurrentUserId;
                var resultBUS = await Task.FromResult(_studentBUS.Update(model));
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
        [Route("get-by-id")]
        [HttpGet]
        public async Task<ResponseMessage<StudentModel>> GetById()
        {
            var response = new ResponseMessage<StudentModel>();
            var student_rcd = CurrentUserName;
            try
            {
                response.Data = await Task.FromResult(_studentBUS.GetById(student_rcd));
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }


        [Route("get-provinces")]
        [HttpGet]
        public async Task<ResponseMessage<IList<DropdownOptionModel>>> GetProvinces()
        {
            var response = new ResponseMessage<IList<DropdownOptionModel>>();
            try
            {
                response.Data = await Task.FromResult(_studentBUS.GetProvinces(CurrentLanguage));
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }


        [Route("get-districts-by-id/{provinces_rcd}")]
        [HttpGet]
        public async Task<ResponseMessage<IList<DropdownOptionModel>>> GetDistricts(string provinces_rcd)
        {
            var response = new ResponseMessage<IList<DropdownOptionModel>>();
            try
            {
                response.Data = await Task.FromResult(_studentBUS.GetDistricts(CurrentLanguage, provinces_rcd));
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }
        [Route("get-wards-by-id/{districts_rcd}")]
        [HttpGet]
        public async Task<ResponseMessage<IList<DropdownOptionModel>>> GetWards(string districts_rcd)
        {
            var response = new ResponseMessage<IList<DropdownOptionModel>>();
            try
            {
                response.Data = await Task.FromResult(_studentBUS.GetWards(CurrentLanguage, districts_rcd));
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
                    using ( var fileStream = new FileStream(filePath, FileMode.Create))
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