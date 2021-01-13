using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework
{
    public class Startup
    {
        //interfaz para acceder a appsettings.json
        IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //LA APLICACION

            // las dependencias de objetos se resuelven en los servicios de la App
            // dos opciones:
            //1: AddTransient<T> todos los controladores que utilicen coche, nuevo coche por cada peticion de objeto
            //services.AddTransient<Coche>();
            //2: .AddSingleton<T> una misma instancia del objeto, solo una, para toda la app
            //services.AddSingleton<ICoche,Coche>();

            String cadena = "Data Source=localhost;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=Data Source=localhost;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2020";
            //String cadena = this.Configuration.GetConnectionString("casamysqlhospital");

            services.AddTransient<RepositoryHospital>();
            services.AddDbContext<HospitalContext>(options=> options.UseSqlServer(cadena));

            services.AddSingleton<IDepartamentosContext>( c => 
                                  new DepartamentosContextMysql(cadena) 
            );  
            
            services.AddSingleton<ICoche>( c =>
                    new Deportivo("ferrari","testarrossa","testarrossa.jpg",290)
            ); 
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //EL SERVIDOR
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
          
        }
    }
}
