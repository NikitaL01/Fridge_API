using AspNetCoreRateLimit;
using Contracts;
using Entities.DataTransferObjects;
using Filters.ActionFilters;
using FridgeAPI.Authentication;
using FridgeAPI.Extensions;
using FridgeAPI.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using Repository.DataShaping;
using System;
using System.IO;

namespace FridgeAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(),
                "/nlog.config"));

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();
            services.ConfigureIisIntegration();
            services.ConfigureLoggerService();
            services.ConfigureSlqContext(Configuration);
            services.ConfigureRepositoryManager();
            services.ConfigureVersioning();
            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<ValidateFridgeExistsAttribute>();
            services.AddScoped<ValidateFridgeModelForFridgeExistsAttribute>();
            services.AddScoped<IDataShaper<FridgeModelDto>, DataShaper<FridgeModelDto>>();
            services.AddScoped<ValidateMediaTypeAttribute>();
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<FridgeModelLinks>();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;

                //config.CacheProfiles.Add("120SecondsDuration",
                //    new CacheProfile { Duration = 120 });
            }).AddNewtonsoftJson()
            .AddXmlDataContractSerializerFormatters()
            .AddCustomCsvFormatter();

            //services.ConfigureResponseCaching();
            //services.AddHttpContextAccessor();
            //services.ConfigureHttpCacheHeaders();
            services.AddCustomMediaTypes();

            services.AddMemoryCache();
            services.ConfigureRateLimitingOptions();
            services.AddInMemoryRateLimiting();
            services.AddHttpContextAccessor();

            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJwt(Configuration);
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();

            services.ConfigureSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FridgeAPI v1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "FridgeAPI v2");
                });
            }
            else
            {
                app.UseHsts();
            }

            app.ConfigureExceptionHandler(logger);
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            //app.UseResponseCaching();
            //app.UseHttpCacheHeaders();

            app.UseIpRateLimiting();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

//https://code-maze.com/unit-testing-aspnetcore-web-api/
//https://www.thecodebuzz.com/unit-test-mock-actionfilter-asp-net-core-actionexecutingcontext-moq/
//https://stackoverflow.com/questions/62799045/how-do-i-unit-test-a-controller-that-is-decorated-with-the-servicefilterattribut
