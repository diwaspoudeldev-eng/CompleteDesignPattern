namespace WindowsForm
{
    partial class FormCustomer
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
            btnValidate = new Button();
            btnAdd = new Button();
            btnAddInmemory = new Button();
            btnBatchSave = new Button();
            btnCloneAndSave = new Button();
            btnGenerateReport = new Button();
            txtId = new TextBox();
            label8 = new Label();
            dataGridView1 = new DataGridView();
            txtAddress = new TextBox();
            label6 = new Label();
            txtBillingDate = new TextBox();
            label5 = new Label();
            txtBillingAmount = new TextBox();
            label4 = new Label();
            txtPhoneNumber = new TextBox();
            label3 = new Label();
            txtCustomerName = new TextBox();
            label2 = new Label();
            cmbCustomerType = new ComboBox();
            label1 = new Label();
            cmbDALType = new ComboBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnValidate
            // 
            btnValidate.Location = new Point(23, 144);
            btnValidate.Margin = new Padding(3, 4, 3, 4);
            btnValidate.Name = "btnValidate";
            btnValidate.Size = new Size(131, 44);
            btnValidate.TabIndex = 37;
            btnValidate.Text = "Validate";
            btnValidate.UseVisualStyleBackColor = true;
            btnValidate.Click += btnValidate_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(160, 144);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(131, 44);
            btnAdd.TabIndex = 38;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnAddInmemory
            // 
            btnAddInmemory.Location = new Point(619, 104);
            btnAddInmemory.Margin = new Padding(3, 4, 3, 4);
            btnAddInmemory.Name = "btnAddInmemory";
            btnAddInmemory.Size = new Size(83, 83);
            btnAddInmemory.TabIndex = 41;
            btnAddInmemory.Text = "Add (Iterator)";
            btnAddInmemory.UseVisualStyleBackColor = true;
            btnAddInmemory.Click += btnAddInmemory_Click;
            // 
            // btnBatchSave
            // 
            btnBatchSave.Location = new Point(729, 94);
            btnBatchSave.Margin = new Padding(3, 4, 3, 4);
            btnBatchSave.Name = "btnBatchSave";
            btnBatchSave.Size = new Size(75, 99);
            btnBatchSave.TabIndex = 45;
            btnBatchSave.Text = "Batch Save After Iteration";
            btnBatchSave.UseVisualStyleBackColor = true;
            btnBatchSave.Click += btnBatchSave_Click;
            // 
            // btnCloneAndSave
            // 
            btnCloneAndSave.Location = new Point(639, 201);
            btnCloneAndSave.Margin = new Padding(3, 4, 3, 4);
            btnCloneAndSave.Name = "btnCloneAndSave";
            btnCloneAndSave.Size = new Size(128, 34);
            btnCloneAndSave.TabIndex = 46;
            btnCloneAndSave.Text = "Clone & Add";
            btnCloneAndSave.UseVisualStyleBackColor = true;
            btnCloneAndSave.Click += btnCloneAndSave_Click;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(23, 215);
            btnGenerateReport.Margin = new Padding(3, 4, 3, 4);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(160, 34);
            btnGenerateReport.TabIndex = 47;
            btnGenerateReport.Text = "Generate CSV Report";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(650, 60);
            txtId.Margin = new Padding(3, 4, 3, 4);
            txtId.Name = "txtId";
            txtId.Size = new Size(146, 27);
            txtId.TabIndex = 43;
            txtId.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(570, 60);
            label8.Name = "label8";
            label8.Size = new Size(22, 20);
            label8.TabIndex = 44;
            label8.Text = "Id";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(23, 257);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new Size(781, 256);
            dataGridView1.TabIndex = 32;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(393, 104);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(203, 83);
            txtAddress.TabIndex = 27;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(309, 104);
            label6.Name = "label6";
            label6.Size = new Size(62, 20);
            label6.TabIndex = 31;
            label6.Text = "Address";
            // 
            // txtBillingDate
            // 
            txtBillingDate.Location = new Point(393, 60);
            txtBillingDate.Margin = new Padding(3, 4, 3, 4);
            txtBillingDate.Name = "txtBillingDate";
            txtBillingDate.Size = new Size(146, 27);
            txtBillingDate.TabIndex = 25;
            txtBillingDate.Text = "1/1/2010";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(309, 60);
            label5.Name = "label5";
            label5.Size = new Size(66, 20);
            label5.TabIndex = 30;
            label5.Text = "Bill Date";
            // 
            // txtBillingAmount
            // 
            txtBillingAmount.Location = new Point(393, 18);
            txtBillingAmount.Margin = new Padding(3, 4, 3, 4);
            txtBillingAmount.Name = "txtBillingAmount";
            txtBillingAmount.Size = new Size(146, 27);
            txtBillingAmount.TabIndex = 22;
            txtBillingAmount.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(309, 18);
            label4.Name = "label4";
            label4.Size = new Size(87, 20);
            label4.TabIndex = 28;
            label4.Text = "Bill Amount";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(147, 104);
            txtPhoneNumber.Margin = new Padding(3, 4, 3, 4);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(146, 27);
            txtPhoneNumber.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(19, 104);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 24;
            label3.Text = "Phone number";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(147, 60);
            txtCustomerName.Margin = new Padding(3, 4, 3, 4);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(146, 27);
            txtCustomerName.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 60);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 21;
            label2.Text = "Customer Name";
            // 
            // cmbCustomerType
            // 
            cmbCustomerType.FormattingEnabled = true;
            cmbCustomerType.Items.AddRange(new object[] { "Lead", "Customer", "SelfService", "HomeDelivery" });
            cmbCustomerType.Location = new Point(147, 14);
            cmbCustomerType.Margin = new Padding(3, 4, 3, 4);
            cmbCustomerType.Name = "cmbCustomerType";
            cmbCustomerType.Size = new Size(146, 28);
            cmbCustomerType.TabIndex = 20;
            cmbCustomerType.SelectedIndexChanged += cmbCustomerType_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 14);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 19;
            label1.Text = "Customer Type";
            // 
            // cmbDALType
            // 
            cmbDALType.FormattingEnabled = true;
            cmbDALType.Items.AddRange(new object[] { "ADO", "EF" });
            cmbDALType.Location = new Point(650, 14);
            cmbDALType.Margin = new Padding(3, 4, 3, 4);
            cmbDALType.Name = "cmbDALType";
            cmbDALType.Size = new Size(146, 28);
            cmbDALType.TabIndex = 39;
            cmbDALType.Text = "ADO";
            cmbDALType.SelectedIndexChanged += cmbDALType_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(570, 14);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 40;
            label7.Text = "DAL Type";
            // 
            // FormCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 529);
            Controls.Add(btnValidate);
            Controls.Add(btnAdd);
            Controls.Add(btnAddInmemory);
            Controls.Add(btnBatchSave);
            Controls.Add(btnCloneAndSave);
            Controls.Add(btnGenerateReport);
            Controls.Add(dataGridView1);
            Controls.Add(txtAddress);
            Controls.Add(label6);
            Controls.Add(txtBillingDate);
            Controls.Add(label5);
            Controls.Add(txtBillingAmount);
            Controls.Add(label4);
            Controls.Add(txtPhoneNumber);
            Controls.Add(label3);
            Controls.Add(txtCustomerName);
            Controls.Add(label2);
            Controls.Add(cmbCustomerType);
            Controls.Add(label1);
            Controls.Add(cmbDALType);
            Controls.Add(label7);
            Controls.Add(txtId);
            Controls.Add(label8);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormCustomer";
            Text = "Customer";
            Load += FrmCustomer_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAddInmemory;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.Button btnCloneAndSave;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBillingDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBillingAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDALType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label8;
    }
}
