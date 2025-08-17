using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebAppPortalApi.Data.Database;
using MediatR;
using FluentValidation.AspNetCore;
using WebAppPortalApi.Data.Stores.Users;
using WebAppPortalApi.Data.Stores.RequestLogs;
using WebAppPortalApi.Data.Stores.EventLogs;

namespace WebAppPortalApi.Extensions
{
    public static class DataExtensions
    {
        public static WebApplicationBuilder AddDataExtensions(this WebApplicationBuilder builder)
        {
            //DB
            builder.Services.AddDbContext<DBContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //Stores
            builder.Services.AddScoped<IUserStore, UserStore>();

            builder.Services.AddScoped<IRequestLogStore, RequestLogStore>();
            builder.Services.AddScoped<IEventLogStore, EventLogStore>();



            return builder;
        }
    }
}
