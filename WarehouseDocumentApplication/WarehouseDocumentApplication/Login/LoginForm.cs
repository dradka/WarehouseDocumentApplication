using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;
using WarehouseDocumentApplication.GithubInformation;
using WarehouseDocumentApplication.Utils;

namespace WarehouseDocumentApplication.Login
{
    public partial class LoginForm : BaseForm, IHasControlClass<LoginControlClass>
    {
        private readonly IServiceProvider _serviceProvider;

        public new LoginControlClass ControlClass
        {
            get { return base.ControlClass as LoginControlClass; }
            set { base.ControlClass = value; }
        }

        public LoginForm(LoginControlClass loginControlClass, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            ControlClass = loginControlClass;
            _serviceProvider = serviceProvider;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ControlClass.LoadingData)
                return;
            if (string.IsNullOrEmpty(connectionStringTextBox.Text))
            {
                MessageBoxUtils.ShowErrorMessage("Uzupełnij dane połączenia");
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void githubInformationButton_Click(object sender, EventArgs e)
        {
            var githubInformationForm = _serviceProvider.GetRequiredService<GithubInformationForm>();
            githubInformationForm.ShowDialog();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var text = connectionStringTextBox.Text;
            if(!string.IsNullOrEmpty(text))
               ControlClass.ConfigurationItem.ConnectionStrings.WarehouseDocumentsDatabase = connectionStringTextBox.Text;
        }

        private async void LoginForm_LoadCompleted()
        {
            await ControlClass.DeserializeConfiguration();
            connectionStringTextBox.Text = ControlClass.ConfigurationItem.ConnectionStrings.WarehouseDocumentsDatabase;
        }
    }
}
