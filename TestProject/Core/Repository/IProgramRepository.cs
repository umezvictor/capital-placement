using TestProject.Models;

namespace TestProject.Repository
{


    public interface IProgramRepository
    {
        Task<IEnumerable<InternshipProgram>> GetAllAsync(string query);
        Task<InternshipProgram> GetAsync(string id);
        Task AddAsync(InternshipProgram program);
        Task UpdateAsync(string id, InternshipProgram program);
        Task DeleteAsync(string id);
       
       
    }
}
