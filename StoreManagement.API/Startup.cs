using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using MediatR;
using StoreManagement.Data.Infrastructure.UnitOfWorks;
using StoreManagement.Data.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Domain;
using StoreManagement.Application.Queries;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using Bogus;
using StoreManagement.API.Extensions;

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
            #region LowerCase URLs for frontend convention "lowerCamelCase"
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            #endregion

            #region Enable Cors
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder => builder
            .WithOrigins("http://localhost:4200")
            .WithOrigins("http://localhost:9800")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials())
            ); ; // Make sure you call this previous to AddMvc
            // sometime cors fails in client because of multiple path in launchApplicationSettings
            //"applicationUrl": "https://localhost:5001;http://localhost:5000"
            // only keep "applicationUrl": "http://localhost:5000"
            #endregion

            // Register MediatR services
            services.AddMediatR(typeof(Startup));
            services.AddServices();

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

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreManagement.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            #region Enable Corse
            // Make sure you call this before calling app.UseMvc() and before auhentication middleware
            app.UseCors("CorsPolicy");
            #endregion

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store Management Swagger Open API Documentation");
            });
            #endregion
        }

        private void AddTestData(StoreDbContext context)
        {
            var codeRecordFaker = new Faker();

            #region Brand Mock
            for (int i = 0; i < 20; i++)
            {
                context.Add
                (
                    new Brand
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.UtcNow,
                        Updated = DateTime.UtcNow,
                        Name = codeRecordFaker.Company.CompanyName()
                    }
                );
            }
            context.SaveChanges();
            #endregion

            #region Category Mock
            for (int i = 0; i < 10; i++)
            {
                context.AddRange
                (
                    new Category
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.UtcNow,
                        Updated = DateTime.UtcNow,
                        Name = codeRecordFaker.Commerce.Categories(1)[0]
                    }
                );
            }
            context.SaveChanges();
            #endregion

            #region Product Mock
            for (int i = 0; i < 100; i++)
            {
                List<Brand> brands = context.Brands.ToListAsync().Result;
                List<Category> categories = context.Categories.ToListAsync().Result;
                Random random = new Random();
                int randomBrand = random.Next(0, brands.Count);
                int randomCategory = random.Next(0, categories.Count);

                context.Add
                (
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.UtcNow,
                        Updated = DateTime.UtcNow,
                        Name = codeRecordFaker.Commerce.ProductName(),
                        Brand = brands[randomBrand],
                        BrandId = brands[randomBrand].Id,
                        Description = codeRecordFaker.Commerce.ProductDescription(),
                        Price = decimal.Parse(codeRecordFaker.Commerce.Price(10.00M, 5000.00M)),
                        Category = categories[randomCategory],
                        CategoryId = categories[randomCategory].Id
                    }
                );
            }
            context.SaveChanges();
            #endregion
        }
    }
}
