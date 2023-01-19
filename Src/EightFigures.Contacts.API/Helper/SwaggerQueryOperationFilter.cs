using Microsoft.OpenApi.Models;
using System.Runtime.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace EightFigures.Contacts.API.Helper
{
    public class SwaggerQueryOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            context.ApiDescription.ParameterDescriptions
                .Where(d => d.Source.Id == "Query").ToList()
                .ForEach(param =>
                {
                    var toIgnore =
                        ((DefaultModelMetadata)param.ModelMetadata)
                        .Attributes.PropertyAttributes
                        ?.Any(x => x is IgnoreDataMemberAttribute);

                    var toRemove = operation.Parameters
                        .SingleOrDefault(p => p.Name == param.Name);

                    if (toIgnore ?? false)
                        operation.Parameters.Remove(toRemove);
                });
        }
    }
}
