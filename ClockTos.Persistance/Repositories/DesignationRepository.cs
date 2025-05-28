using ClockTos.Application.Abstractions.IRepositories;
using ClockTos.Domain.Entities;
using ClockTos.Persistance.Data;

namespace ClockTos.Persistance.Repositories
{
    public class DesignationRepository : BaseRepositories<Designations>, IDesignationRepository
    {

        public DesignationRepository(ClockDbContext context):base(context)
        {
            
        }
        public Task<int> AddDesignation(Designations model)
        {
            string  Query= $@"Insert into Designations values(@id,@Acronym,@Name,@StaffType,@Priority,@RolesAndResponsibilities,@CollegeId,@createdOn)";
            return ExecuteAsync(Query, new
            {
                Id=model.Id,
                Acronym=model.Acronym,
                Name=model.Name,
                StaffType=model.StaffType,
                Priority=model.Priority,
                RolesAndResponsibilities=model.RolesAndResponsibilities,
                CollegeId=model.CollegeId,
                CreatedOn=model.CreatedOn,
            });
        }

        public async Task<IEnumerable<Designations>> GetAllDesignations()
        {
            string Query = $@"Select * From Designations";
            return await QueryAsync<Designations>(Query);
        }
    }
}
