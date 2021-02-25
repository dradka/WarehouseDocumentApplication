using System;
using System.Windows.Forms;
using WarehouseDocumentApplication.Utils;

namespace WarehouseDocumentApplication.PositionEditor
{
    public partial class PositionEditorForm : BaseForm, IHasControlClass<PositionEditorControlClass>
    {
        public new PositionEditorControlClass ControlClass
        {
            get { return base.ControlClass as PositionEditorControlClass; }
            set { base.ControlClass = value; }
        }

        private Binding quantityBinding;

        public PositionEditorForm(PositionEditorControlClass controlClass)
        {
            InitializeComponent();
            ControlClass = controlClass;
        }

        public void AddDataBindings()
        {
            productNameTextBox.DataBindings.Add(nameof(productNameTextBox.Text),
                positionBindingSource, nameof(ControlClass.PositionItem.ProductName));

            quantityBinding = new Binding(nameof(quantityTextBox.Text),
                positionBindingSource, nameof(ControlClass.PositionItem.Quantity), true,
                DataSourceUpdateMode.OnValidation);
            quantityBinding.Parse += new ConvertEventHandler(QuantityBinding_Parse);
            quantityBinding.Format += new ConvertEventHandler(QuantityBinding_Format);
            quantityTextBox.DataBindings.Add(quantityBinding);

            Binding netPriceBinding = new Binding(nameof(netPriceTextBox.Text),
                positionBindingSource, nameof(ControlClass.PositionItem.NetPrice), false,
                DataSourceUpdateMode.OnValidation);
            netPriceBinding.Parse += new ConvertEventHandler(Price_Parse);
            netPriceBinding.Format += new ConvertEventHandler(Price_Format);
            netPriceTextBox.DataBindings.Add(netPriceBinding);

            Binding grossPriceBinding = new Binding(nameof(grossPriceTextBox.Text),
                positionBindingSource, nameof(ControlClass.PositionItem.GrossPrice), true,
                DataSourceUpdateMode.OnValidation);
            grossPriceBinding.Parse += new ConvertEventHandler(Price_Parse);
            grossPriceBinding.Format += new ConvertEventHandler(Price_Format);
            grossPriceTextBox.DataBindings.Add(grossPriceBinding);
        }

        private void QuantityBinding_Parse(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType != typeof(int) || e.Value == null || !TryParseQuantity(e.Value.ToString().Trim(), out int value))
                return;
            e.Value = value;
        }

        private void QuantityBinding_Format(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType != typeof(string) || !(e.Value is int))
                return;
            e.Value = ((int)e.Value).ToString("n0");
        }


        private void Price_Parse(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType != typeof(decimal) || e.Value == null
                || !TryParsePrice(e.Value.ToString().Trim(), out decimal value))
                return;
            e.Value = value;
        }

        private void Price_Format(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType != typeof(string) || !(e.Value is decimal))
                return;
            decimal value = (decimal)e.Value;
            e.Value = value.ToString("n2");
        }

        private bool TryParseQuantity(string quantity, out int value)
        {
            bool tryParse = int.TryParse(quantity, out int returnValue);
            if (tryParse)
                value = returnValue;
            else
                value = default(int);
            return tryParse;
        }

        private bool TryParsePrice(string price, out decimal value)
        {
            bool tryParse = decimal.TryParse(price, out decimal returnValue);
            if (tryParse)
                value = returnValue;
            else
                value = default(decimal);
            return tryParse;
        }

        private bool ValidateData()
        {
            bool isValid = true;
            (bool IsValid, string ErrorMessage) errorData = ControlClass.ValidateProductName();
            if (!errorData.IsValid)
            {
                isValid = false;
                errorProvider.SetError(productNameTextBox, errorData.ErrorMessage);
            }
            else
            {
                errorProvider.SetError(productNameTextBox, string.Empty);
            }
            errorData = ControlClass.ValidateQuantity();
            if (!errorData.IsValid)
            {
                isValid = false;
                errorProvider.SetError(quantityTextBox, errorData.ErrorMessage);
            }
            else
            {
                errorProvider.SetError(quantityTextBox, string.Empty);
            }
            errorData = ControlClass.ValidateNetPrice();
            if (!errorData.IsValid)
            {
                isValid = false;
                errorProvider.SetError(netPriceTextBox, errorData.ErrorMessage);
            }
            else
            {
                errorProvider.SetError(netPriceTextBox, string.Empty);
            }
            errorData = ControlClass.ValidateGrossPrice();
            if (!errorData.IsValid)
            {
                isValid = false;
                errorProvider.SetError(grossPriceTextBox, errorData.ErrorMessage);
            }
            else
            {
                errorProvider.SetError(grossPriceTextBox, string.Empty);
            }
            return isValid;
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            if (ControlClass.LoadingData)
                return;
            bool success = ValidateData() && await ControlClass.SaveChanges();
            if(success)
            { 
                DialogResult = DialogResult.OK;
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private async void PositionEditorForm_LoadCompleted()
        {
            var controlClass = ControlClass;
            if (controlClass != null)
            {
                await controlClass.LoadDataAsync();
                positionBindingSource.DataSource = controlClass.PositionItem;
                AddDataBindings();
            }
        }
    }
}
