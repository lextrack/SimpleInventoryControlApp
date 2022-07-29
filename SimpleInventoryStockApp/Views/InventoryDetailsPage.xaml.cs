using SimpleInventoryStockApp.ViewModels;

namespace SimpleInventoryStockApp.Views;

public partial class InventoryDetailsPage : ContentPage
{
    public InventoryDetailsPage(InventoryDetailsViewModel inventoryDetailsViewModel)
    {
        InitializeComponent();
        BindingContext = inventoryDetailsViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        // Do fanciness 
        base.OnNavigatedTo(args);
    }
}