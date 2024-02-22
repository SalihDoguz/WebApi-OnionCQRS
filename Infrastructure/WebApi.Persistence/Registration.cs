﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Persistence.Context;

namespace WebApi.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
