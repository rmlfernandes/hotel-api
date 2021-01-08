using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using HotelApi.Data;
using HotelApi.Schemas;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace HotelApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelApi", Version = "v1" });
            });

            services.AddDbContext<MyHotelDbContext>(options => options.UseSqlServer(MyHotelDbContext.DbConnectionString));
            services.AddTransient<ReservationRepository>();

            services.AddScoped<MyHotelSchema>();

            services
                .AddGraphQL()
                .AddSystemTextJson()
                .AddGraphTypes(ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HotelApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseGraphQL<MyHotelSchema>();

            //to explorer API navigate https://localhost:44349/ui/playground
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}
