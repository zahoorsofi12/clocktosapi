using ClockTos.Application.Shared;
using System.Text.Json.Serialization;
using System.Text.Json;
using ClockTos.Api.Controllers.Common;

namespace ClockTos.Api.Utils
{
    public static class ResultExtension
    {
        public static IResult ApiResult<T>(this ApiController controller, ApiResponse<T> result)
        {
            return new CustomResult<T>(result);
        }
    }

    public class CustomResult<T> : IResult
    {
        public int StatusCode { get; }

        public ApiResponse<T> Value { get; }

        public CustomResult(ApiResponse<T> value)
        {
            StatusCode = value.Status;
            Value = value;
        }
        public Task ExecuteAsync(HttpContext httpContext)
        {
            httpContext.Response.StatusCode = StatusCode;
            httpContext.Response.ContentType = "application/json";

            var JsonSerializerSettings = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new JsonStringEnumConverter() }
            };

            var responseJson = JsonSerializer.Serialize(Value, JsonSerializerSettings);
            return httpContext.Response.WriteAsync(responseJson);

        }
    }
}
