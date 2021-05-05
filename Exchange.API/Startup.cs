using Exchange.Application;
using Exchange.Domain.Interfaces;
using Exchange.Domain.Interfaces.Repository;
using Exchange.Repository;
using Exchange.Repository.DapperMap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace Exchange.API
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
                .AllowAnyHeader());
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                .Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(option => option.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddControllers();

            #region Singleton for Services

            services.AddSingleton<ISegmentService, SegmentService>();
            services.AddSingleton<ICountryService, CountryService>();
            services.AddSingleton<IRateService, RateService>();
            services.AddSingleton<ISegmentRepository, SegmentRepository>();
            services.AddSingleton<ICountryRepository, CountryRepository>();

            #endregion

            RegisterDapperMapping();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterDapperMapping()
        {
            DapperMap.RegisterDapperMapper();
        }
    }
}
