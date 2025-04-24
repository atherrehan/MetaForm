using DynamicFlow.Models.DTOs;
using DynamicFlow.Models.Generic;

namespace Module.Dynamic.Core.Services
{
    public interface IDynamicService
    {
        Task<List<ApiUrl>> GetURL();

        Task<DynamicFlowComponentResponseDto> GetFlowDetail(DynamicFlowComponentRequestDto requestDto);

        Task<List<GenericKeyValueResponseDto>> GetKeyValue(GenericKeyValueRequestDto requestDto);

        Task<GenericResponseApi> SaveFlow(DynamicFlowComponentSaveRequestDto requestDto);


    }
}
