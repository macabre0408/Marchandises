using Marchandises.Components;
using Marchandises.Data;
using Microsoft.EntityFrameworkCore;
using Marchandises.Service;
using Marchandises.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Marchandises.Models;
using Marchandises.Components.Account;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddCascadingAuthenticationState();
        builder.Services.AddScoped<IdentityUserAccessor>();
        builder.Services.AddScoped<IdentityRedirectManager>();
        builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();


        // Configure the MySQL connection
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ProductDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        // Register the service
        builder.Services.AddScoped<IProduitService, ProductService>();
        builder.Services.AddScoped<IClientCrud, ClientCrud>();
        // Ajouter les services d'authentification et d'autorisation
        //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        //    .AddCookie();

        //builder.Services.AddAuthorizationCore();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
            .AddIdentityCookies();

        //builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddIdentityCore<Utilisateur>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ProductDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders()
            ;

        builder.Services.AddSingleton<IEmailSender<Utilisateur>, IdentityNoOpEmailSender>();

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();

        //

        //add Identity Services


        var app = builder.Build();



        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
        }

        app.UseStaticFiles();
        app.UseAntiforgery();
       

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();
        app.MapAdditionalIdentityEndpoints();

        app.Run();
    }
}