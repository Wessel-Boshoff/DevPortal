using FluentValidation.Results;
using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Common.Models;
using WebAppPortalApi.Data.Database.Tables.log;

namespace WebAppPortalApi.Core.Mappers.Logs
{
    internal static class ErrorMapper
    {
        internal static List<Error> Map(this List<ValidationFailure> models) => models == default ? [] : [.. models.Select(c => c.Map())];

        internal static Error Map(this ValidationFailure model) => new() 
        { 
            Code = model.ErrorCode.MapCode(),
            Value = model.ErrorMessage
        };

        private static ErrorCode MapCode(this string? code)
        {
            return ErrorCode.Unknown;
        }
    }
}
