using ECommerce.DataAccess;
using ECommerce.Entities;
using ECommerce.Services;
using ECommerce.Services.Profiles;
using ECommerceAPI.Apis;
using ECommerceAPI.HealthChecks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Text;

namespace ECommerceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .MinimumLevel.Warning()
                .WriteTo.Console()
                .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("ECommerceDB"),
                    new MSSqlServerSinkOptions
                    {
                        AutoCreateSqlTable = true,
                        TableName = "ApiLogs"
                    }, restrictedToMinimumLevel: LogEventLevel.Fatal)
                .CreateLogger();

            builder.Host.ConfigureLogging(options =>
            {
                //options.ClearProviders();
                options.AddSerilog(logger);
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.Configure<AppSettings>(builder.Configuration);

            builder.Services.AddDbContext<ECommerceDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDB"));

                if (builder.Environment.IsDevelopment())
                    options.EnableSensitiveDataLogging();
            });

            // Configuramos el Identity
            builder.Services.AddIdentity<ECommerceUserIdentity, IdentityRole>(setup =>
                {
                    setup.Password.RequireDigit = false;
                    setup.Password.RequireNonAlphanumeric = true;
                    setup.Password.RequireUppercase = false;
                    setup.Password.RequireLowercase = false;
                    setup.Password.RequiredLength = 6;
                    
                    setup.User.RequireUniqueEmail = true;
                    //setup.SignIn.RequireConfirmedEmail = true;

                })
                .AddEntityFrameworkStores<ECommerceDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile<CustomerProfile>();
                config.AddProfile<SaleProfile>();
            });

            builder.Services.AddDependencyInjection();

            builder.Services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy(), new[] { "service" })
                .AddDbContextCheck<ECommerceDbContext>("ECommerceDB", HealthStatus.Unhealthy, new[] { "db" })
                .AddTypeActivatedCheck<DiskHealthCheck>("Storage", HealthStatus.Unhealthy, new[] { "disk" },
                    builder.Configuration)
                .AddTypeActivatedCheck<PingHealthCheck>("Google", HealthStatus.Unhealthy, new[] { "internet" },
                    "google.com")
                .AddTypeActivatedCheck<PingHealthCheck>("Azure", HealthStatus.Unhealthy, new[] { "internet" },
                    "portal.azure.com")
                .AddCheck("pokemon", (_) =>
                {
                    var httpClient = new System.Net.Http.HttpClient();
                    httpClient.BaseAddress = new System.Uri("https://pokeapi.co/api/v2/");
                    var response = httpClient.GetAsync("pokemon/1", System.Threading.CancellationToken.None).Result;

                    if (response.IsSuccessStatusCode)
                        return new HealthCheckResult(HealthStatus.Healthy, "pokemon");
                    else
                        return new HealthCheckResult(HealthStatus.Unhealthy, "pokemon");
                }, new[] { "pokemon" }, timeout: TimeSpan.FromSeconds(20));

            // configuracion por appsettings.json
            //builder.Services.AddHealthChecksUI(setup =>
            //    {
            //        setup.SetHeaderText("ECommerce API - Health Checks Status");

            //        /*
            //         * "HealthChecksUI": {
            //           "HealthChecks": [
            //           {
            //           "Name": "Base de Datos",
            //           "Uri": "https://localhost:7020/health/db"
            //           },
            //           {
            //           "Name": "Internet",
            //           "Uri": "https://localhost:7020/health/internet"
            //           },
            //           {
            //           "Name": "Second API",
            //           "Uri": "https://localhost:8001/health-secondapi"
            //           }
            //           ],
            //           "EvaluationTimeInSeconds": 60,
            //           "MinimumSecondsBetweenFailureNotifications": 3600
            //           }
            //         */
            //    })
            //    .AddInMemoryStorage();

            if (builder.Environment.IsDevelopment())
                builder.Services.AddTransient<IFileUploader, FileUploader>();
            else
                builder.Services.AddTransient<IFileUploader, AzureFileUploader>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            var key = Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Jwt:SigningKey"));

            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer( x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            // Zona PIPELINE
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseHealthChecksUI();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                
                endpoints.MapHealthChecks("/health/db", new HealthCheckOptions
                {
                    Predicate = x => x.Tags.Contains("db"),
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                
                endpoints.MapHealthChecks("/health/internet", new HealthCheckOptions
                {
                    Predicate = x => x.Tags.Contains("internet"),
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                endpoints.MapHealthChecksUI(setup => setup.AddCustomStylesheet("dotnet.css"));

                endpoints.MapDefaultControllerRoute();
            });

            app.MapControllers();

            //app.MapGet("/api/Ventas/busqueda", async (string? initialDate,
            //    string? finalDate,
            //    string? documentNumber,
            //    string? invoiceNumber,
            //    int page, int rows,
            //    [FromServices]ISaleService service) =>
            //{
            //    BaseResponseGenericCollection<SaleDtoResponse> response;

            //    if (!string.IsNullOrEmpty(initialDate) && !string.IsNullOrEmpty(finalDate))
            //        response = await service.SelectAsync(initialDate, finalDate, page, rows);
            //    else if (!string.IsNullOrEmpty(documentNumber))
            //        response = await service.SelectAsync(documentNumber, page, rows);
            //    else
            //        response = await service.SelectByInvoiceNumberAsync(invoiceNumber ?? string.Empty, page, rows);

            //    return Results.Ok(response);

            //}).Produces<BaseResponseGenericCollection<SaleDtoResponse>>(StatusCodes.Status200OK);

            app.RegisterApis();

            app.MapGet("api/Clientes/{id:int}", [Authorize] async (int id, ICustomerService service) =>
            {
                var response = await service.GetByIdAsync(id);

                return response.Success ? Results.Ok(response) : Results.Json(response, statusCode: StatusCodes.Status404NotFound);
            });

            app.Run();
        }
    }
}


