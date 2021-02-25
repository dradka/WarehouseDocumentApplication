using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseDocumentApplication.Models;

namespace WarehouseDocumentApplication.Utils
{
    public static class PriceCalculator
    {
        public const decimal maxHeaderValue = 9_999_999_999_999_999.99M;

        public static async Task<(bool, string)> CalculateWarehouseDocumentHeaderPrice(WarehouseDocumentsDatabaseContext context, int headerId)
        {
            var header = await context.WarehouseDocumentHeaders.Where(p => p.Id == headerId).FirstOrDefaultAsync();
            var positions = context.WarehouseDocumentPositions.Where(p => p.HeaderId == headerId);
            header.NetValue = positions.Sum(p => p.NetValue);
            header.GrossValue = positions.Sum(p => p.GrossValue);
            if (header.NetValue > maxHeaderValue)
            {
                return (false, "Łączna cena netto produktów dla nagłówka dokumentu przekracza dozwoloną wartość");
            }
            else if (header.GrossValue > maxHeaderValue)
            {
                return (false, "Łączna cena brutto produktów dla nagłówka dokumentu przekracza dozwoloną wartość");
            }
            else
            {
                await context.SaveChangesAsync();
                return (true, string.Empty);
            }
        }
    }
}
