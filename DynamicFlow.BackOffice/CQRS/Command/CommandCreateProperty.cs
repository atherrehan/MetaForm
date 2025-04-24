using DynamicFlow.BackOffice.DbContext;
using DynamicFlow.BackOffice.DBOs;
using DynamicFlow.BackOffice.Models.Generic;
using MediatR;

namespace DynamicFlow.BackOffice.CQRS.Command
{
    //internal class CommandCreateProperty(IDbContext _dbContext) : IRequestHandler<CreatePropertyRequestDbo, GenericResponse>
    //{
    //    public async Task<GenericResponse> Handle(CreatePropertyRequestDbo request, CancellationToken cancellationToken)
    //    {
    //        var response = await FlowDbo(request);
    //        return response;
    //    }
    //    private async Task<GenericResponse> FlowDbo(CreatePropertyRequestDbo requestDbo)
    //    {
    //        requestDbo.DataTypeId = requestDbo.DataTypeId == 0 ? null : requestDbo.DataTypeId;
    //        requestDbo.EventId = requestDbo.EventId == 0 ? null : requestDbo.EventId;
    //        requestDbo.ParentPropertyId = requestDbo.ParentPropertyId == 0 ? null : requestDbo.ParentPropertyId;
    //        requestDbo.ScriptId = requestDbo.ScriptId == 0 ? null : requestDbo.ScriptId;
    //        var response = await _dbContext.ExecuteSingleReturn<GenericResponse>("usp_create_property", "", requestDbo);
    //        return response;
    //    }
    //}
}
