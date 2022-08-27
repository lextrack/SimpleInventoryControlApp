using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SimpleInventoryStockApp.Models;
using SimpleInventoryStockApp.Services;
using SimpleInventoryStockApp.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SimpleInventoryStockApp.ViewModels
{
    public partial class InventoryListViewModel : BaseViewModel
    {
        const string editButtonText = "Update";
        const string createButtonText = "Add item";
        public ObservableCollection<Inventory> Inventories { get; set; } = new ();

        public InventoryListViewModel()
        {
            Title = "Inventory Control Register";
            AddEditButtonText = createButtonText;
            GetInventoryList().Wait();
        }

        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        string item;

        [ObservableProperty]
        string qty;

        [ObservableProperty]
        string price;

        [ObservableProperty]
        string location;

        [ObservableProperty]
        string supplier;

        [ObservableProperty]
        string observations;

        [ObservableProperty]
        string date;

        [ObservableProperty]
        string addEditButtonText;

        [ObservableProperty]
        int inventoryId;

        [RelayCommand]
        public async Task GetInventoryList()
        {
            if (IsLoading) return;
            try
            {
                IsLoading = true;
                if (Inventories.Any()) Inventories.Clear();

                var inventories = App.InventoryService.GetInventories();

                foreach (var inventory in inventories) Inventories.Add(inventory);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get the inventory: {ex.Message}");
                await Shell.Current.DisplayAlert("Error", "Failed to retrive the inventory.", "Ok");
            }
            finally
            {
                IsLoading = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GetInventoryDetails(int id)
        {
            if (id == 0) return;

            await Shell.Current.GoToAsync($"{nameof(InventoryDetailsPage)}?Id={id}", true);
        }

        [RelayCommand]
        async Task SaveInventory()
        {
            if (string.IsNullOrEmpty(Item) || string.IsNullOrEmpty(Qty) || string.IsNullOrEmpty(Price))
            {
                await Shell.Current.DisplayAlert("Invalid Data", "At the very least, you must insert an item, quantity and price", "Ok");
                return;
            }

            var inventory = new Inventory
            {
                Item = Item,
                Qty = qty,
                Price = Price,
                Location = Location,
                Supplier = Supplier,
                Observations = Observations,
                Date = Date
            };

            if (InventoryId != 0)
            {
                inventory.Id = InventoryId;
                App.InventoryService.UpdateInventory(inventory);
                await Shell.Current.DisplayAlert("Info", App.InventoryService.StatusMessage, "Ok");
            }
            else
            {
                App.InventoryService.AddInventory(inventory);
                await Shell.Current.DisplayAlert("Info", App.InventoryService.StatusMessage, "Ok");
            }

            await GetInventoryList();
            await ClearForm();
        }

        [RelayCommand]
        async Task DeleteInventory(int id)
        {
            if (id == 0)
            {
                await Shell.Current.DisplayAlert("Invalid Record", "Please try again", "Ok");
                return;
            }
            var result = App.InventoryService.DeleteInventory(id);
            if (result == 0) await Shell.Current.DisplayAlert("Failed", "Please insert valid data", "Ok");
            else
            {
                await Shell.Current.DisplayAlert("Deletion Successful", "Record Removed Successfully", "Ok");
                await GetInventoryList();
            }
        }

        [RelayCommand]
        async Task UpdateInventory(int id)
        {
            AddEditButtonText = editButtonText;
            return;
        }

        [RelayCommand]
        async Task SetEditMode(int id)
        {
            AddEditButtonText = editButtonText;
            InventoryId = id;
            var inventory = App.InventoryService.GetInventory(id);
            Item = inventory.Item;
            Qty = inventory.Qty;
            Price = inventory.Price;
            Location = inventory.Location;
            Supplier = inventory.Supplier;
            Observations = inventory.Observations;
            Date = inventory.Date;
        }

        [RelayCommand]
        async Task ClearForm()
        {
            AddEditButtonText = createButtonText;
            InventoryId = 0;
            Item = string.Empty;
            Qty = string.Empty;
            Price = string.Empty;
            Location = string.Empty;
            Supplier = string.Empty;
            Observations = string.Empty;
            Date = string.Empty;
        }
    }
}
