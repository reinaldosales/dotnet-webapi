using DotnetWebAPI.Data;
using DotnetWebAPI.IoC;
using DotnetWebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddRepositoriesDependencies();
builder.Services.AddServicesDependecy();

var columnOptions = new ColumnOptions
{
    AdditionalColumns = new List<SqlColumn>
    {
        new SqlColumn { DataType = SqlDbType.VarChar, ColumnName = "Payload", DataLength = -1, AllowNull = true}
    }
};

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
        columnOptions: columnOptions)
        .CreateLogger();
});

var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Security"));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
