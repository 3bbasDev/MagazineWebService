using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using JwtAuth;
using MagazineWebService.AuthFilterAPI;
using MagazineWebService.Data;
using MagazineWebService.DTO.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace MagazineWebService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Env { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }
        public static readonly ILoggerFactory MyLoggerFactory
                = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddDbContextPool<MagazineContext>(options =>
            {
                options.UseLoggerFactory(MyLoggerFactory);
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), config =>
                {
                    config.CommandTimeout(30);
                    config.EnableRetryOnFailure(3);
                });
            });
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });
            services.AddScoped<FilterAPI>();
            services.AddJwtAuth(c =>
            {
                c.HashKey = Encoding.UTF8.GetBytes(Configuration.GetSection("keys:hashKey").Value);
                c.ExpirationTime = TimeSpan.FromDays(365);
                List<string> lss = new List<string>();
                lss.Add("ADMIN");
                c.GetUserRolesAsyncFunc = async (object userID, HttpContext context) => await Task.FromResult(lss);
                c.GetUserPolicesAsyncFunc = (object userID, HttpContext context) => null;
                c.VerifyUserAsyncFunc =
                    async (object userID, DateTime iat, DateTime exp, string token, Dictionary<string, object> meta) =>
                        await Task.FromResult(true);
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(typeof(Program).Assembly))
                .AddXmlSerializerFormatters();

            services.Configure<ApiBehaviorOptions>(c => c.SuppressModelStateInvalidFilter = true);
            services.AddHttpClient();
        }


        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
