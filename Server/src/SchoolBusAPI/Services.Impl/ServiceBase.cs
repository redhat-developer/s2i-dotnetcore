using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolBusAPI.Models;
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

        protected OkObjectResult Ok(object value)
        {
            return new OkObjectResult(value);
        }
    }
}
