using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using WarehouseDocumentApplication.HeaderEditor;
using WarehouseDocumentApplication.Login;
using WarehouseDocumentApplication.PositionEditor;
using WarehouseDocumentApplication.WarehouseDocument;
using WarehouseDocumentApplication.Utils;
using WarehouseDocumentApplication.GithubInformation;
using System.Threading.Tasks;

namespace WarehouseDocumentApplication
{
    public class Program
    {
        [STAThread]
        static async Task Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IServiceProvider serviceProvider = GetServiceProvider();
            var loginForm = serviceProvider.GetRequiredService<LoginForm>();
            DialogResult result = loginForm.ShowDialog();
            await loginForm.ControlClass.SerializeConfiguration();
            if (result == DialogResult.OK)
            {
                var dbContextFactory = serviceProvider.GetRequiredService<WarehouseDocumentsDatabaseDbContextFactory>();
                if (dbContextFactory.CreateDbContext().Database.CanConnect())
                {
                    var form = serviceProvider.GetRequiredService<WarehouseDocumentForm>();
                    Application.Run(form);
                }
                else
                {
                    MessageBoxUtils.ShowErrorMessage("Wystapi� b��d podczas po��czenia z baz� danych");
                }
            }
        }
        private static IServiceProvider GetServiceProvider()
        {
            var serviceCollection = new ServiceCollection()
                .AddSingleton<LoginControlClass>()
                 .AddTransient<WarehouseDocumentsDatabaseDbContextFactory>()
                 .AddTransient<LoginForm>()
                 .AddTransient<GithubInformationForm>()
                 .AddTransient<WarehouseDocumentForm>()
                 .AddTransient<HeaderEditorForm>()
                 .AddTransient<PositionEditorForm>()
                 .AddTransient<GithubInformationControlClass>()
                 .AddTransient<WarehouseDocumentControlClass>()
                 .AddTransient<WarehouseDocumentFilterClass>()
                 .AddTransient<HeaderEditorControlClass>()
                 .AddTransient<PositionEditorControlClass>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
