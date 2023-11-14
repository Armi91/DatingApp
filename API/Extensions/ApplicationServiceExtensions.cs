﻿using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
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
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.Configure<CloudimarySettings>(config.GetSection("CloudinarySettings"));
        services.AddScoped<IPhotoService, PhotoService>();
        services.AddScoped<LogUserActivity>();
        services.AddScoped<ILikesRepository, LikesRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        return services;
    }
}
