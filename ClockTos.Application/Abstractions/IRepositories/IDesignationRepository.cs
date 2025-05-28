using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClockTos.Domain.Entities;

namespace ClockTos.Application.Abstractions.IRepositories
{
    public interface IDesignationRepository:IBaseRepository<Designations>
    {
        Task<int> AddDesignation(Designations model);

        Task<IEnumerable< Designations>> GetAllDesignations();
    }
}
