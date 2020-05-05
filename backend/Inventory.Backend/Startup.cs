using Inventory.EntityFrameworkCore;
using Inventory.EntityFrameworkCore.SqlServer;
using Inventory.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Security.Core.Authentication;
using Security.Core.Controller.Extensions;
using Security.Core.Manager;
using Security.Core.Options;
using Security.Core.Service.Extensions;
using UtilsCore;
using UtilsCore.CacheData.Extensions;
using UtilsCore.Cors;
using UtilsCore.Filter.Json;
using UtilsCore.Mvc;
using UtilsCore.Mvc.Error;

namespace Inventory.Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString();

            services.AddCoreSecurityServices();
            services.AddCoreJsonFilter(Environment);

            var settings = new ApplicationSetting();

            Configuration.GetSection(nameof(ApplicationSetting)).Bind(settings);

            services.AddCoreAuthentication<EntityDbContext, EntityDbContextFactory>(
                new SecurityOptions
                {
                    Authentication = new AuthenticationOptions {IssuerSigningKey = settings.SecretKeyJwt},
                    ConnectionString = connectionString
                }
            );

            services.Configure<ApplicationSetting>(options => settings.CopyTo(options));
            services.AddDbContext<EntityDbContext>(options => options.AddSqlServer(connectionString));
            services.AddCoreCacheData();
            services.AddServices();
            services.AddCoreCors();
            services.AddCoreControllers().AddCoreSecurityControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IOptions<SecurityOptions> securityOptions
        )
        {
            app.UseCoreMvcErrorHandler();
            app.UseCoreCacheData();
            app.UseSqlServerAutoMigrations(securityOptions.Value.ConnectionString);
            app.UseCoreCors();
            app.UseCoreAuthentication(services => services.SeedDefaultUser().Wait());
            app.UseCoreControllers();
            app.UseWelcomePage("/");
        }
    }
}