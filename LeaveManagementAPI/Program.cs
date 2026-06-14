using LeaveManagementAPI.Data;
using LeaveManagementAPI.Middleware;
using LeaveManagementAPI.Repositories;
using LeaveManagementAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService,    EmployeeService>();
builder.Services.AddScoped<ILeaveRepository,    LeaveRepository>();
builder.Services.AddScoped<ILeaveService,       LeaveService>();

var app = builder.Build();

// Middleware
app.UseMiddleware<LoggingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
