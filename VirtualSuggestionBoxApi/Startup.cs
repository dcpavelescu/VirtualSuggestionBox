using System;
using System.Security.Authentication;
using System.Text;
using AspNetCore.Identity.MongoDB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using VirtualSuggestionBoxApi.Controllers;
using VirtualSuggestionBoxApi.Models;
using VirtualSuggestionBoxApi.Repositories;
using VirtualSuggestionBoxApi.Storages;

namespace VirtualSuggestionBoxApi
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
            if (Convert.ToBoolean(Configuration["PersistData"] ?? "true"))
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(Configuration["MongoDB:ConnectionString"]));
                settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
                services.AddSingleton<IMongoClient, MongoClient>(client => new MongoClient(settings));
                services.AddTransient(typeof(IStorage<Suggestion>), typeof(MongoDBStorage<Suggestion>));
            }
            else
            {
                services.AddTransient(typeof(IStorage<Suggestion>), typeof(MemoryStorage<Suggestion>));
            }

            services.AddTransient(typeof(SuggestionRepository), typeof(SuggestionRepository));

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                 builder =>
                 {
                     builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                 });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors("AllowAllOrigins");

            //app.UseHttpsRedirection();
            //app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "api/{controller}/{id}");
                // routes.MapRoute("top3", "{*url}", defaults: new { controller = "Suggestion", action = "top3" });
                routes.MapRoute(name: "top3", template: "api/suggestion/top3");
            });
        }
    }
}
