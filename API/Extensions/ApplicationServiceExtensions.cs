﻿using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<ITokenService, TokenService>();
        services.AddEndpointsApiExplorer();
        services.AddCors();
        return services;
    }
}
