
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppPortalApi.Database.Extensions
{
    public static class DatabaseExtensions
    {
        public static WebApplicationBuilder AddDatabaseExtensions(this WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<DBContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            return builder;
        }
    }
}
