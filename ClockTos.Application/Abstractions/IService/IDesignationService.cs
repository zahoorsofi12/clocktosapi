using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockTos.Application.RRModels;
using ClockTos.Application.Shared;

namespace ClockTos.Application.Abstractions.IService
{
    public interface IDesignationService
    {
        Task<ApiResponse<DesignationResponse>> AddDestination(DesignationRequest model);

        Task<ApiResponse<IEnumerable<DesignationResponse>>> GetAllDestinations();
    }
}
