using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApiModulum.Models;
using Microsoft.OpenApi.Models;

namespace WebApiModulum.Filters;
public class AddRequiredHeaderParameter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        List<Parameter> parameters = new List<Parameter>();
        if (parameters == null)
        {
            parameters = new List<Parameter>();
        }

        parameters.Add
        (
            new Parameter()
            {
                name = "Authorization",
                @in = "header",
                type = "string",
                required = true
            }
        );
        parameters.Add
        (
            new Parameter()
            {
                name = "refreshtoken",
                @in = "header",
                type = "string",
                required = true
            }
        );
            
    }
}