using AgendaContactos.Services;
using AgendaContactos.Pages;


namespace AgendaContactos;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>();

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "agenda.db3");
        builder.Services.AddSingleton(new DatabaseService(dbPath));

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<AddContactPage>();
        builder.Services.AddTransient<AgendaContactPage>();

        return builder.Build();
    }
}
