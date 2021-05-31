using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebApplication.Api.Infrastructure.Errors
{
    public static class Errors
    {
        public static ModelStateDictionary AddErrorToModelState(string code, string description, ModelStateDictionary modelState)
        {
            modelState.TryAddModelError(code, description);
            return modelState;
        }
    }
}