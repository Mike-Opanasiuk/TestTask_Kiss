using Api;
using Api.UnitOfWork.Abstract;
using Api.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Api.Services;
using Api.Middlewares.ExceptionHandlingMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<ISha256Service, Sha256Service>();
builder.Services.AddTransient<IOAuthService, OAuthService>();
builder.Services.AddTransient<IHttpClientService, HttpClientService>();
builder.Services.AddTransient<IImageService, ImageService>();
builder.Services.AddTransient<IAppUtils, AppUtils>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(text =>
{
    text.AllowAnyHeader();
    text.AllowAnyMethod();
    text.AllowAnyOrigin();
});

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSession();

app.MapControllers();

app.Run();
