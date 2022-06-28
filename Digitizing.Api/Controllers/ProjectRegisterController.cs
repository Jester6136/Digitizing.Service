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
    [Route("api/project_register")]
    public class ProjectRegisterController : BaseController
    {
        private IWebHostEnvironment _env;
        private IProjectRegisterBusiness _projectregisterBUS;
        public ProjectRegisterController(ICacheProvider redis, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env,
            IProjectRegisterBusiness projectregisterBUS) : base(redis, configuration, httpContextAccessor)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _projectregisterBUS = projectregisterBUS;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ResponseMessage<ProjectRegisterModel>> Create([FromBody] ProjectRegisterModel model)
        {
            var response = new ResponseMessage<ProjectRegisterModel>();
            try
            {
                model.student_rcd = CurrentUserName;
                model.created_by_user_id = CurrentUserId;
                var resultBUS = await Task.FromResult(_projectregisterBUS.Create(model));
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

        [Route("delete")]
        [HttpPost]
        public async Task<ResponseMessage<ProjectRegisterModel>> Delete([FromBody] ProjectRegisterModel model)
        {
            var response = new ResponseMessage<ProjectRegisterModel>();
            try
            {
                model.student_rcd = CurrentUserName;
                model.lu_user_id = CurrentUserId;
                var resultBUS = await Task.FromResult(_projectregisterBUS.Delete(model));
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

        [HttpGet]
        [Route("get-by-id")]
        public async Task<ResponseMessage<ProjectRegisterModel>> GetById(int project_type)
        {
            var response = new ResponseMessage<ProjectRegisterModel>();
            var student_rcd = CurrentUserName;
            try
            {
                response.Data = await Task.FromResult(_projectregisterBUS.GetById(student_rcd,project_type));
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }

        [Route("update")]
        [HttpPost]
        public async Task<ResponseMessage<ProjectRegisterModel>> Update([FromBody] ProjectRegisterModel model)
        {
            var response = new ResponseMessage<ProjectRegisterModel>();
            try
            {
                var student_rcd = CurrentUserName;
                model.lu_user_id = CurrentUserId;
                var resultBUS = await Task.FromResult(_projectregisterBUS.Update(model));
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
    }
}