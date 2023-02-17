
namespace U3A
{

    public static void UseBrowserLocalisation(this IBlazorApplicationBuilder app) {
        var browserLocale = ((IJSInProcessRuntime)JSRuntime.Current).Invoke<string>("blazoredLocalisation.getBrowserLocale");
        var culture = new CultureInfo(browserLocale);

        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
    }

}