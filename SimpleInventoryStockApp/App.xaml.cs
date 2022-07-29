using SimpleInventoryStockApp.Services;

namespace SimpleInventoryStockApp;

public partial class App : Application
{
    public static InventoryService InventoryService { get; private set; }

    public App(InventoryService inventoryService)
    {
        InitializeComponent();

        MainPage = new AppShell();
        InventoryService = inventoryService;
    }

}
