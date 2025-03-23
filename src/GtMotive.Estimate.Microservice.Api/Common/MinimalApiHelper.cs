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
                OkObjectResult okObjectResult => Results.Json(new { data = okObjectResult.Value }),
                BadRequestObjectResult badRequestObjectResult => Results.BadRequest(new { error = badRequestObjectResult.Value }),
                NotFoundObjectResult notFoundObjectResult => Results.NotFound(new { error = notFoundObjectResult.Value }),
                ObjectResult objectResult => Results.Json(new { data = objectResult.Value }),
                StatusCodeResult statusCodeResult => Results.StatusCode(statusCodeResult.StatusCode),
                _ => throw new InvalidOperationException("Unsupported action result type."),
            };
        }
    }
}
