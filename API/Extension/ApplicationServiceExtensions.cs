
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using MediatR;
using Application.Activities;
using Application.Core;
using AutoMapper;

namespace API.Extension
{
    public static class ApplicationServiceExtensions
    {
       public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)  
       {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddCors();
            services.AddMediatR(typeof(List.Handler).Assembly);
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            return services;
       } 
    }
}