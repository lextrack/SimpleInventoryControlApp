using SimpleInventoryStockApp.Views;

namespace SimpleInventoryStockApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(InventoryDetailsPage), typeof(InventoryDetailsPage));
    }
}