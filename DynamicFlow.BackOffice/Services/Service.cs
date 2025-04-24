using DynamicFlow.BackOffice.DBOs;
using DynamicFlow.BackOffice.Models.DynamicFlow;
using DynamicFlow.BackOffice.Models.Generic;
using Mapster;
using MediatR;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DynamicFlow.BackOffice.Services
{
    public class Service(IMediator _mediator) : IService
    {

        public async Task<GetCreateFlowViewModel> GetCreateFlow()
        {
            var response = new GetCreateFlowViewModel();
            var requestDbo = new GetCreateFlowRequestDbo();
            var responseDbo = await _mediator.Send(requestDbo);
            response.dbConnection = responseDbo.dbConnection.Adapt<List<KeyValueGeneric>>();
            response.button = responseDbo.button.Adapt<List<KeyValueGeneric>>();
            return response;
        }

        public async Task<GenericResponse> CreateFlow(CreateFlowViewModel request)
        {
            var response = new GenericResponse();
            var requestDbo = request.Adapt<CreateFlowRequestDbo>();
            var responseDbo = await _mediator.Send(requestDbo);
            response = responseDbo.Adapt<GenericResponse>();
            return response;
        }

        public async Task<GetFlowPropertyViewModel> FlowProperty(GetProcedureViewModel request)
        {
            var response = new GetFlowPropertyViewModel();
            var getProcedureRequestDbo = request.Adapt<GetPropertyProcedureRequestDbo>();
            var getProcedureResponseDbo = await _mediator.Send(getProcedureRequestDbo);
            var getParameterRequestDbo = new GetParameterRequestDbo()
            {
                ConnectionString = getProcedureResponseDbo?.Connection?.Key ?? "",
                Procedure = getProcedureResponseDbo?.Connection?.Value ?? ""
            };
            var getParameterResponseDbo = await _mediator.Send(getParameterRequestDbo);
            getParameterResponseDbo.Parameter = getParameterResponseDbo?.Parameter?.Where(kv => kv.Key != "@Params").ToList();
            getParameterResponseDbo.Parameter = getParameterResponseDbo?.Parameter?.Where(kv => kv.Key != "@FlowId").ToList();
            var getCreatePropertyRequestDbo = new GetCreatePropertyRequestDbo();
            var getCreatePropertyResponseDbo = await _mediator.Send(getCreatePropertyRequestDbo);
            response.propertyType = getCreatePropertyResponseDbo.propertyType.Adapt<List<KeyValueGeneric>>();



            var dbScript = getParameterResponseDbo.Procedure.Where(f => !getCreatePropertyResponseDbo.dbScript.Any(e => e.Value == f.Value)).ToList();





            response.dbScript = dbScript.Adapt<List<KeyValueStringGeneric>>(); //getCreatePropertyResponseDbo.dbScript.Adapt<List<KeyValueGeneric>>();
            response.parameters = new List<KeyValueStringGeneric>();
            foreach (var item in getParameterResponseDbo?.Parameter ?? new List<KeyValueStringGeneric>())
            {
                KeyValueStringGeneric obj = new();
                obj.Key = item.Key;
                response.parameters.Add(obj);
            }
            if (getCreatePropertyResponseDbo is not null && getCreatePropertyResponseDbo.currentProperty is not null && getCreatePropertyResponseDbo.currentProperty.Any(x => x.FlowId == request.Id))
            {
                List<GetExistingPropertyViewModel> filteredList = getCreatePropertyResponseDbo.currentProperty
                    .Where(x => x.FlowId == request.Id)
                    .Select(x => new GetExistingPropertyViewModel
                    {
                        FlowId = x.FlowId,
                        PropertyTypeId = x.PropertyTypeId,
                        Script = x.Script,
                        Title = x.Title,
                        Parameter = x.Parameter,
                        ErrorMessage = x.ErrorMessage,
                        IsVisible = x.IsVisible,
                        IsPreproperty = x.IsPreproperty,
                        IsRequired = x.IsRequired
                    }).ToList();
                response.currentProperty = filteredList;
            }
            return response;
        }

        public async Task<List<KeyValueGeneric>> GetSetupFlow()
        {
            var response = new GetSetupFlowViewModel();
            var requestDbo = new GetSetupFlowRequestDbo();
            var responseDbo = await _mediator.Send(requestDbo);
            //response.flow = responseDbo.flow.Adapt<List<KeyValueGeneric>>();
            //response.property = responseDbo.property.Adapt<List<KeyValueGeneric>>();
            return responseDbo;
        }

        public async Task<GenericResponse> SaveFlow(SaveFlowViewModel request)
        {
            var response = new GenericResponse();
            var requestDbo = request.Adapt<SetupFlowRequestDbo>();
            var responseDbo = await _mediator.Send(requestDbo);
            response = responseDbo.Adapt<GenericResponse>();
            return response;
        }

        public async Task<List<KeyValueStringGeneric>> GetAllProcedure(GetAllProcedureViewModel request)
        {
            var response = new List<KeyValueStringGeneric>();
            var requestDbo = request.Adapt<GetAllProcedureRequestDbo>();
            var responseDbo = await _mediator.Send(requestDbo);
            response = responseDbo.Adapt<List<KeyValueStringGeneric>>();
            return response;
        }

        public async Task<GenericResponse> DeleteFlow(GetAllProcedureViewModel request)
        {
            var response = new GenericResponse();
            var requestDbo = request.Adapt<DeleteFlowRequestDbo>();
            var responseDbo = await _mediator.Send(requestDbo);
            response = responseDbo.Adapt<GenericResponse>();
            return response;
        }
    }
}
