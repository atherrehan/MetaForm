using DynamicFlow.BackOffice.Models.Generic;
using MediatR;

namespace DynamicFlow.BackOffice.DBOs;

public class GetCreateFlowRequestDbo : IRequest<GetCreateFlowResponseDbo>
{
}
public class GetCreateFlowResponseDbo
{
    public List<KeyValueGeneric>? dbConnection { get; set; }
    public List<KeyValueGeneric>? button { get; set; }

}
public class CreateFlowRequestDbo : IRequest<GenericResponse>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int? ConnectionId { get; set; }
    public string Procedure { get; set; } = string.Empty;
    public int? ButtonId { get; set; }
}

public class GetAllProcedureRequestDbo : IRequest<List<KeyValueStringGeneric>>
{
    public int? Id { get; set; }
}
