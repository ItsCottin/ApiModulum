#pragma warning disable CS1591
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using ApiModulum.Models;
using Microsoft.OpenApi.Models;

namespace ApiModulum.Filters
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var requiredHeaderAttribute = context.MethodInfo.GetCustomAttributes(typeof(RequiredHeaderAttribute), false).FirstOrDefault() as RequiredHeaderAttribute;
            if (requiredHeaderAttribute != null && requiredHeaderAttribute.IsRequired)
            {
                if (operation.Parameters == null)
                {
                    operation.Parameters = new List<OpenApiParameter>();
                }

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Schema = new OpenApiSchema { Type = "string" },
                    Required = true
                });
            }
        }
    }
}