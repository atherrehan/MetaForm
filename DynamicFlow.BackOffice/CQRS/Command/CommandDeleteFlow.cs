using DynamicFlow.BackOffice.DbContext;
using DynamicFlow.BackOffice.DBOs;
using DynamicFlow.BackOffice.Models.Generic;
using MediatR;

namespace DynamicFlow.BackOffice.CQRS.Command
{
    internal class CommandDeleteFlow(IDbContext _dbContext) : IRequestHandler<DeleteFlowRequestDbo, GenericResponse>//Yes
    {
        public async Task<GenericResponse> Handle(DeleteFlowRequestDbo request, CancellationToken cancellationToken)
        {
            var response = await DeleteFlowDbo(request);
            return response;
        }
        private async Task<GenericResponse> DeleteFlowDbo(DeleteFlowRequestDbo requestDbo)
        {
            var response = await _dbContext.ExecuteSingleReturn<GenericResponse>("usp_delete_flow", "", requestDbo);
            return response;
        }
    }
}
