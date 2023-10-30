using Core.Interfaces.Infra.Database;
using Core.Interfaces.Infra.Email;
using Core.Interfaces.Infra.ServiceLifetimes;
using Core.Interfaces.Services;
using Core.Services;
using Infrastructure.Database;
using Infrastructure.Database.Repositories;
using Infrastructure.Email;
using Infrastructure.ServiceLifetimes;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// configure database connection string
builder.Services.AddDbContext<DatabaseContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString(
      "DefaultConnection"));
});

#region Configure IOptioin Pattern
builder.Services.Configure<SendgridEmailProviderOptions>(
     builder.Configuration.GetSection(SendgridEmailProviderOptions.ConfigItem));

builder.Services.Configure<MailGunEmailProviderOptions>(
    builder.Configuration.GetSection(MailGunEmailProviderOptions.ConfigItem));

#endregion

#region Configure DI Container - Service Lifetimes - Infra
builder.Services.AddTransient<ITransientService, TransientService>();
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddSingleton<ISingletonService, SingletonService>();

// Install Service Lifetimes for Email Provider to ready using in API 
// Try to switch between Sendgrid and Mailgun
//builder.Services.AddTransient<IEmailProvider, SendgridEmailProvider>();
builder.Services.AddTransient<IEmailProvider, MailGunEmailProvider>();

builder.Services.AddScoped<IProvinceRepository, ProvinceRepository>();

#endregion

#region Configure DI Container - Service Lifetimes - Business Services
builder.Services.AddTransient<ITokenService, TokenService>();
//builder.Services.AddScoped<IProvinceService, ProvinceService>();
builder.Services.AddScoped<IProvinceService, ProvinceService>();
#endregion

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await SeedDatabase();

app.Run();

#region Seed Database
async Task SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbcontext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

        // Run migration scripts
        await dbcontext.Database.MigrateAsync();

        // Seed data to the project
        await Seed.SeedData(dbcontext);
    }
}
#endregion
