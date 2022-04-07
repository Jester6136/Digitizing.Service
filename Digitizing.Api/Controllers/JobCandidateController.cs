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
    [Route("api/job-candidate")]
    public class JobCandidateController : BaseController
    {
        private IWebHostEnvironment _env;
        private IJobCandidateBusiness _jobcandidateBUS;
        public JobCandidateController(ICacheProvider redis, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor, IWebHostEnvironment env,
            IJobCandidateBusiness jobcandidateBUS) : base(redis, configuration, httpContextAccessor)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _jobcandidateBUS = jobcandidateBUS;
        }

        [Route("create")]
        [HttpPost]
        public async Task<ResponseMessage<JobCandidateModel>> Create([FromBody] JobCandidateModel model)
        {
            var response = new ResponseMessage<JobCandidateModel>();
            try
            {
                model.created_by_user_id = CurrentUserId;
                var resultBUS = await Task.FromResult(_jobcandidateBUS.Create(model));
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
        public async Task<ResponseMessage<JobCandidateModel>> Update([FromBody] JobCandidateModel model)
        {
            var response = new ResponseMessage<JobCandidateModel>();
            try
            {

                model.lu_user_id = CurrentUserId;
                var resultBUS = await Task.FromResult(_jobcandidateBUS.Update(model));
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
