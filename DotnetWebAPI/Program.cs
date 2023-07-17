using DotnetWebAPI.Data;
using DotnetWebAPI.IoC;
using DotnetWebAPI.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DotnetWebAPI"),
        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
});

builder.Services.AddRepositoriesDependencies();
builder.Services.AddServicesDependecy();

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    Serilog.Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("DotnetWebAPI"),
        sinkOptions: new MSSqlServerSinkOptions
        {
            AutoCreateSqlTable = true,
            TableName = "Logging"
        },
        columnOptions: new ColumnOptions
        {
            AdditionalColumns = new List<SqlColumn>
            {
                new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "Payload", DataLength = -1, AllowNull = true}
            }
        })
        .CreateLogger();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
