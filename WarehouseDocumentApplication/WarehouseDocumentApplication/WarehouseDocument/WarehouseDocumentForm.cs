using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseDocumentApplication.HeaderEditor;
using WarehouseDocumentApplication.Models;
using WarehouseDocumentApplication.PositionEditor;
using WarehouseDocumentApplication.Utils;

namespace WarehouseDocumentApplication.WarehouseDocument
{
    public partial class WarehouseDocumentForm : BaseForm, IHasControlClass<WarehouseDocumentControlClass>
    {
        public new WarehouseDocumentControlClass ControlClass
        {
            get { return base.ControlClass as WarehouseDocumentControlClass; }
            set { base.ControlClass = value; }
        }
        private Binding _currentItemBinding;
        private Binding _currentItem2Binding;
        private readonly IServiceProvider _serviceProvider;

        public WarehouseDocumentForm(WarehouseDocumentControlClass controlClass, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            ControlClass = controlClass;
            _serviceProvider = serviceProvider;
            headerDataGridView.AutoGenerateColumns = false;
            positionDataGridView.AutoGenerateColumns = false;
            formBindingSource.DataSource = new[] { ControlClass };            
            filterBindingSource.DataSource = controlClass.Filter;
            _disposables.Add(this.OnPropertyChange(p => p.ControlClass.CurrentItem)
            .Subscribe(async p =>
            {
                await ShowPositionRecords();
                ControlClass.CurrentItem2 = ControlClass.Items2.FirstOrDefault();
            }));
        }

        public void AddDataBindings()
        {
            Binding headerDataBinding = new Binding(nameof(headerDataGridView.DataSource), formBindingSource, nameof(ControlClass.Items),
                false, DataSourceUpdateMode.OnPropertyChanged);

            headerDataGridView.DataBindings.Add(headerDataBinding);

           _currentItemBinding = new Binding(nameof(headerDataGridView.CurrentCell), formBindingSource, nameof(ControlClass.CurrentItem),
                true, DataSourceUpdateMode.OnPropertyChanged);
            _currentItemBinding.Format += new ConvertEventHandler(HeaderDataBinding_Format);
            _currentItemBinding.Parse += new ConvertEventHandler(HeaderDataBinding_Parse);

            headerDataGridView.DataBindings.Add(_currentItemBinding);


            Binding positionDataBinding = new Binding(nameof(positionDataGridView.DataSource), formBindingSource, nameof(ControlClass.Items2),
                            false, DataSourceUpdateMode.OnPropertyChanged);
            positionDataGridView.DataBindings.Add(positionDataBinding);

            _currentItem2Binding = new Binding(nameof(positionDataGridView.CurrentCell), formBindingSource, nameof(ControlClass.CurrentItem2),
                true, DataSourceUpdateMode.OnPropertyChanged);
            _currentItem2Binding.Format += new ConvertEventHandler(PositionDataBinding_Format);
            _currentItem2Binding.Parse += new ConvertEventHandler(PositionDataBinding_Parse);

            positionDataGridView.DataBindings.Add(_currentItem2Binding);

            startDateCheckbox.DataBindings.Add(nameof(startDateCheckbox.Checked),
                filterBindingSource, nameof(ControlClass.Filter.IsDateStartEnabled));
            startDatePicker.DataBindings.Add(nameof(startDatePicker.Value),
                filterBindingSource, nameof(ControlClass.Filter.DateStart), false, 
                DataSourceUpdateMode.OnPropertyChanged);
            startDatePicker.DataBindings.Add(nameof(startDatePicker.Enabled),
                startDateCheckbox, nameof(startDateCheckbox.Checked));

            stopDatePicker.DataBindings.Add(nameof(stopDatePicker.Value),
                filterBindingSource, nameof(ControlClass.Filter.DateStop), false, 
                DataSourceUpdateMode.OnPropertyChanged);
            stopDatePicker.DataBindings.Add(nameof(stopDatePicker.Enabled),
                stopDateCheckbox, nameof(stopDateCheckbox.Checked), false,
                DataSourceUpdateMode.OnPropertyChanged);
            stopDateCheckbox.DataBindings.Add(nameof(stopDateCheckbox.Checked),
                filterBindingSource, nameof(ControlClass.Filter.IsDateStopEnabled));

            customerNumberTextBox.DataBindings.Add(nameof(customerNumberTextBox.Text),
                filterBindingSource, nameof(ControlClass.Filter.CustomerNumber));
            documentNameTextBox.DataBindings.Add(nameof(documentNameTextBox.Text),
                filterBindingSource, nameof(ControlClass.Filter.DocumentName));
            productNameTextBox.DataBindings.Add(nameof(productNameTextBox.Text),
                filterBindingSource, nameof(ControlClass.Filter.ProductName));
        }

