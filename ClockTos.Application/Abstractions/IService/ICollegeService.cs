using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockTos.Application.RRModels;
using ClockTos.Application.Shared;

namespace ClockTos.Application.Abstractions.IService
{
    public interface ICollegeService
    {
        Task<ApiResponse<CollegeResponse>> AddCollege(CollegeRequest model);

        Task<ApiResponse<IEnumerable<CollegeResponse>>> GetAllColleges();

    }
}
