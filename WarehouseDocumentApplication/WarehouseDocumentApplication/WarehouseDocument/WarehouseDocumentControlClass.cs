using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseDocumentApplication.Models;
using WarehouseDocumentApplication.Utils;

namespace WarehouseDocumentApplication.WarehouseDocument
{
    public class WarehouseDocumentControlClass : BaseControlClass
    {
        private readonly WarehouseDocumentsDatabaseDbContextFactory _dbContextFactory;
        public WarehouseDocumentFilterClass Filter { get; set; }        

        private SortableBindingList<WarehouseDocumentHeader> _items;
        public SortableBindingList<WarehouseDocumentHeader> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private SortableBindingList<WarehouseDocumentPosition> _items2;
        public SortableBindingList<WarehouseDocumentPosition> Items2
        {
            get { return _items2; }
            set { SetProperty(ref _items2, value); }
        }

        private WarehouseDocumentHeader _currentItem;
        public WarehouseDocumentHeader CurrentItem
        {
            get { return _currentItem; }
            set { SetProperty(ref _currentItem, value); }
        }

        private WarehouseDocumentPosition _currentItem2;
        public WarehouseDocumentPosition CurrentItem2
        {
            get { return _currentItem2; }
            set { SetProperty(ref _currentItem2, value); }
        }

        private bool _loadingData;
        public bool LoadingData
        {
            get { return _loadingData; }
            set { SetProperty(ref _loadingData, value); }
        }

        private bool _loadingData2;
        public bool LoadingData2
        {
            get { return _loadingData2; }
            set { SetProperty(ref _loadingData2, value); }
        }

        public IList<int> SelectedIds { get; set; }
        public IList<int> SelectedIds2 { get; set; }

        public WarehouseDocumentControlClass(WarehouseDocumentsDatabaseDbContextFactory dbContextFactory, WarehouseDocumentFilterClass filter)
        {
            _dbContextFactory = dbContextFactory;
            Filter = filter;
            Items = new SortableBindingList<WarehouseDocumentHeader>(new List<WarehouseDocumentHeader>(), nameof(CurrentItem.IssueDate), ListSortDirection.Ascending, true);
            Items2 = new SortableBindingList<WarehouseDocumentPosition>(new List<WarehouseDocumentPosition>(), nameof(CurrentItem2.ProductName), ListSortDirection.Ascending, true);
           
        }

        public async Task LoadSortedDataAsync(string propertyName, ListSortDirection sortDirection, bool sorting)
        {
            LoadingData = true;
            try
            {
                SortableBindingList<WarehouseDocumentHeader> items
                    = new SortableBindingList<WarehouseDocumentHeader>(new List<WarehouseDocumentHeader>(), propertyName, sortDirection, sorting);
                var filter = Filter;
                using var dbContext = _dbContextFactory.CreateDbContext();
                if (filter != null && dbContext != null)
                {
                    var data = await dbContext.WarehouseDocumentHeaders
                        .Where(p => p.CustomerNumber.StartsWith(filter.CustomerNumber ?? string.Empty)
                            && p.DocumentName.StartsWith(filter.DocumentName ?? string.Empty)
                            && (!filter.IsDateStartEnabled || p.IssueDate >= filter.DateStart)
                            && (!filter.IsDateStopEnabled || p.IssueDate <= filter.DateStop))
                        .ToListAsync();
                    if (data.Any())
                    {
                        items = new SortableBindingList<WarehouseDocumentHeader>(data, propertyName, sortDirection, sorting);
                    }
                }
                Items = items;
                
            }
            catch(Exception)
            {
                MessageBoxUtils.ShowErrorMessage("Wystąpił błąd podczas odczytu danych");
            }
            LoadingData = false;
        }