        public void AddHeaderColumns()
        {
            headerDataGridView.Columns.Clear();
            headerDataGridView.Columns.Add(GetColumn("Data dokumentu", nameof(ControlClass.CurrentItem.IssueDate),
                150, true, DataGridViewContentAlignment.MiddleCenter, "dd.MM.yyyy"));
            headerDataGridView.Columns.Add(GetColumn("Numer klienta", nameof(ControlClass.CurrentItem.CustomerNumber),
                200, true, DataGridViewContentAlignment.MiddleLeft));
            headerDataGridView.Columns.Add(GetColumn("Nazwa dokumentu", nameof(ControlClass.CurrentItem.DocumentName),
                200, true, DataGridViewContentAlignment.MiddleLeft));
            headerDataGridView.Columns.Add(GetColumn("Wartość netto (PLN)", nameof(ControlClass.CurrentItem.NetValue),
                180, true, DataGridViewContentAlignment.MiddleRight, "n2"));
            headerDataGridView.Columns.Add(GetColumn("Wartość brutto (PLN)", nameof(ControlClass.CurrentItem.GrossValue),
                180, true, DataGridViewContentAlignment.MiddleRight, "n2"));                
        }

        public void AddPositionColumns()
        {
            positionDataGridView.Columns.Clear();
            positionDataGridView.Columns.Add(GetColumn("Nazwa produktu", nameof(ControlClass.CurrentItem2.ProductName),
                200, true, DataGridViewContentAlignment.MiddleLeft));
            positionDataGridView.Columns.Add(GetColumn("Ilość", nameof(ControlClass.CurrentItem2.Quantity),
                200, true, DataGridViewContentAlignment.MiddleRight, "n0"));
            positionDataGridView.Columns.Add(GetColumn("Cena netto (PLN)", nameof(ControlClass.CurrentItem2.NetPrice),
                170, true, DataGridViewContentAlignment.MiddleRight, "n2"));
            positionDataGridView.Columns.Add(GetColumn("Cena brutto (PLN)", nameof(ControlClass.CurrentItem2.GrossPrice),
                170, true, DataGridViewContentAlignment.MiddleRight, "n2"));
            positionDataGridView.Columns.Add(GetColumn("Wartość netto (PLN)", nameof(ControlClass.CurrentItem2.NetValue),
                170, true, DataGridViewContentAlignment.MiddleRight, "n2"));
            positionDataGridView.Columns.Add(GetColumn("Wartość brutto (PLN)", nameof(ControlClass.CurrentItem2.GrossValue),
                170, true, DataGridViewContentAlignment.MiddleRight, "n2"));
        }

        public DataGridViewColumn GetColumn(string columnName, string dataMember, 
            int columnWidth, bool isReadOnly, DataGridViewContentAlignment alignment, string format = null)
        {
            
            DataGridViewColumn column = new DataGridViewTextBoxColumn
            {
                HeaderText = columnName,
                DataPropertyName = dataMember,
                Width = columnWidth,
                ReadOnly = isReadOnly,
                MinimumWidth = columnWidth
            };
            column.DefaultCellStyle = new DataGridViewCellStyle { Alignment = alignment };
            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (format != null)
            {
                column.DefaultCellStyle.Format = format;
            }
            return column;
        }


