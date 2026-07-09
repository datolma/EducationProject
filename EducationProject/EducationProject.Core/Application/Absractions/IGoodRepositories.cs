using EducationProject.Core.Models;

namespace EducationProject.Core.Application.Absractions
{
    public interface IGoodRepositories
    {
        Task<List<Good>> GetAllAsync();
        Task<Good?> GetByIdAsync(int id);
        Task<Good> AddAsync(Good good);
        Task<Good> UpdateAsync(Good good);
        Task<bool> DeleteAsync(int id);
        Task<List<Good>> SearchByNameAsync(string name);
    }
}
