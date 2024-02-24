using KureaKurusu.Web;
using KureaKurusu.Web.Access;
using KureaKurusu.Web.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[assembly: ApiController]
var builder = WebApplication.CreateBuilder(args);

// var startup = new Startup(builder.Configuration);
// startup.ConfigureServices(builder.Services);
        
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseMySQL(builder.Configuration.GetConnectionString("RakbowConnection")!));

builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 注册自定义服务
builder.Services.AddSingleton<PersonService>();

var app = builder.Build();
// startup.Configure(app, builder.Environment);
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
