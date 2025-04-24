using DynamicFlow.BackOffice.Models.DynamicFlow;
using DynamicFlow.BackOffice.Models.Generic;

namespace DynamicFlow.BackOffice.Services
{
    public interface IService
    {
        Task<GetCreateFlowViewModel> GetCreateFlow();

        Task<List<KeyValueGeneric>> GetSetupFlow();

        Task<GenericResponse> CreateFlow(CreateFlowViewModel request);

        Task<GenericResponse> SaveFlow(SaveFlowViewModel request);

        Task<List<KeyValueStringGeneric>> GetAllProcedure(GetAllProcedureViewModel request);

        Task<GetFlowPropertyViewModel> FlowProperty(GetProcedureViewModel request);

        Task<GenericResponse> DeleteFlow(GetAllProcedureViewModel request);


    }
}
