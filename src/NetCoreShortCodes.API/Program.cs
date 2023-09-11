using Dapper;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using NetCoreShortCodes.API.Database;
using NetCoreShortCodes.API.Repositories;
using NetCoreShortCodes.API.Repositories.Dapper;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddHealthChecks()
                .AddSqlite(config["Database:ConnectionString"]);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // only required for minimal APIs
builder.Services.AddSwaggerGen(options =>
{
    options.MapType<char>(() => new OpenApiSchema
    {
        Type = "string",
        MinLength = 1,
        MaxLength = 1
    });
    options.MapType<TimeOnly>(() => new OpenApiSchema
    {
        // TODO: add pattern here
        Type = "string",
        Example = new OpenApiString(DateTime.Now.ToString("HH:mm:ss.fffffff"))
    });
    options.MapType<TimeSpan>(() => new OpenApiSchema
    {
        // TODO: add pattern here
        Type = "string",
        Example = new OpenApiString(DateTime.Now.ToString("1.HH:mm:ss.fffffff"))
    });
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Example API",
        Description = "Example API",
        Contact = new OpenApiContact
        {
            Name = "BrunoCampiol",
            Url = new Uri("https://brunocampiol.github.io/about.html")
        }
    });
    var xmlFilename = $"{typeof(Program).Assembly.GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new SqliteConnectionFactory(config["Database:ConnectionString"]));
builder.Services.AddSingleton<DatabaseInitializer>();
builder.Services.AddSingleton<ISqliteNativeDataTypesRepository, SqliteNativeDataTypesRepository>();
builder.Services.AddSingleton<ISqliteSupportedNetTypesRepository, SqliteSupportedNetTypesRepository>();

// Adds Dapper support for C# types
SqlMapper.AddTypeHandler(new GuidHandler());
SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
SqlMapper.AddTypeHandler(new DateTimeOffsetHandler());
SqlMapper.AddTypeHandler(new TimeOnlyTypeHandler());
SqlMapper.AddTypeHandler(new TimeSpanHandler());

var app = builder.Build();

// Register middlewares (middlwares are sequential)
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.EnableTryItOutByDefault();
    });
}

app.MapHealthChecks("/_health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

//app.UseAuthorization();
app.MapControllers();

var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

app.Run();