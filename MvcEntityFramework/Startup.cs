using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //nuestra aplicacion

            // las dependencias de objetos se resuelven en los servicios de la App
            // dos opciones:
            //1: AddTransient<T> todos los controladores que utilicen coche, nuevo coche por cada peticion de objeto
            //services.AddTransient<Coche>();
            //2: .AddSingleton<T> una misma instancia del objeto, solo una, para toda la app
            //services.AddSingleton<ICoche,Coche>();

            services.AddSingleton<ICoche>( c =>
                    new Deportivo("ferrari","testarrossa","testarrossa.jpg",290)
            );
            String cadena = "Data Source=localhost;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=Data Source=localhost;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2020";
            services.AddSingleton<IDepartamentosContext>( c => 
                                  new DepartamentosContextSQL(cadena) 
            );
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //el servidor
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
