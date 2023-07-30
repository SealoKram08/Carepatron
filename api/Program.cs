using api.Data;
using api.Services;
using api.Repositories.IConfiguration;
using Microsoft.EntityFrameworkCore;
using api.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// cors
services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .Build());
});

// ioc
services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(databaseName: "Test"));
services.AddScoped<DataSeeder>();

services.AddControllers();

//DTO Automapper
services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//DI unit of work and services.
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<IClientServices, ClientServices>();
services.AddScoped<IDocumentServices, DocumentServices>();
services.AddScoped<IEmailServices, EmailServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseCors();

// seed data
using (var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

    dataSeeder.Seed();
}

// run app
app.Run();