using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ClockTos.Api.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected internal string RequestedUrl => Request.GetEncodedUrl();

        protected CreatedResult Create<T>(T obj)
        {
            return Created(RequestedUrl, obj);
        }
    }
}
