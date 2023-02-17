using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using U3A.Areas.Identity;
using U3A.Database;
using U3A.Model;
using U3A.Services;
using U3A.UI.Reports;
using DevExpress.XtraReports.Web.Extensions;
using DevExpress.XtraReports.Services;
using Finbuckle.MultiTenant;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Globalization;
using Finbuckle.MultiTenant.Stores;
using Azure.Identity;
using Eway.Rapid.Abstractions.Request;
using DevExpress.XtraCharts;
using DevExpress.Blazor.Reporting;
using DevExpress.AspNetCore.Reporting;
using DevExpress.XtraReports.Web.ReportDesigner.Services;
using U3A.UI.Reports.Pages;
using DevExpress.Blazor;
using Blazored.LocalStorage;
using U3A.UI.Forms;
using DevExpress.Office.Services;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Components.Server.Circuits;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Finbuckle Multi-tenant service. NB: we are using a custom TenantInfo
string? MultiTenantConnectionString = builder.Configuration.GetConnectionString("TenantConnectionString");
string? defaultTenant = builder.Environment.IsDevelopment() ? "localdemo" : "demo";
builder.Services.AddDbContext<TenantStoreDbContext>(options =>
    options.UseSqlServer(MultiTenantConnectionString)
);
builder.Services.AddMultiTenant<TenantInfoEx>()
        .WithHostStrategy("__tenant__.*")
        .WithStaticStrategy(defaultTenant)
        .WithEFCoreStore<TenantStoreDbContext, TenantInfoEx>();

// U3ADbContextFactory
builder.Services.AddDbContextFactory<U3ADbContext>(options => {
    options.UseSqlServer();
}, ServiceLifetime.Scoped);

// Microsoft Core Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<U3ADbContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor(options => {
    options.DetailedErrors = false;
    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
});

builder.Services.AddSingleton<CircuitHandler>(new CircuitHandlerService());

builder.Services.AddScoped<AuthenticationStateProvider,
    RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();

builder.Services.AddDevExpressBlazor();
builder.Services.AddDevExpressBlazorReporting();
// Register the storage after the AddDevExpressBlazorReporting method call.
builder.Services.AddScoped<ReportStorageWebExtension, CustomReportStorageWebExtension>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<IScopedDbContextProvider<U3ADbContext>, ScopedDbContextProvider<U3ADbContext>>();
builder.Services.AddSingleton<IObjectDataSourceInjector, ObjectDataSourceInjector>();
builder.Services.AddSingleton<PreviewReportCustomizationService, CustomPreviewReportCustomizationService>();
builder.Services.AddTransient<ReportRepository>();
builder.Services.ConfigureReportingServices(configurator => {
    configurator.ConfigureReportDesigner((reportDesignerConfigurator) => {
        reportDesignerConfigurator.RegisterObjectDataSourceConstructorFilterService<ObjectDataSourceConstructorFilterService>();
        reportDesignerConfigurator.RegisterObjectDataSourceWizardTypeProvider<ObjectDataSourceWizardTypeProvider>();
    });
    configurator.ConfigureWebDocumentViewer(viewerConfigurator => {
        viewerConfigurator.UseCachedReportSourceBuilder();
    });
});


builder.Services.AddDevExpressServerSideBlazorReportViewer();
builder.Services.Configure<DevExpress.Blazor.Configuration.GlobalOptions>(options => {
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
    options.SizeMode = DevExpress.Blazor.SizeMode.Small;
});

//Allows accessing HttpContext in Blazor (Required for Finbuckle)
builder.Services.AddHttpContextAccessor();

// ASP.NET Core Identity email sender
builder.Services.AddScoped<IEmailSender, IdentityEmailSender>();

builder.Services.AddLocalization();

// Get / Set local storage data
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<EwayConnectionSingleton>();
#if !DEBUG
builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"]);
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
#if DEBUG
    TelemetryConfiguration.Active.DisableTelemetry = true;
    TelemetryDebugWriter.IsTracingDisabled = true;
#endif
    app.UseMigrationsEndPoint();
}
else {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization("en-AU");
app.UseWebSockets();
app.UseHttpsRedirection();

app.UseMultiTenant(); //Finbuckle
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseDevExpressServerSideBlazorReportViewer();


app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/Public/{*path:nonfile}", "/Public/_PublicHost");
app.MapFallbackToPage("/_Host");

app.Run();
