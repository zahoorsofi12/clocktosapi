using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClockTos.Application.Abstractions.IRepositories;
using ClockTos.Application.Abstractions.IService;
using ClockTos.Application.RRModels;
using ClockTos.Application.Shared;
using ClockTos.Domain.Entities;

namespace ClockTos.Application.Services
{
    public class CollegeService : ICollegeService
    {
        private readonly ICollegeRepository repository;
        private readonly IMapper mapper;

        public CollegeService(ICollegeRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ApiResponse<CollegeResponse>> AddCollege(CollegeRequest model)
        {
            var college = mapper.Map<Colleges>(model);
            int returnValue=await repository.AddCollege(college);
            if(returnValue==0)
            {
                return ApiResponse<CollegeResponse>.ErrorResponse("there is some issue try after some time", ApiStatusCodes.Conflict);
            }
            return ApiResponse<CollegeResponse>.SuccessResponse(mapper.Map<CollegeResponse>(college), "success", ApiStatusCodes.OK);
        }

        public async Task<ApiResponse<IEnumerable<CollegeResponse>>> GetAllColleges()
        {

            var college = await repository.GetAllColleges();
            if(college is null)
            {
                return ApiResponse<IEnumerable<CollegeResponse>>.ErrorResponse("No Data Found", ApiStatusCodes.NoContent);
            }
            return ApiResponse<IEnumerable<CollegeResponse>>.SuccessResponse(college.Select(x => new CollegeResponse() { Id = x.Id, Name = x.Name, }));
        }
    }
}
