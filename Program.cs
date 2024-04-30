using Microsoft.EntityFrameworkCore;
using tasksprintbe.Services;
using tasksprintbe.Services.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<PasswordService>();

builder.Services.AddScoped<TaskService>();

builder.Services.AddScoped<CommentService>();

builder.Services.AddScoped<UserService>();

var connectionString = builder.Configuration.GetConnectionString("MyTaskString");

builder.Services.AddDbContext<DataContext>(Options => Options.UseSqlServer(connectionString));

builder.Services.AddCors(options => options.AddPolicy("TaskPolicy",
builder => {
    builder.WithOrigins("http://localhost:5072")
    .AllowAnyHeader()
    .AllowAnyMethod();
}));


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

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
