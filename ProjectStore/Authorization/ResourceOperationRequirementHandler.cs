using Microsoft.AspNetCore.Authorization;
using ProjectStore.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectStore.Authorization
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Product>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Product product)
        {
            if (requirement.ResourceOperation == ResourceOperation.Read)
            { 
                context.Succeed(requirement);
            }
            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (product.CreatedByUserId == int.Parse(userId)) 
            {
                context.Succeed(requirement);
            } 
            return Task.CompletedTask;
        }
    }
}
