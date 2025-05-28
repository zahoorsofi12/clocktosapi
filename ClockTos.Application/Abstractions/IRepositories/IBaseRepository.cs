using ClockTos.Domain.Entities;

namespace ClockTos.Application.Abstractions.IRepositories
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {

    }
}
