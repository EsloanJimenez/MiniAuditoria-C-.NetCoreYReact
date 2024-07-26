using ejpservice.Infrastructure.Context;
using ejpservice.IOC.Dependencies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add services to the container.

#region "Registro del contexto"
var pr = builder.Configuration.GetConnectionString("EJPServiceContext");

builder.Services.AddDbContext<EJPServiceContext>(op => op.UseMySQL(pr));

#endregion

#region "Registro de dependencias"
builder.Services.AddCustomerDependency();
builder.Services.AddInventoryDependency();
builder.Services.AddSalesDependency();
#endregion



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowReactApp");

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