        private async void searchButton_Click(object sender, EventArgs e)
        {
            if (ControlClass.LoadingData || ControlClass.LoadingData2)
                return;
            await ShowHeaderRecords();
            ControlClass.CurrentItem = ControlClass.Items.FirstOrDefault();
        }        

        public async Task ShowHeaderRecords()
        {
            headerDataGridView.DataBindings.Remove(_currentItemBinding);
            await ControlClass.LoadSortedDataAsync(headerDataGridView.SortedColumn?.DataPropertyName,
               headerDataGridView.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending,
               headerDataGridView.SortOrder != SortOrder.None);
            headerDataGridView.DataBindings.Add(_currentItemBinding);
        }


        public async Task ShowPositionRecords()
        {
            positionDataGridView.DataBindings.Remove(_currentItem2Binding);
            await ControlClass.LoadSortedData2(positionDataGridView.SortedColumn?.DataPropertyName,
               positionDataGridView.SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending,
               positionDataGridView.SortOrder != SortOrder.None);
            positionDataGridView.DataBindings.Add(_currentItem2Binding);
        }

        private void SortDataGridView(DataGridView dataGridView, string propertyName, bool ascending)
        {
            DataGridViewColumn sortedColumn = null;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (column.DataPropertyName == propertyName)
                { 
                    sortedColumn = column;
                }    
            }
            if(sortedColumn != null)
            {
                dataGridView.Sort(sortedColumn, ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
            }
        }

        private async void WarehouseDocumentForm_LoadCompleted()
        {
            AddDataBindings();
            AddHeaderColumns();
            AddPositionColumns();
            SortDataGridView(headerDataGridView, nameof(ControlClass.CurrentItem.IssueDate), true);
            SortDataGridView(positionDataGridView, nameof(ControlClass.CurrentItem2.ProductName), true);
            await ShowHeaderRecords();
            ControlClass.CurrentItem = ControlClass.Items.FirstOrDefault();
        }

        private async void addHeaderButton_Click(object sender, EventArgs e)
        {
            if (ControlClass.LoadingData)
                return;
            var headerEditorForm = _serviceProvider.GetRequiredService<HeaderEditorForm>();
            var headerEditorControlClass = headerEditorForm?.ControlClass;
            if (headerEditorForm.ShowDialog() == DialogResult.OK)
            {
                await ShowHeaderRecords();
                var headerId = headerEditorControlClass?.HeaderItem?.Id;
                var itemToSelect = ControlClass.Items.Where(p => p.Id == headerId).FirstOrDefault();
                ControlClass.CurrentItem = itemToSelect ?? ControlClass.Items.FirstOrDefault();
            }
        }

        private async void editHeaderButton_Click(object sender, EventArgs e)
        {
            if (ControlClass.LoadingData)
                return;
            var current = ControlClass.CurrentItem;
            if (current == null) return;

            var headerEditorForm = _serviceProvider.GetRequiredService<HeaderEditorForm>();
            var headerEditorControlClass = headerEditorForm?.ControlClass;
            if (headerEditorControlClass != null) headerEditorControlClass.HeaderId = current.Id;
            if (headerEditorForm.ShowDialog() == DialogResult.OK)
            {
                await ShowHeaderRecords();
                var itemToSelect = ControlClass.Items.Where(p => p.Id == headerEditorControlClass.HeaderId).FirstOrDefault();
                ControlClass.CurrentItem = itemToSelect ?? ControlClass.Items.FirstOrDefault();
            }
        }

