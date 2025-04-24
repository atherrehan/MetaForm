using DynamicFlow.Models.DTOs;
using DynamicFlow.Models.Exceptions;
using DynamicFlow.Models.Generic;
using Mapster;
using MediatR;
using Module.Dynamic.Core.DBOs;
using Module.Flow.Core.DBOs;

namespace Module.Dynamic.Core.Services
{
    public class DynamicService(IMediator _mediator) : IDynamicService
    {
        public async Task<DynamicFlowComponentResponseDto> GetFlowDetail(DynamicFlowComponentRequestDto requestDto)
        {
            var responseApi = new DynamicFlowComponentResponseDto();
            var requestDbo = requestDto.Adapt<DynaicFlowComponentRequestDbo>();
            var responseDbo = await _mediator.Send(requestDbo);
            if (responseDbo is null)
            {
                throw new NullModelException();
            }
            responseApi = BindFlowDto(responseDbo);
            return responseApi;
        }

        public async Task<List<GenericKeyValueResponseDto>> GetKeyValue(GenericKeyValueRequestDto requestDto)
        {
            var requestDbo = requestDto.Adapt<KeyValueRequestDbo>();
            var responseDbo = await _mediator.Send(requestDbo);
            var responseApi = responseDbo.Adapt<List<GenericKeyValueResponseDto>>();
            return responseApi;
        }

        public async Task<GenericResponseApi> SaveFlow(DynamicFlowComponentSaveRequestDto requestDto)
        {
            var requestDbo = requestDto.Adapt<DynamicFlowComponentSaveRequestDbo>();
            requestDbo.KeyValue = requestDto.parameterValue.Adapt<List<DynamicFlowComponentSaveKeyValueRequestDbo>>();
            var responseDbo = await _mediator.Send(requestDbo);
            if (responseDbo is null)
            {
                throw new NullModelException();
            }
            var responseApi = responseDbo.Adapt<GenericResponseApi>();
            return responseApi;
        }

        private static DynamicFlowComponentResponseDto BindFlowDto(DynaicFlowComponentResponseDbo responseDbo)
        {
            var response = new DynamicFlowComponentResponseDto();
            response.Flow = responseDbo.Flow.Adapt<DynamicFlowResponseDto>();
            response.Properties = responseDbo.Properties.Adapt<List<DynamicFlowComponentPropertiesResponseDto>>();
            return response;
        }

        public async Task<List<ApiUrl>> GetURL()
        {
            var requestDbo = new ApiUrlRequestDbo();

            var responseDbo = await _mediator.Send(requestDbo);
            if (responseDbo == null)
            {
                throw new NullModelException();
            }
            var responseApi = responseDbo.Adapt<List<ApiUrl>>();
            return responseApi;
        }
    }
}
