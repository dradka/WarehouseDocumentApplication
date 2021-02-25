using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WarehouseDocumentApplication.Models;
using WarehouseDocumentApplication.Utils;

namespace WarehouseDocumentApplication.PositionEditor
{
    public class PositionEditorControlClass : BaseControlClass
    {
        private readonly WarehouseDocumentsDatabaseDbContextFactory _dbContextFactory;
        private const decimal maxPositionValue = 9_999_999_999_999.99M;

        public int HeaderId { get; set; }
        public int? PositionId { get; set; }
        private WarehouseDocumentPosition _positionItem;
        public WarehouseDocumentPosition PositionItem
        {
            get { return _positionItem; }
            set { SetProperty(ref _positionItem, value); }
        }

        private bool _loadingData;
        public bool LoadingData
        {
            get { return _loadingData; }
            set { SetProperty(ref _loadingData, value); }
        }

        public PositionEditorControlClass(WarehouseDocumentsDatabaseDbContextFactory dbContext)
        {
            _dbContextFactory = dbContext;
        }

        public async Task LoadDataAsync()
        {
            LoadingData = true;
            try
            {
                if (PositionId.HasValue)
                {
                    using var context = _dbContextFactory.CreateDbContext();
                    if (context == null) return;
                    var first = await context.WarehouseDocumentPositions
                        .Where(p => p.Id == PositionId).FirstOrDefaultAsync();
                    PositionItem = first;
                }
                else
                {
                    PositionItem = new WarehouseDocumentPosition { HeaderId = HeaderId };
                }
            }
            catch (Exception)
            {
                MessageBoxUtils.ShowErrorMessage("Wystąpił błąd podczas odczytu danych");
            }
            LoadingData = false;
        }

        public (bool, string) ValidateProductName()
        {
            if (string.IsNullOrEmpty(PositionItem.ProductName))
                return (false, "Uzupełnij nazwę produktu");
            return (true, string.Empty);
        }

        public (bool, string) ValidateQuantity()
        {
            if (PositionItem.Quantity == default(int))
                return (false, "Podaj ilość");
            return (true, string.Empty);
        }

        public (bool, string) ValidateNetPrice()
        {
            if (PositionItem.NetPrice == default(decimal))
                return (false, "Podaj cenę netto");
            else if (PositionItem.NetPrice * PositionItem.Quantity > maxPositionValue)
                return (false, "Łączna wartość netto przekracza dozwoloną wartość");
            return (true, string.Empty);
        }

        public (bool, string) ValidateGrossPrice()
        {
            if (PositionItem.GrossPrice == default(decimal))
                return (false, "Podaj cenę brutto");
            else if (PositionItem.GrossPrice * PositionItem.Quantity > maxPositionValue)
                return (false, "Łączna wartość brutto przekracza dozwoloną wartość");
            return (true, string.Empty);
        }

        public async Task<bool> SaveChanges()
        {
            bool success;
            try
            {
                if (!PositionId.HasValue)
                {
                    success = await InsertData();
                }
                else
                {
                    success = await UpdateData();
                }
            }
            catch(Exception)
            {
                success = false;
                MessageBoxUtils.ShowErrorMessage("Wystąpił błąd podczas zapsisywania zmian");
            }
            return success;
        }

        public async Task<bool> InsertData()
        {
            using var context = _dbContextFactory.CreateDbContext();
            if (context == null) return false;
            using var transaction = context.Database.BeginTransaction();            
            int id = await context.GetWarehouseDocumentPositionSequenceNextValue();
            PositionItem.Id = id;
            PositionItem.NetValue = PositionItem.Quantity * PositionItem.NetPrice;
            PositionItem.GrossValue = PositionItem.Quantity * PositionItem.GrossPrice;
            context.WarehouseDocumentPositions.Add(PositionItem);
            await context.SaveChangesAsync();
            (bool Success, string ErrorMessage) errorData = (true, string.Empty);
            errorData = await PriceCalculator.CalculateWarehouseDocumentHeaderPrice(context, HeaderId);
            if (errorData.Success)
                await transaction.CommitAsync();
            else
            {
                await transaction.RollbackAsync();
                MessageBoxUtils.ShowErrorMessage(errorData.ErrorMessage);
            }
            return errorData.Success;
        }

        public async Task<bool> UpdateData()
        {
            using var context = _dbContextFactory.CreateDbContext();
            if (context == null) return false;
            using var transaction = context.Database.BeginTransaction();
            var first = await context.WarehouseDocumentPositions
                   .Where(p => p.Id == PositionId).FirstOrDefaultAsync();
            first.ProductName = PositionItem.ProductName;
            first.Quantity = PositionItem.Quantity;
            first.NetPrice = PositionItem.NetPrice;
            first.GrossPrice = PositionItem.GrossPrice;
            first.NetValue = PositionItem.Quantity * PositionItem.NetPrice;
            first.GrossValue = PositionItem.Quantity * PositionItem.GrossPrice;
            await context.SaveChangesAsync();
            (bool Success, string ErrorMessage) errorData = (true, string.Empty);
            errorData = await PriceCalculator.CalculateWarehouseDocumentHeaderPrice(context, HeaderId);
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
