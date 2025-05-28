using ClockTos.Domain.Entities;

namespace ClockTos.Application.Abstractions.IRepositories
{
    public interface ICollegeRepository
    {
        Task<int> AddCollege(Colleges model);


        Task<IEnumerable< Colleges>> GetAllColleges();
    }
}
