using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using WarehouseDocumentApplication.Configuration;
using WarehouseDocumentApplication.Utils;

namespace WarehouseDocumentApplication.Login
{
    public class LoginControlClass : BaseControlClass
    {
        private const string connectionConfigurationFileName = "ConnectionSettings.json";
        public RootObject ConfigurationItem { get; set; }

        private bool _loadingData;
        public bool LoadingData
        {
            get { return _loadingData; }
            set { SetProperty(ref _loadingData, value); }
        }

        public async Task DeserializeConfiguration()
        {
            LoadingData = true;
            try
            {
                using FileStream fileStream = File.Open(connectionConfigurationFileName, FileMode.OpenOrCreate);
                ConfigurationItem = await JsonSerializer.DeserializeAsync<RootObject>(fileStream);
            }
            catch(Exception)
            {
                MessageBoxUtils.ShowErrorMessage("Wystąpił błąd podczas odczytywania pliku konfiguracyjnego");
            }
            LoadingData = false;
        }

        public async Task SerializeConfiguration()
        {
            try
            {
                RootObject configuration = ConfigurationItem;
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                using FileStream fileStream = File.Create(connectionConfigurationFileName);
                await JsonSerializer.SerializeAsync(fileStream, configuration, options);
            }
            catch (Exception)
            {
                MessageBoxUtils.ShowErrorMessage("Wystąpił błąd podczas zapisywania pliku konfiguracyjnego");
            }
}
    }
}
