using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Aster.Cache;
using Aster.Common.Data;
using Aster.Common.Filter;
using Aster.Localizations;
using Aster.Security;
using Aster.Security.AuthContext;
using Aster.Security.Models;
using Aster.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.WebEncoders;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace Aster.Admin.API
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
            services.AddCors(o =>
            o.AddPolicy("*",
                builder => builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials()
            ));
            //services.AddHttpContextAccessor();
            //services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            var appSettingsSection = Configuration.GetSection("TokenOptions");
            services.Configure<AppAuthenticationSettings>(appSettingsSection);
            services.AddDistributedRedisCache(Configuration);
            services.AddLocalizationOption(opts => Configuration.GetSection("Localization").Bind(opts));
            services.AddSqlStringLocalizer(opts => Configuration.GetSection("Localization").Bind(opts));
            services.AddServices(Configuration);
            services.AddData(Configuration);
            //jwt
            var tokenOptions = appSettingsSection.Get<TokenOptions>();
            services.AddJwtBearerAuthentication(tokenOptions);
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.Configure<WebEncoderOptions>(options =>
               options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs)
           );


            services.AddMvc(options => 
             {
                 //options.Filters.Add(typeof(AuthorizationFilter));
                 options.Filters.Add(typeof(MyExceptionFilter));

             }).AddJsonOptions(options =>
             { 
                 options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
              }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Aster通用权限API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("Bearer",
                    new ApiKeyScheme
                    {
                        In = "header",
                        Description = "请输入OAuth接口返回的Token，前置Bearer。示例：Bearer {Roken}",
                        Name = "Authorization",
                        Type = "apiKey"
                    });
                c.AddSecurityRequirement(
                    new Dictionary<string, IEnumerable<string>>
                    {
                        { "Bearer",
                          Enumerable.Empty<string>()
                        },
                    });
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseFileServer();
            app.UseAuthentication();
            app.UseCors("*");
            app.ConfigureCustomExceptionMiddleware();

            //var serviceProvider = app.ApplicationServices;
            //var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            //AuthContextService.Configure(httpContextAccessor);
            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                     name: "areaRoute",
                     template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "apiDefault",
                    template: "api/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger(o =>
            {
                o.PreSerializeFilters.Add((document, request) =>
                {
                    document.Paths = document.Paths.ToDictionary(p => p.Key.ToLowerInvariant(), p => p.Value);
                });
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aster API V1");
                //c.RoutePrefix = "";
            });
        }
    }
}
