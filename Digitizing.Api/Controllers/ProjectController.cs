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
    //[Route("api/student-project")]
    //public class ProjectController : BaseController
    //{
        //private IWebHostEnvironment _env;
        //private IProjectBusiness _projectBUS;
        //public ProjectController(ICacheProvider redis, IConfiguration configuration,
        //    IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env,
        //    IProjectBusiness projectBUS) : base(redis, configuration, httpContextAccessor)
        //{
        //    _env = env ?? throw new ArgumentNullException(nameof(env));
        //    _projectBUS = projectBUS;
        //}
        //[Route("search")]
        //[HttpPost]
        //public async Task<ResponseListMessage<List<ProjectRegisterModel>>> Search([FromBody] Dictionary<string, object> formData)
        //{
        //    var response = new ResponseListMessage<List<ProjectRegisterModel>>();
        //    try
        //    {
        //        var page = int.Parse(formData["page"].ToString());
        //        var pageSize = int.Parse(formData["pageSize"].ToString());
        //        var student_rcd = formData.Keys.Contains("student_rcd") ? Convert.ToString(formData["student_rcd"]) : "";

        //        long total = 0;
        //        var data = await Task.FromResult(_projectBUS.Search(page, pageSize,
        //            out total, student_rcd));
        //        response.TotalItems = total;
        //        response.Data = data;
        //        response.Page = page;
        //        response.PageSize = pageSize;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.MessageCode = ex.Message;
        //    }
        //    return response;
        //}
        //[Route("search-member")]
        //[HttpPost]
        //public async Task<ResponseListMessage<List<ProjectRegisterModel>>> SearchMember([FromBody] Dictionary<string, object> formData)
        //{
        //    var response = new ResponseListMessage<List<ProjectRegisterModel>>();
        //    try
        //    {
        //        var page = int.Parse(formData["page"].ToString());
        //        var pageSize = int.Parse(formData["pageSize"].ToString());
        //        Guid student_project_id = formData.Keys.Contains("student_project_id") ? Guid.Parse(formData["student_project_id"].ToString()) : new Guid();

        //        long total = 0;
        //        var data = await Task.FromResult(_projectBUS.SearchMember(page, pageSize,
        //            out total, student_project_id));
        //        response.TotalItems = total;
        //        response.Data = data;
        //        response.Page = page;
        //        response.PageSize = pageSize;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.MessageCode = ex.Message;
        //    }
        //    return response;
        //}
        //[Route("get-by-id/{id}")]
        //[HttpGet]
        //public async Task<ResponseMessage<ProjectRegisterModel>> GetById(Guid id)
        //{
        //    var response = new ResponseMessage<ProjectRegisterModel>();
        //    try
        //    {
        //        response.Data = await Task.FromResult(_projectBUS.GetById(id));
        //    }
        //    catch (Exception ex)
        //    {
        //        response.MessageCode = ex.Message;
        //    }
        //    return response;
        //}
        //[Route("create-project")]
        //[HttpPost]
        //public async Task<ResponseMessage<ProjectRegisterModel>> CreateProject(
        //    [FromBody] ProjectRegisterModel register)
        //{
        //    var response = new ResponseMessage<ProjectRegisterModel>();
        //    try
        //    {
        //        Console.WriteLine(register);
        //        register.created_by_user_id = CurrentUserId;
        //        var resultBUS = await Task.FromResult(_projectBUS.Create(register));
        //        if (resultBUS)
        //        {
        //            response.Data = register;
        //            response.MessageCode = MessageCodes.CreateSuccessfully;
        //        }
        //        else
        //        {
        //            response.MessageCode = MessageCodes.CreateFail;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        response.MessageCode = ex.Message;
        //    }
        //    return response;
        //}
        //[Route("create-member")]
        //[HttpPost]
        //public async Task<ResponseMessage<ProjectRegisterModel>> CreateMember(
        //    [FromBody] ProjectRegisterModel register)
        //{
        //    var response = new ResponseMessage<ProjectRegisterModel>();
        //    try
        //    {
        //        Console.WriteLine(register);
        //        register.created_by_user_id = CurrentUserId;
        //        var resultBUS = await Task.FromResult(_projectBUS.CreateMember(register));
        //        if (resultBUS)
        //        {
        //            response.Data = register;
        //            response.MessageCode = MessageCodes.CreateSuccessfully;
        //        }
        //        else
        //        {
        //            response.MessageCode = MessageCodes.CreateFail;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        response.MessageCode = ex.Message;
        //    }
        //    return response;
        //}
        //[Route("update-project")]
        //[HttpPost]
        //public async Task<ResponseMessage<ProjectRegisterModel>> UpdateProject([FromBody] ProjectRegisterModel model)
        //{
        //    var response = new ResponseMessage<ProjectRegisterModel>();
        //    try
        //    {
        //        model.lu_user_id = CurrentUserId;
        //        var resultBUS = await Task.FromResult(_projectBUS.Update(model));
        //        if (resultBUS)
        //        {
        //            response.Data = model;
        //            response.MessageCode = MessageCodes.UpdateSuccessfully;
        //        }
        //        else
        //            response.MessageCode = MessageCodes.UpdateFail;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.MessageCode = ex.Message;
        //    }
        //    return response;
        //}
        //[Route("delete-project")]
        //[HttpPost]
        //public async Task<ResponseListMessage<ProjectRegisterModel>> DeleteProject([FromBody] ProjectRegisterModel model)
        //{
        //    var response = new ResponseListMessage<ProjectRegisterModel>();
        //    try
        //    {
        //        model.lu_user_id = CurrentUserId;
        //        var resultBUS = await Task.FromResult(_projectBUS.Delete(model));
        //        if (resultBUS)
        //        {
        //            response.Data = model;
        //            response.MessageCode = MessageCodes.DeleteSuccessfully;
        //        }
        //        else
        //            response.MessageCode = MessageCodes.DeleteFail;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.MessageCode = ex.Message;
        //    }
        //    return response;
        //}

    //}
}