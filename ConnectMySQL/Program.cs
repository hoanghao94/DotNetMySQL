using ConnectMySQL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "Server=localhost;Port=3306;database=quanlycafe;uid=root;pwd=123456;";
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddDbContext<AppDbContext>(optionBuilder => {
    optionBuilder.UseMySql(connectionString,
                   new MySqlServerVersion(new Version(8, 0, 27)),
                   options => options.EnableRetryOnFailure(
                       maxRetryCount: 5,
                   maxRetryDelay: System.TimeSpan.FromSeconds(30),
                   errorNumbersToAdd: null
                       )
                   );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
