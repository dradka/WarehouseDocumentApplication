using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseDocumentApplication.Utils;

namespace WarehouseDocumentApplication.HeaderEditor
{
    public partial class HeaderEditorForm : BaseForm, IHasControlClass<HeaderEditorControlClass>
    {
        public new HeaderEditorControlClass ControlClass
        {
            get { return base.ControlClass as HeaderEditorControlClass; }
            set { base.ControlClass = value; }
        }

        public HeaderEditorForm(HeaderEditorControlClass controlClass)
        {
            InitializeComponent();
            ControlClass = controlClass;
        }

        public void AddDataBindings()
        {
            Binding issueDateBinding = new Binding(nameof(issueDatePicker.Value),
                headerBindingSource, nameof(ControlClass.HeaderItem.IssueDate), false, 
                DataSourceUpdateMode.OnPropertyChanged);
            issueDatePicker.DataBindings.Add(issueDateBinding);

            customerNumberTextBox.DataBindings.Add(nameof(customerNumberTextBox.Text),
                headerBindingSource, nameof(ControlClass.HeaderItem.CustomerNumber));
            documentNameTextBox.DataBindings.Add(nameof(documentNameTextBox.Text),
                headerBindingSource, nameof(ControlClass.HeaderItem.DocumentName));
        }

        private async void HeaderEditorForm_LoadCompleted()
        {
            await ControlClass.LoadDataAsync();
            headerBindingSource.DataSource = new[] { ControlClass.HeaderItem };
            AddDataBindings();
        }

        private async Task<bool> ValidateData()
        {
            bool isValid = true;
            (bool IsValid, string ErrorMessage) errorData = ControlClass.ValidateCustomerNumber();
            if(!errorData.IsValid)
            {
                isValid = false;
                errorProvider.SetError(customerNumberTextBox, errorData.ErrorMessage);
            }
            else
            {
                errorProvider.SetError(customerNumberTextBox, string.Empty);
            }
                   
            errorData = await ControlClass.ValidateDocumentName();
            if (!errorData.IsValid)
            {
                isValid = false;
                errorProvider.SetError(documentNameTextBox, errorData.ErrorMessage);
            }
            else
            {
                errorProvider.SetError(documentNameTextBox, string.Empty);
            }
                
            return isValid;
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            if (ControlClass.LoadingData)
                return;
            if(await ValidateData())
            {
                await ControlClass.SaveChanges();
                DialogResult = DialogResult.OK;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
