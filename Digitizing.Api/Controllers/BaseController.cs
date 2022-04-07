using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Common;
using Library.Common.Helper;
using Library.Common.Caching;

namespace Digitizing.Api.Cms.Controllers
{
    public class BaseController : Controller
    {
        private static bool EnabledLanguageCaching;
        private int DefaultDatabase = 0;
        private char DefaultLanguage = 'l'; 
        protected ICacheProvider redisHelper;
        protected IHttpContextAccessor httpContextAccessor;
        protected IConfiguration configuration;
        public BaseController(ICacheProvider redis, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this.redisHelper = redis;
            this.httpContextAccessor = httpContextAccessor;
            this.configuration = configuration;
            EnabledLanguageCaching = bool.Parse(configuration["AppSettings:EnabledLanguageCaching"]);
        }
        private string GetHeaderValue(string key)
        {
            try
            {
                var result = Request.Headers.FirstOrDefault(x => x.Key == key).Value;
                if (!string.IsNullOrEmpty(result))
                {
                    return result;
                }
            }
            catch
            {

            }

            return null;
        }
        protected Guid CurrentUserId
        {
            get
            {
                var result = GetHeaderValue(MediaTypeHeader.UserId);
                return result == null ? Guid.Empty : Guid.Parse(result);
            }
        }
        protected string CurrentUserName
        {
            get
            {
                return GetHeaderValue(MediaTypeHeader.UserName);
            }
        }
        protected Guid CurrentFacilityId
        {
            get
            {
                var result = GetHeaderValue(MediaTypeHeader.Facility);
                return result == null ? Guid.Empty : Guid.Parse(result);
            }
        }
        protected char CurrentLanguage
        {
            get
            {
                var currentLanguage = GetHeaderValue(MediaTypeHeader.CurrentLanguage);
                return null == currentLanguage ? DefaultLanguage : Convert.ToChar(currentLanguage);
            }
            set
            {
                if (EnabledLanguageCaching)
                    redisHelper.Add(DefaultDatabase, CurrentUserId + "_" + CustomClaimTypes.Language, value);
            }
        }
        protected UserInfo RequestInternalSet()
        {
            return new UserInfo(CurrentUserId, CurrentUserName, CurrentFacilityId, HttpUtils.IpAddress(), HttpUtils.BrowserName(this.httpContextAccessor));
        }
    }
}
