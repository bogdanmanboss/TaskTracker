using Microsoft.EntityFrameworkCore;
using TaskTracker.Sql.Library;
using TaskTracker.Sql.Library.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string taskTrackerDatabaseConnectionString = builder.Configuration.GetConnectionString("TaskTrackerDbConnectionString");

builder.Services.AddDbContext<TaskTrackerDbContext>(
        options => options.UseSqlServer(taskTrackerDatabaseConnectionString));
builder.Services.AddScoped<UserService>();

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
