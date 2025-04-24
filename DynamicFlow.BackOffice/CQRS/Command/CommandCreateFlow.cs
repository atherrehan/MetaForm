using DynamicFlow.BackOffice.DbContext;
using DynamicFlow.BackOffice.DBOs;
using DynamicFlow.BackOffice.Models.Generic;
using MediatR;

namespace DynamicFlow.BackOffice.CQRS.Command
{
    internal class CommandCreateFlow(IDbContext _dbContext) : IRequestHandler<CreateFlowRequestDbo, GenericResponse>//Yes
    {
        public async Task<GenericResponse> Handle(CreateFlowRequestDbo request, CancellationToken cancellationToken)
        {
            var response = await FlowDbo(request);
            return response;
        }
        private async Task<GenericResponse> FlowDbo(CreateFlowRequestDbo requestDbo)
        {
            var response = await _dbContext.ExecuteSingleReturn<GenericResponse>("usp_create_flow", "", requestDbo);
            return response;
        }
    }
}
