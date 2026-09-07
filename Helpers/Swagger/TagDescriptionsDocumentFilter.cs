using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace APISmartCity.Helpers
{
    public class TagDescriptionsDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new List<OpenApiTag> {
            new OpenApiTag { Name = "Authentication.System", Description = "Browse/manage the product catalog" },
            new OpenApiTag { Name = "Microservice.Category.Crowns", Description = "Danh mục tán cây" }
        };
        }
    }
}