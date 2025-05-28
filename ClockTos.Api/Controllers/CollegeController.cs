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
    public class CollegeController : ApiController
    {
        private readonly ICollegeService service;

        public CollegeController(ICollegeService service)
        {
            this.service = service;
        }


        [HttpPost]
        public async Task<IResult> AddCollege(CollegeRequest model)=>this.ApiResult(await  service.AddCollege(model));


        [HttpGet]
        public async Task<IResult> GetAllColleges()=>this.ApiResult(await service.GetAllColleges());


    }
}
