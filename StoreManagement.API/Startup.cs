using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using StoreManagement.Data.Infrastructure.UnitOfWorks;
using StoreManagement.Data.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Domain;
using StoreManagement.Application.Queries;

namespace StoreManagement.API
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
            // Register MediatR services
            services.AddMediatR(typeof(Startup));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                #region Description
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "StoreManagement.API Swagger",
                    Contact = new OpenApiContact()
                    {
                        Email = "m.elharfi@gmail.com",
                        Name = "Mohssine EL HARFI",
                    },
                    Description = "StoreManagement.API handle requests about store management",
                    License = new OpenApiLicense()
                    {
                        Name = "Copyright",
                    }
                });
                #endregion

                //Enable Swagger Annotations
                c.EnableAnnotations();
            });

            #region MediatR
            services.AddMediatR(typeof(GetAllBrandesQueryHandler).Assembly);
            #endregion

            #region Entity Framework InMemory
            //services.AddDbContext<StoreDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddDbContext<StoreDbContext>(opt => opt.UseInMemoryDatabase("TestDB"));
            #endregion

            #region Unit Of Work
            services.AddScoped<IStoreUnitOfWork, StoreUnitOfWork>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<StoreDbContext>();
                AddTestData(context);
                // Seed the database.
            }

            //var context = app.ApplicationServices.GetService<StoreDbContext>();
            //AddTestData(context);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreManagement.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddTestData(StoreDbContext context)
        {
            #region Brand Mock
            var adidasBrand = new Brand
            {
                Id = Guid.Parse("07b40f57-34f0-4ada-b7e1-db081e729e8e"),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                Name = "Adidas"
            };
            context.Add(adidasBrand);

            var pumaBrand = new Brand
            {
                Id = Guid.Parse("bb89f2ed-33d8-4dae-a2e8-6ea8a2f602ea"),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                Name = "Puma"
            };
            context.Add(pumaBrand);
            #endregion

            #region Category Mock
            var pantCategory = new Category
            {
                Id = Guid.Parse("08d607ab-397e-48e0-98b2-a3834b97766a"),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                Name = "Pant"
            };
            context.Add(pantCategory);

            var HatCategory = new Category
            {
                Id = Guid.Parse("db26d0d4-dff1-499c-bb17-a7cc06ac6933"),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                Name = "Hat"
            };
            context.Add(HatCategory);
            #endregion

            #region Product Mock
            var p1 = new Product
            {
                Id = Guid.Parse("08d607ab-397e-48e0-98b2-a3834b97766a"),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                Name = "Black Hat 01",
                Brand = pumaBrand,
                BrandId = pumaBrand.Id,
                Category = HatCategory,
                CategoryId = HatCategory.Id
            };
            context.Add(p1);

            var p2 = new Product
            {
                Id = Guid.Parse("2d8eefe5-0476-4e7b-8051-059736442023"),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                Name = "US Jeans 01",
                Brand = adidasBrand,
                BrandId = adidasBrand.Id,
                Category = pantCategory,
                CategoryId = pantCategory.Id
            };
            context.Add(p2);
            #endregion

            context.SaveChanges();
        }
    }
}
