using API_MedicoPaciente.Data;
using API_MedicoPaciente.Data.EFCore;
using API_MedicoPaciente.Models;
using API_MedicoPaciente.Services;
using API_MedicoPaciente.Services.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace API_MedicoPaciente
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                //cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyMethod()
                                      .AllowAnyHeader()
                                      .SetIsOriginAllowed(_ => true)
                                      .AllowCredentials());
            });




            services.AddDbContext<AppDbContext>(
                options => options.UseNpgsql("name=ConnectionStrings:DefaultConnection"));


            services.AddMvc()
                  .AddControllersAsServices();
            services.AddControllers();
            services.AddControllersWithViews();
            services.AddSession();

            services.AddRazorPages();

            services.AddSwaggerGen();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyTestService", Version = "v1", });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddTransient<IEFCoreMedicosRepository, EfCoreMedicosRepository>();
            services.AddTransient<IEFCorePacientesRepository, EfCorePacientesRepository>();

            services.AddTransient(typeof(IRepository<>), typeof(EfCoreRepository<>));
            services.AddTransient<IMedicoService, MedicoService>();
            services.AddTransient<IPacienteService, PacienteService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseCors(policy =>
                policy.WithMethods(new string[] { "GET", "POST", "PUT", "DELETE" })
            );

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestService");
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
