using MediatR;
using OnlineCourseRegistration.Application;
using System.Reflection;
using OnlineCourseRegistration.Domain;
using OnlineCourseRegistration.Persistence;
using OnlineCourseRegistration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
var provider = builder.Services.BuildServiceProvider();

var configuration = provider.GetRequiredService<IConfiguration>();


//  services.AddAutoMapper(typeof(ApplicationDependenceInjectionModule));


builder.Services.AddMediatR(Assembly.GetExecutingAssembly())

.AddPresentationDependenceInjection()
.AddPersistenceDependenceInjection(configuration)
.AddApplicationDependencyInjection()
.AddDomainDependenceInjection();

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
