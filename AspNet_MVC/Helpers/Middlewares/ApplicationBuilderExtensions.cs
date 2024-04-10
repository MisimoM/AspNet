﻿namespace Presentation.Helpers.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseUserSessionValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserSessionValidationMiddleware>();
        }
    }
}
