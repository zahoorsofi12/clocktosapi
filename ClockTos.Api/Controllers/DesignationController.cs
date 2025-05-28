using ClockTos.Api.Controllers.Common;
using ClockTos.Api.Utils;
using ClockTos.Application.Abstractions.IService;
using ClockTos.Application.RRModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClockTos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ApiController
    {
        private readonly IDesignationService service;

        public DesignationController(IDesignationService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IResult> GetAllDestintaions()=>this.ApiResult(await service.GetAllDestinations());

        [HttpPost]

        public async Task<IResult> AddDestinations(DesignationRequest model) => this.ApiResult(await service.AddDestination(model));
    }
}