        private async void deleteHeaderButton_Click(object sender, EventArgs e)
        {
            if (ControlClass.LoadingData)
                return;
            if (await ControlClass.DeleteWarehouseDocumentHeaders())
            {
                await ShowHeaderRecords();
                ControlClass.CurrentItem = ControlClass.Items.FirstOrDefault();
            }
        }

        private async void addPositionButton_Click(object sender, EventArgs e)
        {
            if (ControlClass.LoadingData2)
                return;
            var current = ControlClass.CurrentItem;
            if (current == null) return;
            var positionEditorForm = _serviceProvider.GetRequiredService<PositionEditorForm>();
            var positionEditorControlClass = positionEditorForm?.ControlClass;
            if (positionEditorControlClass != null) positionEditorControlClass.HeaderId = current.Id;
            if (positionEditorForm.ShowDialog() == DialogResult.OK)
            {
                await ShowHeaderRecords();
                var itemToSelect = ControlClass.Items.Where(p => p.Id == current.Id).FirstOrDefault();
                headerDataGridView.DataBindings.Remove(_currentItemBinding);
                ControlClass.CurrentItem = itemToSelect ?? ControlClass.Items.FirstOrDefault();
                headerDataGridView.DataBindings.Add(_currentItemBinding);
                await ShowPositionRecords();
                var positionId = positionEditorControlClass?.PositionItem?.Id;
                var itemToSelect2 = ControlClass.Items2.Where(p => p.Id == positionId).FirstOrDefault();
                ControlClass.CurrentItem2 = itemToSelect2 ?? ControlClass.Items2.FirstOrDefault();
            }
        }

        private async void editPositionButton_Click(object sender, EventArgs e)
        {
            if (ControlClass.LoadingData2)
                return;
            var current = ControlClass.CurrentItem;
            if (current == null) return;

            var current2 = ControlClass.CurrentItem2;
            if (current2 == null) return;

            var positionEditorForm = _serviceProvider.GetRequiredService<PositionEditorForm>();
            var positionEditorControlClass = positionEditorForm?.ControlClass;
            if (positionEditorControlClass != null)
            {
                positionEditorControlClass.HeaderId = current.Id;
                positionEditorControlClass.PositionId = current2.Id;
            }
            if (positionEditorForm.ShowDialog() == DialogResult.OK)
            {
                await ShowHeaderRecords();
                var itemToSelect = ControlClass.Items.Where(p => p.Id == current.Id).FirstOrDefault();
                headerDataGridView.DataBindings.Remove(_currentItemBinding);
                ControlClass.CurrentItem = itemToSelect ?? ControlClass.Items.FirstOrDefault();
                headerDataGridView.DataBindings.Add(_currentItemBinding);
                await ShowPositionRecords();
                var itemToSelect2 = ControlClass.Items2
                    .Where(p => p.Id == positionEditorControlClass.PositionId).FirstOrDefault();
                ControlClass.CurrentItem2 = itemToSelect2 ?? ControlClass.Items2.FirstOrDefault();
            }
        }

        private async void deletePositionButton_Click(object sender, EventArgs e)
        {
            if (ControlClass.LoadingData2)
                return;
            var current = ControlClass.CurrentItem;
            if (current == null) return;
            if (await ControlClass.DeleteWarehouseDocumentPositions())
            {
                await ShowHeaderRecords();
                var itemToSelect = ControlClass.Items.Where(p => p.Id == current.Id).FirstOrDefault();
                headerDataGridView.DataBindings.Remove(_currentItemBinding);
                ControlClass.CurrentItem = itemToSelect ?? ControlClass.Items.FirstOrDefault();
                headerDataGridView.DataBindings.Add(_currentItemBinding);
                await ShowPositionRecords();
                ControlClass.CurrentItem2 = ControlClass.Items2.FirstOrDefault();
            }
        }

