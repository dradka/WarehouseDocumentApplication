using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseDocumentApplication.Models;
using WarehouseDocumentApplication.Utils;

namespace WarehouseDocumentApplication.HeaderEditor
{
    public class HeaderEditorControlClass : BaseControlClass
    {
        private readonly WarehouseDocumentsDatabaseDbContextFactory _dbContextFactory;

        public int? HeaderId { get; set; }
        private WarehouseDocumentHeader _headerItem;
        public WarehouseDocumentHeader HeaderItem 
        { 
            get { return _headerItem; }
            set { SetProperty(ref _headerItem, value); }
        }

        private bool _loadingData;
        public bool LoadingData
        {
            get { return _loadingData; }
            set { SetProperty(ref _loadingData, value); }
        }

        public HeaderEditorControlClass(WarehouseDocumentsDatabaseDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task LoadDataAsync()
        {
            LoadingData = true;
            try
            {
                if (HeaderId.HasValue)
                {
                    using var context = _dbContextFactory.CreateDbContext();
                    if (context == null) return;
                    var first = await context.WarehouseDocumentHeaders
                        .Where(p => p.Id == HeaderId).FirstOrDefaultAsync();
                    HeaderItem = first;
                }
                else
                {
                    HeaderItem = new WarehouseDocumentHeader { IssueDate = DateTime.Today };
                }
            }
            catch (Exception)
            {
                MessageBoxUtils.ShowErrorMessage("Wystąpił błąd podczas odczytu danych");
            }
            LoadingData = false;
        }

        public (bool, string) ValidateCustomerNumber()
        {
            if (string.IsNullOrEmpty(HeaderItem.CustomerNumber))
                return (false, "Uzupełnij numer klienta");
            return (true, string.Empty);
        }

        public async Task<(bool, string)> ValidateDocumentName()
        {
            try
            {
                if (string.IsNullOrEmpty(HeaderItem.DocumentName))
                    return (false, "Uzupełnij nazwę dokumentu");

                bool isNew = !HeaderId.HasValue;
                string documentName = HeaderItem.DocumentName;
                int id = HeaderItem.Id;

                using var context = _dbContextFactory.CreateDbContext();
                if (context == null) return (false, string.Empty);
                var items = await context.WarehouseDocumentHeaders
                            .Where(p => p.DocumentName == documentName
                                       && (isNew || p.Id != id))
                            .Select(p => p.Id).ToListAsync();

                if (items.Any())
                    return (false, "Podaj unikalną nazwę dokumentu");
                return (true, string.Empty);
            }
            catch(Exception)
            {
                MessageBoxUtils.ShowErrorMessage("Wystąpił błąd podczas odczytu danych");
            }
            return (false, string.Empty);
        }

        public async Task SaveChanges()
        {
            try
            {
                if (!HeaderId.HasValue)
                {
                    await InsertData();
                }
                else
                {
                    await UpdateData();
                }
            }
            catch(Exception)
            {
                MessageBoxUtils.ShowErrorMessage("Wystąpił błąd podczas zapisywania zmian");
            }
        }

        public async Task InsertData()
        {
            using var context = _dbContextFactory.CreateDbContext();
            if (context == null) return;
            int id = await context.GetWarehouseDocumentHeaderSequenceNextValue();
            HeaderItem.Id = id;
            HeaderItem.CustomerNumber ??= string.Empty;
            HeaderItem.DocumentName ??= string.Empty;
            context.WarehouseDocumentHeaders.Add(HeaderItem);
            await context.SaveChangesAsync();
        }

        public async Task UpdateData()
        {
            using var context = _dbContextFactory.CreateDbContext();
            if (context == null) return;
            var first = await context.WarehouseDocumentHeaders
                   .Where(p => p.Id == HeaderId).FirstOrDefaultAsync();
            first.CustomerNumber = HeaderItem.CustomerNumber ?? string.Empty;
            first.DocumentName = HeaderItem.DocumentName ?? string.Empty;
            await context.SaveChangesAsync();
        }
    }
}
