using DynamicFlow.Models.DTOs;
using DynamicFlow.Models.Generic;

namespace DynamicFlow.API.Core.Service.Interfaces
{
    public interface IDynamicService
    {
        Task<List<ApiUrl>> GetURL();

        Task<DynamicFlowComponentResponseDto> GetFlowDetail(DynamicFlowComponentRequestDto requestDto);

        Task<List<GenericKeyValueResponseDto>> GetKeyValue(GenericKeyValueRequestDto requestDto);

        Task<GenericResponseApi> SaveFlow(DynamicFlowComponentSaveRequestDto requestDto);
    }
}
