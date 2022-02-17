using Masny.TimeTracker.Data.Contexts;
using Masny.TimeTracker.Data.Models;
using Masny.TimeTracker.Logic.Interfaces;
using Masny.TimeTracker.Logic.Managers;
using Masny.TimeTracker.Logic.Services;
using Masny.TimeTracker.WebApi.Middlewares;
using Masny.TimeTracker.WebApi.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Masny.TimeTracker.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            // Custom managers & services
            services.AddScoped(typeof(IRepositoryManager<>), typeof(RepositoryManager<>));
            services.AddScoped<IProjectManager, ProjectManager>();
            services.AddScoped<IRecordManager, RecordManager>();
            services.AddScoped<IJwtService, JwtService>();

            // Database context
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ApplicationConnection")));

            // Configure
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // Default microsoft & other services
            services.AddMemoryCache();
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.ExcludedMimeTypes = new[] { "application/json" };
                options.Providers.Add<GzipCompressionProvider>();
            });
            services.AddHttpContextAccessor();
            services.AddCors();
            services.AddControllers();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API",
                    Description = "TimeTracker API",
                    Contact = new OpenApiContact() { }
                });

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                config.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        securitySchema, new[] { "Bearer" }
                    }
                };
                config.AddSecurityRequirement(securityRequirement);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Masny.TimeTracker.WebApi v1"));
            }

            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseResponseCompression();

            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
