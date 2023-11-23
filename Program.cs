using System.Data;
using System.Data.SqlClient;
using VerticalSliceArch.Application.Features.Users.Command;
using VerticalSliceArch.Features.TimeConvertion.Infrastructure.Services;
using VerticalSliceArch.Infrastructure.Middlewares;
using VerticalSliceArch.Infrastructure.Services;
using VerticalSliceArch.Infrastructure.Services.shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ITenantService, TenantService>();
builder.Services.AddTransient<ITenantHelper, TenantHelper>();
builder.Services.AddTransient<ITimeConversionService, TimeConversionService>();


//MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly));


// Registra IDbConnection para Dapper - asumiendo una cadena de conexión por defecto
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Middlewares
app.UseMiddleware<TenantIdentificationMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();