﻿using Duffnization.Business;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Text;



namespace Duffnization.API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //services.AddSingleton<DocusignConfig>(c => GetDocuSignConfig(services));
            //services.AddScoped<IDocusignAPI, DocusignAPI>();
            services.AddScoped<IBearStyleBusiness, BearStyleBusiness>();

            //services.AddSingleton(c => GetConfiguration());

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                };
            });


            services.AddAuthorization();


            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Duffnization.API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });

        }

        //private DocusignConfig GetDocuSignConfig(IServiceCollection services)
        //{

        //    var parameterService = services.BuildServiceProvider().GetService<ParameterService>();

        //    var environmentName = System.Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production";

        //    Log.Logger.Information("AMBIENTE DOCUSIGN CONFIG " + environmentName);

        //    var userId = parameterService.GetByCode((int)EnumParameter.DocuSignDevelopmentUserId);
        //    var oAuthPath = parameterService.GetByCode((int)EnumParameter.DocuSignDevelopmentOAuthPath);
        //    var privateKey = parameterService.GetByCode((int)EnumParameter.DocuSignDevelopmentPrivateKey);
        //    var expirationJWT = parameterService.GetByCode((int)EnumParameter.DocuSignDevelopmentExpirationJWT);
        //    var integratorKey = parameterService.GetByCode((int)EnumParameter.DocuSignDevelopmentIntegratorKey); // clientId
        //    var scopesToGrantConsent = parameterService.GetByCode((int)EnumParameter.DocuSignDevelopmentScopesToGrantConsent);
        //    var responseType = parameterService.GetByCode((int)EnumParameter.DocuSignResponseType);
        //    var redirectURIConsentGrant = parameterService.GetByCode((int)EnumParameter.DocuSignDevelopmentRedirectURIConsentGrant);
        //    var apiAccountId = parameterService.GetByCode((int)EnumParameter.DocuSignDevelopmentAPIAccountID);




        //    return new DocusignConfig
        //    {
        //        UserId = userId.Value,
        //        OAuthPathBase = oAuthPath.Value,
        //        PrivateKey = privateKey.Value,
        //        ExpirationJWT = int.Parse(expirationJWT.Value),
        //        IntegratorKey = integratorKey.Value,
        //        ScopesToGrantConsent = scopesToGrantConsent.Value,
        //        ResponseType = responseType.Value,
        //        RedirectURIConsentGrant = redirectURIConsentGrant.Value,
        //        ApiAccountID = apiAccountId.Value,
        //        Environment = environmentName
        //    };
        //}

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
    
        }
    }
}