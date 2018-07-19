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
               // services.AddTransient(typeof(Account), typeof(MongoDBStorage));

            }
            else
            {
               
                services.AddSingleton(typeof(BaseEntity), typeof(MemoryStorage<BaseEntity>));
            }

            // services.AddTransient(typeof(MongoDBStorage<TEntity>), typeof(MongoDBStorage<TEntity>));

            services.AddSingleton<IConfiguration>(Configuration);

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

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "api/{controller}/{id}");
            });
        }
    }
}
