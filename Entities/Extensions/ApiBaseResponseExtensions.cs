using Entities.Responses;

namespace Entities.Extensions
{
    public static class ApiBaseResponseExtensions
    {
        public static TResultType GetResult<TResultType>(this ApiBaseResponse apiBaseResponse) =>
        ((ApiOkResponse<TResultType>)apiBaseResponse).Result;
    }
}
