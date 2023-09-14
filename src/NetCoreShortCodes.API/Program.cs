using Dapper;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using NetCoreShortCodes.API.Configuration;
using NetCoreShortCodes.API.Database;
using NetCoreShortCodes.API.Repositories;
using NetCoreShortCodes.API.Repositories.Dapper;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddHealthChecks()
                .AddSqlite(config["Database:ConnectionString"]);
builder.Services.AddControllers();
builder.Services.AddAppSwaggerGen();

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

// Register middlewares (order matters!)
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
databaseInitializer.Initialize();

app.Run();