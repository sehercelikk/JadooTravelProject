using JadooTravel.Services.CategoryServices;
using JadooTravel.Services.DestinationServices;
using JadooTravel.Services.FeatureService;
using JadooTravel.Services.ReservationService;
using JadooTravel.Services.TestimonialService;
using JadooTravel.Services.TranslatorService;
using JadooTravel.Services.UserReservationService;
using JadooTravel.Settings;
using Microsoft.Extensions.Options;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IDestinationService, DestinationService>();
        builder.Services.AddScoped<IFeatureService, FeatureService>();
        builder.Services.AddScoped<IRezervationService, RezervationService>();
        builder.Services.AddScoped<ITestimonialService, TestimonialService>();
        builder.Services.AddScoped<IUserReservationService, UserReservationService>();


        builder.Services.AddSingleton<TranslatorService>();

        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        builder.Services.Configure<DatabaseSetting>(builder.Configuration.GetSection("DatabaseSettingsKey"));

        builder.Services.AddScoped<IDatabaseSetting>(sp =>
        {
            return sp.GetRequiredService<IOptions<DatabaseSetting>>().Value;
        });

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        var supportedCultures = new[] { "tr", "en", "fr", "es" };
        var localizationOptions = new RequestLocalizationOptions()
            .SetDefaultCulture("tr")
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);

        app.UseRequestLocalization(localizationOptions);




        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Default}/{action=Index}/{id?}");

        app.Run();
    }
}