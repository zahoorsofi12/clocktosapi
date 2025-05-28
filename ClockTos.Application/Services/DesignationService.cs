using AutoMapper;
using ClockTos.Application.Abstractions.IRepositories;
using ClockTos.Application.Abstractions.IService;
using ClockTos.Application.RRModels;
using ClockTos.Application.Shared;
using ClockTos.Domain.Entities;

namespace ClockTos.Application.Services
{
    public class DesignationService : IDesignationService
    {
        private readonly IDesignationRepository repository;
        private readonly IMapper mapper;

        public DesignationService(IDesignationRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<ApiResponse<DesignationResponse>> AddDestination(DesignationRequest model)
        {
            var destination = mapper.Map<Designations>(model);
            int returnValue=await repository.AddDesignation(destination);   
            if(returnValue==0)
            {
                return ApiResponse<DesignationResponse>.ErrorResponse("there is some issue try after some time", ApiStatusCodes.Conflict);
            }
            return ApiResponse<DesignationResponse>.SuccessResponse(mapper.Map<DesignationResponse>(destination), "success", ApiStatusCodes.OK);
        }

        public async Task<ApiResponse<IEnumerable<DesignationResponse>>> GetAllDestinations()
        {
            var destinations = await repository.GetAllDesignations();
            if(destinations is null)
            {
                return ApiResponse<IEnumerable< DesignationResponse>>.ErrorResponse("No Data Found", ApiStatusCodes.NoContent);
            }
            return ApiResponse<IEnumerable<DesignationResponse>>.SuccessResponse(mapper.Map<IEnumerable< DesignationResponse>>(destinations),"success",ApiStatusCodes.OK);
        }
    }
}
