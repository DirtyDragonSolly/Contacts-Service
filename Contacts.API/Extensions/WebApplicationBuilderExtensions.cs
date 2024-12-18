using AutoMapper;
using Contacts.Data;
using Contacts.Core.Abstractions;
using Contacts.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Contacts.Data.MappingProfiles;
using Contacts.Application.Services;
using Microsoft.OpenApi.Models;

namespace Contacts.API.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder ConfigureDIContainer(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Logging.ClearProviders();
            applicationBuilder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

            applicationBuilder.Services.AddControllers();

            applicationBuilder.AddSwaggerConfiguration();
            applicationBuilder.AddDbContext();
            applicationBuilder.AddLogic();
            applicationBuilder.AddRepositories();
            applicationBuilder.AddMapping();
            
            return applicationBuilder;
        }

        private static WebApplicationBuilder AddLogic(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddScoped<IContactsService, ContactsService>();

            return applicationBuilder;
        }

        private static WebApplicationBuilder AddRepositories(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddScoped<IContactsRepository, ContactsRepository>();

            return applicationBuilder;
        }

        private static WebApplicationBuilder AddDbContext(this WebApplicationBuilder applicationBuilder)
        {
            var connectionString = applicationBuilder.Configuration.GetConnectionString("DefaultConnection");

            applicationBuilder.Services.AddDbContext<ContactsContext>((options) => options.UseNpgsql(connectionString));

            return applicationBuilder;
        }

        private static WebApplicationBuilder AddSwaggerConfiguration(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Contacts.Service.Api"
                });
            });

            return applicationBuilder;
        }

        private static WebApplicationBuilder AddMapping(this WebApplicationBuilder applicationBuilder)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullCollections = true;

                mc.AddProfile(new MappingProfiles());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            applicationBuilder.Services.AddSingleton(mapper);

            return applicationBuilder;
        }
    }
}
