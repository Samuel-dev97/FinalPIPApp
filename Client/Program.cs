using AntDesign.ProLayout;
using Blazored.LocalStorage;
using Client.Interfaces;
using Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Client.Extensions.AuthProviders;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");


            builder.Services.AddScoped(sp =>
             { var apiUrl = new Uri(builder.Configuration["apiUrl"]); return new HttpClient() { BaseAddress = apiUrl }; });

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddAntDesign();
            //builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));

            builder.Services.AddScoped<IHttpService, HttpService>()
                .AddScoped<IPayGradeServiceAsync, PayGradeServiceAsync>()
                .AddScoped<IEmployeeIncentiveMonthliesServiceAsync, EmployeeIncentiveMonthliesServiceAsync>()
                .AddScoped<IEmployeeIncentivesServiceAsync, EmployeeIncentivesServiceAsync>()
                .AddScoped<IDepartmentServiceAsync, DepartmentServiceAsync>()
                .AddScoped<IDepartmentBudgetsServiceAsync, DepartmentBudgetsServiceAsync>()
                .AddScoped<IEmployeeServiceAsync, EmployeeServiceAsync>()
                .AddScoped<IPenaltiesServiceAsync, PenaltiesServiceAsync>()
                .AddScoped<IChartService, ChartService>()
                .AddScoped<IProjectService, ProjectService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IProfileService, ProfileService>()
                .AddScoped<IAuthenticationRepositoryAsync, AuthenticationRepositoryAsync>()
                .AddScoped<IReportRepositoryAsync, ReportRepositoryAsync>();

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            builder.Services.AddHttpClientInterceptor();
            //builder.Services.AddSyncfusionBlazor();


            await builder.Build().RunAsync();
        }
    }
}