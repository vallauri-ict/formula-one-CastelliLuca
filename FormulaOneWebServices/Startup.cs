using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FormulaOneWebServices
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Country api:\nhttps://localhost:44348/api/country  visualizza tutte le nazioni\nhttps://localhost:44348/api/country/id  visualizza una nazione in base al codice inserito\n\nTeam api:\nhttps://localhost:44348/api/team  visualizza tutti i team\nhttps://localhost:44348/api/team/id  visualizza un team in base al codice inserito\n\nDriver api:\nhttps://localhost:44348/api/driver  visualizza tutti i piloti\nhttps://localhost:44348/api/team/id  visualizza un pilota in base al codice inserito\n\n");
                });
                endpoints.MapControllers();
            });
        }
    }
}