        private void headerDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = headerDataGridView.SelectedRows;
            var selectedIds = new List<int>();
            foreach (DataGridViewRow row in selectedRows)
            {
                var data = row.DataBoundItem as WarehouseDocumentHeader;
                if (data != null)
                {
                    selectedIds.Add(data.Id);
                }
            }
            ControlClass.SelectedIds = selectedIds;
        }

        private void positionDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = positionDataGridView.SelectedRows;
            var selectedIds2 = new List<int>();
            foreach (DataGridViewRow row in selectedRows)
            {
                var data = row.DataBoundItem as WarehouseDocumentPosition;
                if (data != null)
                {
                    selectedIds2.Add(data.Id);
                }
            }
            ControlClass.SelectedIds2 = selectedIds2;
        }

        private void CurrentItemParse<T>(object sender, ConvertEventArgs e)
                   where T : class
        {
            Binding b = sender as Binding;
            if (b == null)
            {
                e.Value = default(T);
                return;
            }
            var dataGridView = b.Control as DataGridView;
            if (dataGridView == null || dataGridView.Rows.Count == 0)
            {
                e.Value = default(T);
                return;
            }
            var currentCell = e.Value as DataGridViewCell;
            int currentRowIndex = currentCell == null ? -1 : currentCell.RowIndex;
            if (currentRowIndex != -1)
                e.Value = dataGridView.Rows[currentRowIndex].DataBoundItem as T;
            else
                e.Value = default(T);
        }

        private void CurrentItemFormat<T>(object sender, ConvertEventArgs e)
            where T : IContainsId
        {
            Binding b = sender as Binding;
            if (b == null)
            {
                e.Value = default(DataGridViewCell);
                return;
            }
            var dataGridView = b.Control as DataGridView;
            if (dataGridView == null || dataGridView.Rows.Count == 0)
            {
                e.Value = default(DataGridViewCell);
                return;
            }
            DataGridViewCell cell = dataGridView.CurrentCell;
            if (e.Value == null)
            {
                e.Value = cell;
                return;
            }
            var value = (T)e.Value;
            int rowIndex = -1;
            for (int i = 0; (i < dataGridView.Rows.Count) && (rowIndex == -1); i++)
            {
                var row = dataGridView.Rows[i];
                var rowData = (T)row.DataBoundItem;
                if (rowData != null && rowData.Id == value.Id)
                {
                    if (row.Cells.Count > 0)
                    {
                        rowIndex = row.Index;
                    }
                }
            }
            if (rowIndex == -1)
            {
                e.Value = cell;
                return;
            }
            int columnIndex = dataGridView.CurrentCell?.ColumnIndex ?? 0;           
            e.Value = dataGridView[columnIndex, rowIndex];
        }

        private void HeaderDataBinding_Parse(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType == typeof(WarehouseDocumentHeader)
                 && e.Value != null && e.Value is DataGridViewCell)
            {
                CurrentItemParse<WarehouseDocumentHeader>(sender, e);
            }
            else
            {
                e.Value = default(WarehouseDocumentHeader);
            }
        }

        private void HeaderDataBinding_Format(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType == typeof(DataGridViewCell) &&
                e.Value != null && e.Value is WarehouseDocumentHeader)
            {
                CurrentItemFormat<WarehouseDocumentHeader>(sender, e);
            }
            else
            {
                e.Value = default(DataGridViewCell);
            }
        }

        private void PositionDataBinding_Parse(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType == typeof(WarehouseDocumentPosition)
                && e.Value != null && e.Value is DataGridViewCell)
            {
                CurrentItemParse<WarehouseDocumentPosition>(sender, e);
            }
            else
            {
                e.Value = default(WarehouseDocumentPosition);
            }
        }

        private void PositionDataBinding_Format(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType == typeof(DataGridViewCell)
                && e.Value != null && e.Value is WarehouseDocumentPosition)
            {
                CurrentItemFormat<WarehouseDocumentPosition>(sender, e);
            }
            else
            {
                e.Value = default(DataGridViewCell);
            }
        }
    }
}
