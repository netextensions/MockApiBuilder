using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NetExtensions
{
    public static class MockApiBuilderExtension
    {
        public static IServiceCollection AddMockApi<TContext, TAutoMapper, TMediatR>(this IServiceCollection services, string connectionString,
             string swaggerTitle = null,
            string swaggerDescription = null,
            string swaggerVersion = null)
            where TContext : DbContext, new()
        {
            services.AddSwashbuckle(swaggerTitle, swaggerDescription, swaggerVersion);
            services.AddControllers().AddNewtonsoftJson();
            services.AddSqlServerDb<TContext>(connectionString);
            services.AddAutoMapper(typeof(TAutoMapper).Assembly);
            services.AddMediatR(typeof(TMediatR).Assembly);
            return services;
        }
        public static IServiceCollection AddMockApi<TContext, TAutoMapperMediatR>(this IServiceCollection services, string connectionString,
            string swaggerTitle = null,
            string swaggerDescription = null,
            string swaggerVersion = null)
            where TContext : DbContext, new()
        {
            return services.AddMockApi<TContext, TAutoMapperMediatR, TAutoMapperMediatR>(connectionString, swaggerTitle, swaggerDescription, swaggerVersion);
        }

    }
}
