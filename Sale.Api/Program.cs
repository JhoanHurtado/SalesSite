using Microsoft.EntityFrameworkCore;
using Sale.Entitie.Entities;
using Sale.Interface.Interface;
using Sale.Service.Services;

var builder = WebApplication.CreateBuilder(args);


//Add connection to db
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add service AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Add corrs
builder.Services.AddCors(opctions =>
{
    opctions.AddPolicy("CorsPolicy",
    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//MapperConfiguration
builder.Services.AddScoped<IInvoice, InvoiceService>();
builder.Services.AddScoped<IInvoiceDetail, InvoiceDetailService>();



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
