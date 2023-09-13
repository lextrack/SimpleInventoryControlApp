using CommunityToolkit.Mvvm.ComponentModel;
using SimpleInventoryStockApp.Models;
using System.Web;

namespace SimpleInventoryStockApp.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class InventoryDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty]
        Inventory inventory;

        [ObservableProperty]
        int id;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));
            Inventory = App.InventoryService.GetInventory(Id);
        }
    }
}
