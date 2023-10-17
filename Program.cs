using ApiKey.Data;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var conn = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<ApiKeyDbContext>(options => options.UseNpgsql(conn));
// SeriLog
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));


//Data Protection
// builder.Services.AddDataProtection()
//     .PersistKeysToFileSystem(new DirectoryInfo(@"\\server\share\directory\"));
// builder.Services.AddDataProtection()
//     .SetDefaultKeyLifetime(TimeSpan.FromDays(14));



// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
// Cấu hình các HTTP security headers
// builder.Services.AddCustomSecurityHeaders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    app.UseSecurityHeaders();
}
// else
// {
//     app.UseExceptionHandler("/Home/Error");
//     app.UseHsts();  // Enable HTTP Strict Transport Security (HSTS)
// }

// Sử dụng các HTTP security headers
// app.UseSecurityHeadersMiddleware();

app.UseSerilogRequestLogging();
app.UseStaticFiles();
app.UseRouting();

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllerRoute(
//         name: "default",
//         pattern: "{controller=Home}/{action=Index}/{id?}");
// });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
