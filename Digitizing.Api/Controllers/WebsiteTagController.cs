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
    [Route("api/website-tag")]
    public class WebsiteTagController : BaseController
    {
        private IWebHostEnvironment _env;
        private IWebsiteTagBusiness _websitetagBUS;
        public WebsiteTagController(ICacheProvider redis, IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env, IWebsiteTagBusiness websitetagBUS) : base(redis, configuration, httpContextAccessor)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _websitetagBUS = websitetagBUS;
        }

        [Route("create-website-tag")]
        [HttpPost]
        public async Task<ResponseMessage<WebsiteTagModel>> CreateWebsiteTag([FromBody] WebsiteTagModel model)
        {
            var response = new ResponseMessage<WebsiteTagModel>();
            try
            {
                model.created_by_user_id = CurrentUserId;
                var resultBUS = await Task.FromResult(_websitetagBUS.Create(model));
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

        [Route("update-website-tag")]
        [HttpPost]
        public async Task<ResponseMessage<WebsiteTagModel>> UpdateWebsiteTag([FromBody] WebsiteTagModel model)
        {
            var response = new ResponseMessage<WebsiteTagModel>();
            try
            {

                model.lu_user_id = CurrentUserId;
                var resultBUS = await Task.FromResult(_websitetagBUS.Update(model));
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

        [Route("search")]
        [HttpPost]
        public async Task<ResponseListMessage<List<WebsiteTagModel>>> Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseListMessage<List<WebsiteTagModel>>();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                var tag_name = formData.Keys.Contains("tag_name") ? Convert.ToString(formData["tag_name"]) : "";
                long total = 0;
                var data = await Task.FromResult(_websitetagBUS.Search(page, pageSize, CurrentLanguage, out total, tag_name));
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

        [Route("get-by-id/{id}")]
        [HttpGet]
        public async Task<ResponseMessage<WebsiteTagModel>> GetById(Guid? id)
        {
            var response = new ResponseMessage<WebsiteTagModel>();
            try
            {
                response.Data = await Task.FromResult(_websitetagBUS.GetById(id));
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }

        [Route("delete-website-tag")]
        [HttpPost]
        public async Task<ResponseListMessage<bool>> DeleteWebsiteTag([FromBody] List<string> items)
        {
            var response = new ResponseListMessage<bool>();
            try
            {
                var json_list_id = MessageConvert.SerializeObject(items.Select(ds => new { tag_id = ds }).ToList());
                var listItem = await Task.FromResult(_websitetagBUS.Delete(json_list_id, CurrentUserId));
                response.Data = listItem != null;
                response.MessageCode = MessageCodes.DeleteSuccessfully;
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
                response.Data = await Task.FromResult(_websitetagBUS.GetListDropdown(CurrentLanguage));
            }
            catch (Exception ex)
            {
                response.MessageCode = ex.Message;
            }
            return response;
        }


    }
}