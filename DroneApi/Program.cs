using DroneApi.Helpers;
using DroneApi.Repositories;
using DroneApi.Repositories.IRepository;
using DroneApi.Repositories.Repository;
using DroneApi.Services.IService;
using DroneApi.Services.Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();

services.AddDbContext<DataContext>();
services.AddCors();
services.AddControllers().AddJsonOptions(x =>
{
    // serialize enums as strings in api responses (e.g. Role)
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    // ignore omitted parameters on models to enable optional params (e.g. User update)
    x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

});
services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


services.AddScoped<IDroneService, DroneService>();
services.AddScoped<IDroneRepository, DroneRepository>();

services.AddScoped<IDroneBatteryLogService, DroneBatteryLogService>();
services.AddScoped<IDroneBatteryLogRepository, DroneBatteryLogRepository>();

services.AddSwaggerGen();

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

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();

