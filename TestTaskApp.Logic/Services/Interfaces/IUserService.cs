using TestTaskApp.Logic.AuxiliaryСlasses;
using TestTaskApp.Logic.Models;

namespace TestTaskApp.Logic.Services.Interfaces
{
    public interface IUserService
    {
        Task<PaginationResponse<UserDto>> GetAllWithPaginationAsync(PaginationRequest request);
        Task<UserDto> GetByIdAsync(int? userId);
        Task<List<string>> GetAllRolesByIdAsync(int? userId);
        Task AddNewRoleAsync(int? userId, string roleTitle);
        Task CreateAsync(UserDto userDto);
        Task UpdateAsync(UserDto userDto);
        Task DeleteAsync(int? userId);
    }
}
