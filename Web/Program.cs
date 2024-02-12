using Web.Components;
using Base.Singletons;
using Base.IServices;
using Base.Services;
using Base.IRepositories;
using Base.Repositories;
using Blazored.Toast;
using Blazored.Modal;
using Base.Interop;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            //Singgleton Declaration
            builder.Services.AddSingleton<Names>();
            //Scoped Declaration
            builder.Services.AddScoped<LazyLoad>();
            builder.Services.AddScoped<IDatabase, Database>();
            builder.Services.AddScoped<IService, Service>();
            //Extras
            builder.Services.AddBlazoredModal();
            builder.Services.AddBlazoredToast();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddAdditionalAssemblies(new[] { typeof(Base._Imports).Assembly });

            app.Run();
        }
    }
}
