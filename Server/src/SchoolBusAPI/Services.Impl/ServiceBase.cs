using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
using System;
using System.Security.Claims;

namespace SchoolBusAPI.Services.Impl
{
    public abstract class ServiceBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDbAppContext _context;

        public ServiceBase(IHttpContextAccessor httpContextAccessor, DbAppContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            DbContext = context;
        }

        protected IDbAppContext DbContext { get; private set;  }
        protected HttpRequest Request
        {
            get { return _httpContextAccessor.HttpContext.Request; }
        }

        protected ClaimsPrincipal User
        {
            get { return _httpContextAccessor.HttpContext.User; }
        }

        /// <summary>
        /// Returns the current user ID
        /// </summary>
        /// <returns></returns>
        protected int? GetCurrentUserId()
        {
            int? result = null;
            
            try
            {
                string rawuid = User.FindFirst(SchoolBusAPI.Models.User.USERID_CLAIM).Value;
                result = int.Parse(rawuid);
            }
            catch (Exception e)
            {
                result = null;
            }
            return result;
        }

        protected OkObjectResult Ok(object value)
        {
            return new OkObjectResult(value);
        }
    }
}
