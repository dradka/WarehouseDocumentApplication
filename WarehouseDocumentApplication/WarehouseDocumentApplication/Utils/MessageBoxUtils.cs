using System.Windows.Forms;

namespace WarehouseDocumentApplication.Utils
{
    public static class MessageBoxUtils
    {
        public static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Błąd", MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
        }
    }
}
