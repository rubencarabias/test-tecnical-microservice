using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Common
{
    public static class MinimalApiHelper
    {
        public static IResult ToMinimalApiResult(this IActionResult actionResult)
        {
            return actionResult switch
            {
                OkObjectResult okObjectResult => Results.Ok(okObjectResult.Value),
                BadRequestObjectResult badRequestObjectResult => Results.BadRequest(badRequestObjectResult.Value),
                NotFoundObjectResult notFoundObjectResult => Results.NotFound(notFoundObjectResult.Value),
                ObjectResult objectResult => Results.Ok(objectResult.Value),
                StatusCodeResult statusCodeResult => Results.StatusCode(statusCodeResult.StatusCode),
                _ => throw new InvalidOperationException("Unsupported action result type."),
            };
        }
    }
}
