using DynamicFlow.BackOffice.Models;

namespace DynamicFlow.BackOffice.Repository.Interfaces
{
    public interface IRepositoryService
    {
        Task<List<KeyValueResponseDto>> GetKeyValue(KeyValueRequestDto requestDto);
    }
}
