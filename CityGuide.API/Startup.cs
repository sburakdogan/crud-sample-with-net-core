using CityGuide.API.Validators;
using CityGuide.Domain;
using CityGuide.Domain.Contracts;
using CityGuide.Domain.Mapster;
using CityGuide.Exc;
using CityGuide.Repository;
using CityGuide.Repository.Contracts;
using CityGuide.Repository.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace CityGuide.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value);

            services.AddDbContext<CityGuideContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver() { NamingStrategy = new CamelCaseNamingStrategy() });
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddTransient<FluentValidator>();

            #region Repos

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ICitiesRepository, CitiesRepository>();
            services.AddScoped<ITownsRepository, TownsRepository>();

            #endregion

            #region Operations

            services.AddScoped<IAuthOperations, AuthOperations>();
            services.AddScoped<ICitiesOperations, CitiesOperations>();
            services.AddScoped<ITownsOperations, TownsOperations>();

            #endregion

            services.AddSingleton<IMapper, Mapper>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "City Guide API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<CustomExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "City Guide API v1.0");
            });
        }
    }
}
