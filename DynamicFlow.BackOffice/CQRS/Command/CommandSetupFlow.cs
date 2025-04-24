using DynamicFlow.BackOffice.DbContext;
using DynamicFlow.BackOffice.DBOs;
using DynamicFlow.BackOffice.Models.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.Data;

namespace DynamicFlow.BackOffice.CQRS.Command
{
    internal class CommandSetupFlow(IDbContext _dbContext) : IRequestHandler<SetupFlowRequestDbo, GenericResponse>//Yes
    {
        public async Task<GenericResponse> Handle(SetupFlowRequestDbo request, CancellationToken cancellationToken)
        {
            var response = await FlowDbo(request);
            return response;
        }
        private async Task<GenericResponse> FlowDbo(SetupFlowRequestDbo requestDbo)
        {
            var dt = new DataTable();
            dt.Columns.Add("Parameter", typeof(string));
            dt.Columns.Add("PropertyTypeId", typeof(int));
            dt.Columns.Add("Script", typeof(string));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("ErrorMessage", typeof(string));
            dt.Columns.Add("IsHidden", typeof(bool));
            dt.Columns.Add("IsPreproperty", typeof(bool));
            dt.Columns.Add("IsRequired", typeof(bool));

            foreach (var property in requestDbo?.Properties ?? new List<SetupFlowPropertyDbo>())
            {
                if (property.IsPreproperty == false && property.IsHidden == false)
                {
                    DataRow drLabel = dt.NewRow();
                    drLabel["Parameter"] = string.Empty;
                    drLabel["PropertyTypeId"] = 10;
                    drLabel["Script"] = "";
                    drLabel["Title"] = property.Title;
                    drLabel["ErrorMessage"] = string.Empty;
                    drLabel["IsHidden"] = false;
                    drLabel["IsPreproperty"] = false;
                    drLabel["IsRequired"] = false;
                    dt.Rows.Add(drLabel);
                }

                DataRow dr = dt.NewRow();
                dr["Parameter"] = property.Parameter;
                dr["PropertyTypeId"] = property.PropertyTypeId;
                dr["Script"] = property.Script == null ? "" : property.Script;
                dr["Title"] = property.Title;
                dr["ErrorMessage"] = property.ErrorMessage;
                dr["IsHidden"] = property.IsHidden;
                dr["IsPreproperty"] = property.IsPreproperty;
                dr["IsRequired"] = property.IsRequired;
                dt.Rows.Add(dr);
            }
            var response = await _dbContext.ExecuteSingleReturn<GenericResponse>("ups_save_flow_Properties", "", new { FlowId = requestDbo?.FlowId, FlowProperties = dt });
            return response;
        }
    }
}
