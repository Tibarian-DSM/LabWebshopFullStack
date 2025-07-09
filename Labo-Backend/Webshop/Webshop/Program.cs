using Webshop.DAL.Interfaces;
using Webshop.BLL.Intefaces;
using Webshop.DAL.Repositories;
using Webshop.BLL.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Webshop.API.Tools;
using Tools;
using AspNetCoreRateLimit;
using Webshop.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials();
}));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // D�finir les information g�n�rales de notre API dans swagger
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "WebShop",
        Version = "v1"
    });

    // D�clarer une schema de s�curit� de type Bearer pour Swagger
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "Token bearer utilise le schema (Bearer {token})",
        Name = "Authorization", // Nom de l'en-t�te HTTP
        In = Microsoft.OpenApi.Models.ParameterLocation.Header, // Indique que l'info est envoy� dans le header HTTP
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey, // D�clare une cl� API de type Bearer
        Scheme = "Bearer" // Nom du sch�ma utilis�
    });

    // Ajoute une exigence de s�curit� globale pour toutes les routes prott�g�s par [Authorize]
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2", // N�c�ssaire pour swagger (interface)
                Name = "Bearer",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            },
            new List<string>() // Liste vide => Pas de scopes sp�cifique n�c�ssaires...
        }
    });
});

builder.Services.AddHttpClient<GoogleCaptchaService>();


builder.Services.AddScoped<IUserServices, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddSingleton(sp =>new Connection(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddSingleton<TokenManager>();

// Configuration de l'authentification JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["jwt:issuer"],
            ValidAudience = builder.Configuration["jwt:audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"])),
            //Permet de signifier au frontend qu'on attend un r�le
            RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
        };
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", policy =>
    {
        policy
           .WithOrigins("http://localhost:4200")
           .SetIsOriginAllowed(origin => true)
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowCredentials();
    });

});


#region Rate Limiting
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddInMemoryRateLimiting();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
#endregion

var app = builder.Build();

app.UseIpRateLimiting();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","Webshop"));
}

app.UseRouting();

app.UseCors("MyPolicy");
app.UseHttpsRedirection();
app.UseAuthentication(); // Ne pas oublier de la mettre 
app.UseAuthorization();

app.MapControllers();

app.Run();
