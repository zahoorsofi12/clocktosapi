using System.Security.Principal;
using ClockTos.Application.Abstractions.IRepositories;
using ClockTos.Domain.Entities;
using ClockTos.Persistance.Data;

namespace ClockTos.Persistance.Repositories
{
    public class CollegeRepository:BaseRepositories<Colleges>, ICollegeRepository
    {
        public CollegeRepository(ClockDbContext context):base(context)
        {
            
        }

        public async Task<int> AddCollege(Colleges model)
        {
            string Query = $@"Insert into Colleges values(@id,@name,@createdOn)";
            return await ExecuteAsync(Query, new
            {
                Id=model.Id,
                Name=model.Name,
                CreatedOn=model.CreatedOn,
            });
        }

        public async Task<IEnumerable<Colleges>> GetAllColleges()
        {

            string Query = $@"Select * From Colleges";
            return await QueryAsync<Colleges>(Query);
        }
    }
}
