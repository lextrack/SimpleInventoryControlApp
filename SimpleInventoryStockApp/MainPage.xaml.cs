using SimpleInventoryStockApp.ViewModels;

namespace SimpleInventoryStockApp;

public partial class MainPage : ContentPage
{

    public MainPage(InventoryListViewModel inventoryListViewModel)
    {
        InitializeComponent();
        BindingContext = inventoryListViewModel;
    }
}

