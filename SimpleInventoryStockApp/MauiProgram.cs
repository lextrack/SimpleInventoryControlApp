using SimpleInventoryStockApp.Services;
using SimpleInventoryStockApp.ViewModels;
using SimpleInventoryStockApp.Views;

namespace SimpleInventoryStockApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "inventory.db3");
        builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<InventoryService>(s, dbPath));

        builder.Services.AddSingleton<InventoryListViewModel>();
        builder.Services.AddTransient<InventoryDetailsViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<InventoryDetailsPage>();

        return builder.Build();
	}
}
