using AutoMapper;
using HungryPizza.API.DTO.Order;
using HungryPizza.API.Validation.Validators;
using HungryPizza.API.Validation.Validators.Intefaces;
using HungryPizza.Application.Services;
using HungryPizza.Application.Services.Interfaces;
using HungryPizza.Data.DbContext;
using HungryPizza.Data.DbContext.Interfaces;
using HungryPizza.Data.Models;
using HungryPizza.Data.Repositories;
using HungryPizza.Data.Repositories.Base;
using HungryPizza.Data.Repositories.Interfaces;
using HungryPizza.Data.SqlGenerator;
using HungryPizza.Data.UoW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HungryPizza.API
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

            services.AddSwaggerGen();

            ConfigureValidators(services);
            ConfigureAutoMapper(services);
            ConfigureApplicationServices(services);
            ConfigureRepositories(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDatabaseService configureDatabaseService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hungry Pizza API");
                c.RoutePrefix = string.Empty;
            });

            await configureDatabaseService.ConfigureDatabase();
        }

        private void ConfigureValidators(IServiceCollection services)
        {
            services.AddSingleton<IApiValidator<OrderRequestDto>, OrderRequestDtoValidator>();
            services.AddSingleton<IApiValidator<CustomerRequestDto>, CustomerRequestDtoValidator>();
            services.AddSingleton<IApiValidator<OrderItemRequestDto>, OrderItemRequestDtoValidator>();
        }

        private void ConfigureAutoMapper(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mappings.Order.DtoToModelProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private void ConfigureApplicationServices(IServiceCollection services)
        {
            services.AddScoped<IDatabaseService, DatabaseService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderService, OrderService>();
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IDatabase, Database>();
            services.AddScoped<IDbContextFactory, DbContextFactory>();
            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped(typeof(INamedEntityRepository<,>), typeof(NamedEntityRepository<,>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped(typeof(ISqlGenerator<,>), typeof(SqlGenerator<,>));
            services.AddScoped<IUnitOfWork>(_ => new UnitOfWork(Configuration["ConnectionStrings:DefaultConnection"]));
        }
    }
}
