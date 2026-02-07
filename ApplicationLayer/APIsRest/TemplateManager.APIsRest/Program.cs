using Microsoft.OpenApi.Models;
using WebApi.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using TemplateManager.APIs;
using TemplateManager.APIs.BasicAuth;
using UserManager.Common;
using Middleware.APIsRest;
using QuestPDF.Infrastructure;
using Swashbuckle.AspNetCore.Filters;
using TemplateManager.APIs.DomainService.Concrete.QuestPdf;
using TemplateManager.APIs.DomainService;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add services to DI container
{
    var services = builder.Services;
    services.AddCors();
    services.AddControllers();

    // configure DI for application services
    services.AddScoped<IUserService, UserService>();
}

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TemplateManager.APIsRest", Version = "v1" });

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
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

// 4. QuestPDF - Licenza Community (GRATIS per uso non commerciale)
QuestPDF.Settings.License = LicenseType.Community;

// 5. Servizi CORE - Solo QuestPDF e DB operations
// LEGACY services (Razor/Puppeteer) rimossi per performance
builder.Services.AddScoped<IOfferTemplateServiceApi, OfferTemplateServiceApi>();
builder.Services.AddScoped<IOfferPdfEmailService, OfferPdfEmailService>();

// 6. PDF Renderer - Solo QuestPDF (veloce e moderno)
builder.Services.AddScoped<IQuestPdfRenderer, QuestPdfRenderer>();

// 7. Cache per performance
builder.Services.AddMemoryCache();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                    options =>
                    {
                        //options.LoginPath = new PathString("/Account/Login/"); 
                        //options.AccessDeniedPath = new PathString("/Account/Forbidden/");
                    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(PermissionsPolicy.ReadonlyPolicy, policy => policy.RequireClaim("Authorization", new List<String>() { UserAuthorizationsNames.Write, UserAuthorizationsNames.Readonly, UserAuthorizationsNames.FullAccess }));

    options.AddPolicy(PermissionsPolicy.WritePolicy, policy => policy.RequireClaim("Authorization", new List<String>() { UserAuthorizationsNames.Write, UserAuthorizationsNames.FullAccess }));

    options.AddPolicy(PermissionsPolicy.FullControlPolicy, policy => policy
    .RequireClaim("Authorization", new List<String>() { UserAuthorizationsNames.FullAccess, UserAuthorizationsNames.FullAccess })
    .RequireRole(new List<String>() { UserRolesNames.Administrator })
    );
});

// 9. Initialize Bootstrapper (Service Locator pattern - existing architecture)
// This initializes the legacy Service Locator and Gateway pattern
// Used by Template, TemplateParagraph, and all DB operations
TemplateManager.APIs.Application.BootStrapper.Initialize();


var app = builder.Build();

// Configure the HTTP request pipeline.

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// custom basic auth middleware
app.UseMiddleware<BasicAuthMiddleware>();

app.MapControllers();

//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

//Add our new middleware to the pipeline
app.UseMiddleware<RequestResponseLoggingMiddleware>();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// ============================================
// MINIMAL API ENDPOINTS (moderni)
// ============================================

// Health Check
// Endpoint per verificare che API attiva
app.MapGet("/ServiceApi/V1.0/health", () => Results.Ok(new
{
    status = "healthy",
    timestamp = DateTime.UtcNow,
    version = "2.0.0"
}))
.WithName("HealthCheck")
.WithTags("System");

app.Run();