        public async Task LoadSortedData2(string propertyName, ListSortDirection sortDirection, bool sorting)
        {
            LoadingData2 = true;
            try {
                SortableBindingList<WarehouseDocumentPosition> items2
                    = new SortableBindingList<WarehouseDocumentPosition>(new List<WarehouseDocumentPosition>(), propertyName, sortDirection, sorting);
                var current = CurrentItem;
                using var dbContext = _dbContextFactory.CreateDbContext();
                if (current != null && dbContext != null)
                {
                    int headerId = current.Id;
                    var positions = await dbContext.WarehouseDocumentPositions.Where(p => p.HeaderId == headerId
                       && p.ProductName.StartsWith(Filter.ProductName ?? string.Empty)).ToListAsync();
                    if (positions != null)
                    {
                        items2 = new SortableBindingList<WarehouseDocumentPosition>(positions, propertyName, sortDirection, sorting);
                    }
                }
                Items2 = items2;
            }
            catch(Exception)
            {
                MessageBoxUtils.ShowErrorMessage("Wystąpił błąd podczas odczytu danych");
            }
            LoadingData2 = false;
        }

        public async Task<bool> DeleteWarehouseDocumentHeaders()
        {
            try
            {
                using var context = _dbContextFactory.CreateDbContext();
                var selectedIds = SelectedIds;
                if (context == null || selectedIds == null || !selectedIds.Any()) return false;
                if (MessageBox.Show($"Czy na pewno usunąć zaznaczone nagłówki dokumentów magazynowych" +
                    $" wraz z pozycjami? ({selectedIds.Count})", "Uwaga", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var positionsToDelete = await context.WarehouseDocumentPositions.Where(p => selectedIds.Contains(p.HeaderId))
                        .ToArrayAsync();
                    var headersToDelete = await context.WarehouseDocumentHeaders.Where(p => selectedIds.Contains(p.Id))
                        .ToArrayAsync();
                    using var transaction = context.Database.BeginTransaction();
                    if (positionsToDelete.Any())
                    {
                        context.WarehouseDocumentPositions.RemoveRange(positionsToDelete);
                        await context.SaveChangesAsync();
                    }
                    if (headersToDelete.Any())
                    {
                        context.WarehouseDocumentHeaders.RemoveRange(headersToDelete);
                        await context.SaveChangesAsync();
                    }
                    await transaction.CommitAsync();
                    return true;
                }
            }
            catch(Exception)
            {
                MessageBoxUtils.ShowErrorMessage("Wystąpił błąd podczas usuwania danych");
            }
            return false;
        }

        public async Task<bool> DeleteWarehouseDocumentPositions()
        {
            try
            {
                var current = CurrentItem;
                var selectedIds2 = SelectedIds2;
                if (current == null || selectedIds2 == null || !selectedIds2.Any()) return false;
                if (MessageBox.Show($"Czy na pewno usunąć zaznaczone pozycje dokumentów magazynowych?" +
                    $" ({selectedIds2.Count})", "Uwaga", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    using var context = _dbContextFactory.CreateDbContext();
                    if (context != null)
                    {
                        using var transaction = context.Database.BeginTransaction();

                        var itemsToDelete2 = await context.WarehouseDocumentPositions.Where(p => selectedIds2.Contains(p.Id)).ToArrayAsync();
                        (bool Success, string ErrorMessage) errorData = (true, string.Empty);
                        if (itemsToDelete2.Any())
                        {
                            context.WarehouseDocumentPositions.RemoveRange(itemsToDelete2);
                            await context.SaveChangesAsync();
                            errorData = await PriceCalculator.CalculateWarehouseDocumentHeaderPrice(context, current.Id);
                        }
                        if (errorData.Success)
                            await transaction.CommitAsync();
                        else
                        {
                            await transaction.RollbackAsync();
                            MessageBoxUtils.ShowErrorMessage(errorData.ErrorMessage);
                        }
                        return errorData.Success;
                    }
                }
            }
            catch (Exception)
            {
                MessageBoxUtils.ShowErrorMessage("Wystąpił błąd podczas usuwania danych");
            }
            return false;
        }
    }
}
