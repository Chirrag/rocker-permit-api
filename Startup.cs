using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Roker.BuildingBlocks.Common.Middleware;
using Roker.Messagebus.SQS.IOC;
using Roker.Permit.Domain.Options;
using Roker.Permit.IOC.Startup;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace Roker.Permit.Api
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
            IdentityModelEventSource.ShowPII = true;            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Roker API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                  new OpenApiSecurityScheme
                  {
                    Reference = new OpenApiReference
                    {
                      Type = ReferenceType.SecurityScheme,
                      Id = "Bearer"
                    }
                   },
                   new string[] { }
                 }
                });
                c.CustomSchemaIds(x => x.FullName);
            });
            services.AddDependency(Configuration);
            services.AddCors(opts =>
            {
                opts.AddPolicy("CORS", builder =>
                {
                    builder.AllowAnyOrigin()
                         .AllowAnyHeader()
                         .AllowAnyMethod();
                });
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            var identityUrl = Configuration.GetValue<string>("IAMUrl");
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = identityUrl;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json; charset=utf-8";
                            var message = context.Exception.ToString();
                            var result = JsonConvert.SerializeObject(new { message });
                            return context.Response.WriteAsync("Authentication Failed");
                        },
                        OnTokenValidated = async ctx =>
                        {
                            string id = string.Empty, name = string.Empty;
                            int[] roles = { };
                            var data = ctx.Principal.Identity;
                        }
                    };
                }).AddCookie(opt =>
            {
                opt.SlidingExpiration = true;
                opt.Cookie.SameSite = SameSiteMode.None;
                opt.Cookie.Expiration = TimeSpan.FromMinutes(120);
                opt.Cookie.HttpOnly = true;
            });
            //services.AddAuthorization(options =>
            //options.AddPolicy("api", policy => policy.RequireClaim("iam")));
            services.Configure<DocumentFolder>(Configuration.GetSection("DocumentFolder"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UsePathBase("/permit");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var forwardOptions = new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
                RequireHeaderSymmetry = false
            };

            forwardOptions.KnownNetworks.Clear();
            forwardOptions.KnownProxies.Clear();

            // ref: https://github.com/aspnet/Docs/issues/2384
            app.UseForwardedHeaders(forwardOptions);

            app.UseRouting();
            app.UseCors("CORS");
            app.UseAuthorization();
            app.UseMultitenant();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/permit/swagger/v1/swagger.json", "Roker API V1");
            });
            app.UseMiddleware<ResponseMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}