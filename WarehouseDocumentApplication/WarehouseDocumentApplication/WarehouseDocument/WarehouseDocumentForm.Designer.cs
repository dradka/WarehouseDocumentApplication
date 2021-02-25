
namespace WarehouseDocumentApplication.WarehouseDocument
{
    partial class WarehouseDocumentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.stopDatePicker = new System.Windows.Forms.DateTimePicker();
            this.stopDateCheckbox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateCheckbox = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.documentNameTextBox = new System.Windows.Forms.TextBox();
            this.customerNumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.productNameTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.searchButton = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.positionDataGridView = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.addPositionButton = new System.Windows.Forms.Button();
            this.editPositionButton = new System.Windows.Forms.Button();
            this.deletePositionButton = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.headerDataGridView = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.addHeaderButton = new System.Windows.Forms.Button();
            this.editHeaderButton = new System.Windows.Forms.Button();
            this.deleteHeaderButton = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.headerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.positionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.filterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.formBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionDataGridView)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerDataGridView)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.headerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 679);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(306, 679);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wyszukiwanie";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.54015F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.45985F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.documentNameTextBox, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.customerNumberTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.productNameTextBox, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(300, 579);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.62687F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.37313F));
            this.tableLayoutPanel4.Controls.Add(this.stopDatePicker, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.stopDateCheckbox, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(145, 31);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(155, 31);
            this.tableLayoutPanel4.TabIndex = 15;
            // 
            // stopDatePicker
            // 
            this.stopDatePicker.CustomFormat = "dd.MM.yyyy";
            this.stopDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.stopDatePicker.Location = new System.Drawing.Point(38, 0);
            this.stopDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.stopDatePicker.Name = "stopDatePicker";
            this.stopDatePicker.Size = new System.Drawing.Size(107, 27);
            this.stopDatePicker.TabIndex = 10;
            // 
            // stopDateCheckbox
            // 
            this.stopDateCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stopDateCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopDateCheckbox.Location = new System.Drawing.Point(0, 0);
            this.stopDateCheckbox.Margin = new System.Windows.Forms.Padding(0);
            this.stopDateCheckbox.Name = "stopDateCheckbox";
            this.stopDateCheckbox.Size = new System.Drawing.Size(38, 31);
            this.stopDateCheckbox.TabIndex = 9;
            this.stopDateCheckbox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.62687F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.37313F));
            this.tableLayoutPanel3.Controls.Add(this.startDatePicker, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.startDateCheckbox, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(145, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(155, 31);
            this.tableLayoutPanel3.TabIndex = 14;
            // 
            // startDatePicker
            // 
            this.startDatePicker.CustomFormat = "dd.MM.yyyy";
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDatePicker.Location = new System.Drawing.Point(38, 0);
            this.startDatePicker.Margin = new System.Windows.Forms.Padding(0);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(107, 27);
            this.startDatePicker.TabIndex = 10;
            // 
            // startDateCheckbox
            // 
            this.startDateCheckbox.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.startDateCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startDateCheckbox.Location = new System.Drawing.Point(0, 0);
            this.startDateCheckbox.Margin = new System.Windows.Forms.Padding(0);
            this.startDateCheckbox.Name = "startDateCheckbox";
            this.startDateCheckbox.Size = new System.Drawing.Size(38, 31);
            this.startDateCheckbox.TabIndex = 9;
            this.startDateCheckbox.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 31);
            this.label5.TabIndex = 9;
            this.label5.Text = "Data od:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // documentNameTextBox
            // 
            this.documentNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentNameTextBox.Location = new System.Drawing.Point(148, 97);
            this.documentNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.documentNameTextBox.MaxLength = 250;
            this.documentNameTextBox.Name = "documentNameTextBox";
            this.documentNameTextBox.Size = new System.Drawing.Size(149, 27);
            this.documentNameTextBox.TabIndex = 10;
            // 
            // customerNumberTextBox
            // 
            this.customerNumberTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customerNumberTextBox.Location = new System.Drawing.Point(148, 66);
            this.customerNumberTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customerNumberTextBox.MaxLength = 250;
            this.customerNumberTextBox.Name = "customerNumberTextBox";
            this.customerNumberTextBox.Size = new System.Drawing.Size(149, 27);
            this.customerNumberTextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numer klienta:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data do:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nazwa dokumentu:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 31);
            this.label4.TabIndex = 4;
            this.label4.Text = "Nazwa artykułu:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // productNameTextBox
            // 
            this.productNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productNameTextBox.Location = new System.Drawing.Point(148, 159);
            this.productNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.productNameTextBox.MaxLength = 250;
            this.productNameTextBox.Name = "productNameTextBox";
            this.productNameTextBox.Size = new System.Drawing.Size(149, 27);
            this.productNameTextBox.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.searchButton, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 603);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(300, 72);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // searchButton
            // 
            this.searchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchButton.Location = new System.Drawing.Point(63, 4);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(174, 64);
            this.searchButton.TabIndex = 12;
            this.searchButton.Text = "Wyszukaj";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupBox3);
            this.panel6.Controls.Add(this.splitter2);
            this.panel6.Controls.Add(this.groupBox2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(314, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(667, 679);
            this.panel6.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.positionDataGridView);
            this.groupBox3.Controls.Add(this.flowLayoutPanel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 357);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(667, 322);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Pozycje dokumentów magazynowych";
            // 
            // positionDataGridView
            // 
            this.positionDataGridView.AllowUserToAddRows = false;
            this.positionDataGridView.AllowUserToDeleteRows = false;
            this.positionDataGridView.ColumnHeadersHeight = 40;
            this.positionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.positionDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.positionDataGridView.Location = new System.Drawing.Point(3, 24);
            this.positionDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.positionDataGridView.Name = "positionDataGridView";
            this.positionDataGridView.ReadOnly = true;
            this.positionDataGridView.RowHeadersWidth = 51;
            this.positionDataGridView.RowTemplate.Height = 24;
            this.positionDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.positionDataGridView.ShowCellToolTips = false;
            this.positionDataGridView.Size = new System.Drawing.Size(661, 232);
            this.positionDataGridView.TabIndex = 17;
            this.positionDataGridView.SelectionChanged += new System.EventHandler(this.positionDataGridView_SelectionChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.addPositionButton);
            this.flowLayoutPanel1.Controls.Add(this.editPositionButton);
            this.flowLayoutPanel1.Controls.Add(this.deletePositionButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 256);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(661, 62);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // addPositionButton
            // 
            this.addPositionButton.Location = new System.Drawing.Point(3, 4);
            this.addPositionButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addPositionButton.Name = "addPositionButton";
            this.addPositionButton.Size = new System.Drawing.Size(119, 50);
            this.addPositionButton.TabIndex = 18;
            this.addPositionButton.Text = "Dodaj";
            this.addPositionButton.UseVisualStyleBackColor = true;
            this.addPositionButton.Click += new System.EventHandler(this.addPositionButton_Click);
            // 
            // editPositionButton
            // 
            this.editPositionButton.Location = new System.Drawing.Point(128, 4);
            this.editPositionButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editPositionButton.Name = "editPositionButton";
            this.editPositionButton.Size = new System.Drawing.Size(119, 50);
            this.editPositionButton.TabIndex = 19;
            this.editPositionButton.Text = "Edytuj";
            this.editPositionButton.UseVisualStyleBackColor = true;
            this.editPositionButton.Click += new System.EventHandler(this.editPositionButton_Click);
            // 
            // deletePositionButton
            // 
            this.deletePositionButton.Location = new System.Drawing.Point(253, 4);
            this.deletePositionButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deletePositionButton.Name = "deletePositionButton";
            this.deletePositionButton.Size = new System.Drawing.Size(119, 50);
            this.deletePositionButton.TabIndex = 20;
            this.deletePositionButton.Text = "Usuń";
            this.deletePositionButton.UseVisualStyleBackColor = true;
            this.deletePositionButton.Click += new System.EventHandler(this.deletePositionButton_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 349);
            this.splitter2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(667, 8);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.headerDataGridView);
            this.groupBox2.Controls.Add(this.flowLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(667, 349);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dokumenty magazynowe";
            // 
            // headerDataGridView
            // 
            this.headerDataGridView.AllowUserToAddRows = false;
            this.headerDataGridView.AllowUserToDeleteRows = false;
            this.headerDataGridView.ColumnHeadersHeight = 40;
            this.headerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.headerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerDataGridView.Location = new System.Drawing.Point(3, 24);
            this.headerDataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.headerDataGridView.Name = "headerDataGridView";
            this.headerDataGridView.ReadOnly = true;
            this.headerDataGridView.RowHeadersWidth = 51;
            this.headerDataGridView.RowTemplate.Height = 24;
            this.headerDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.headerDataGridView.ShowCellToolTips = false;
            this.headerDataGridView.Size = new System.Drawing.Size(661, 259);
            this.headerDataGridView.TabIndex = 13;
            this.headerDataGridView.SelectionChanged += new System.EventHandler(this.headerDataGridView_SelectionChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.addHeaderButton);
            this.flowLayoutPanel2.Controls.Add(this.editHeaderButton);
            this.flowLayoutPanel2.Controls.Add(this.deleteHeaderButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 283);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(661, 62);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // addHeaderButton
            // 
            this.addHeaderButton.Location = new System.Drawing.Point(3, 4);
            this.addHeaderButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addHeaderButton.Name = "addHeaderButton";
            this.addHeaderButton.Size = new System.Drawing.Size(119, 50);
            this.addHeaderButton.TabIndex = 14;
            this.addHeaderButton.Text = "Dodaj";
            this.addHeaderButton.UseVisualStyleBackColor = true;
            this.addHeaderButton.Click += new System.EventHandler(this.addHeaderButton_Click);
            // 
            // editHeaderButton
            // 
            this.editHeaderButton.Location = new System.Drawing.Point(128, 4);
            this.editHeaderButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editHeaderButton.Name = "editHeaderButton";
            this.editHeaderButton.Size = new System.Drawing.Size(119, 50);
            this.editHeaderButton.TabIndex = 15;
            this.editHeaderButton.Text = "Edytuj";
            this.editHeaderButton.UseVisualStyleBackColor = true;
            this.editHeaderButton.Click += new System.EventHandler(this.editHeaderButton_Click);
            // 
            // deleteHeaderButton
            // 
            this.deleteHeaderButton.Location = new System.Drawing.Point(253, 4);
            this.deleteHeaderButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.deleteHeaderButton.Name = "deleteHeaderButton";
            this.deleteHeaderButton.Size = new System.Drawing.Size(119, 50);
            this.deleteHeaderButton.TabIndex = 16;
            this.deleteHeaderButton.Text = "Usuń";
            this.deleteHeaderButton.UseVisualStyleBackColor = true;
            this.deleteHeaderButton.Click += new System.EventHandler(this.deleteHeaderButton_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(306, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(8, 679);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // WarehouseDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 679);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "WarehouseDocumentForm";
            this.Text = "Dokumenty magazynowe";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.LoadCompleted += new WarehouseDocumentApplication.Utils.BaseForm.LoadCompletedEventHandler(this.WarehouseDocumentForm_LoadCompleted);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.positionDataGridView)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerDataGridView)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.headerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button addPositionButton;
        private System.Windows.Forms.Button editPositionButton;
        private System.Windows.Forms.Button deletePositionButton;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.BindingSource headerBindingSource;
        private System.Windows.Forms.BindingSource positionBindingSource;
        private System.Windows.Forms.DataGridView positionDataGridView;
        private System.Windows.Forms.DataGridView headerDataGridView;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button addHeaderButton;
        private System.Windows.Forms.Button editHeaderButton;
        private System.Windows.Forms.Button deleteHeaderButton;
        private System.Windows.Forms.BindingSource filterBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox documentNameTextBox;
        private System.Windows.Forms.TextBox customerNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox productNameTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.DateTimePicker stopDatePicker;
        private System.Windows.Forms.CheckBox stopDateCheckbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.CheckBox startDateCheckbox;
        private System.Windows.Forms.BindingSource formBindingSource;
    }
}

