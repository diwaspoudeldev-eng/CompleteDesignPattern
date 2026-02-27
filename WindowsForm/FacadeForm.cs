using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using InterfaceLayer;
using InterfaceDAL;
using MiddleLayer;

namespace WindowsForm
{
    public partial class FacadeForm : Form
    {
        private readonly CustomerFacade _facade;
        private ICustomer _latestEntry = null;

        public FacadeForm(IRepository<ICustomer> adoRepository, IRepository<ICustomer> efRepository)
        {
            InitializeComponent();
            // Facade Pattern: The UI only interacts with this one class
            _facade = new CustomerFacade(adoRepository, efRepository);
            ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Customer ID", Name = "Id" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CustomerName", HeaderText = "Customer Name", Name = "CustomerName" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PhoneNumber", HeaderText = "Phone Number", Name = "PhoneNumber" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BillAmount", HeaderText = "Bill Amount", Name = "BillAmount" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BillDate", HeaderText = "Bill Date", Name = "BillDate" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Address", HeaderText = "Address", Name = "Address" });
        }

        private void LoadGrid()
        {
            // Facade Pattern: Simple call to get unified data
            dataGridView1.DataSource = _facade.GetCombinedData(cmbDALType.Text);
        }

        private void FacadeForm_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void cmbDALType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                // We use the facade's builder utility to test validation
                var temp = _facade.BuildCustomer(
                    cmbCustomerType.Text,
                    GetId(),
                    txtCustomerName.Text,
                    txtPhoneNumber.Text,
                    GetBillAmount(),
                    GetBillDate(),
                    txtAddress.Text
                );
                temp.Validate();
                MessageBox.Show("Validation Successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Facade Pattern: Single call handles Builder + Validation + Repository
                _facade.AddDirect(
                    cmbCustomerType.Text,
                    GetId(),
                    txtCustomerName.Text,
                    txtPhoneNumber.Text,
                    GetBillAmount(),
                    GetBillDate(),
                    txtAddress.Text,
                    cmbDALType.Text
                );
                MessageBox.Show("Customer added directly to DB via Facade!");
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddInmemory_Click(object sender, EventArgs e)
        {
            try
            {
                // Facade Pattern: Single call handles Builder + Validation + Memory Collection
                _facade.AddToMemory(
                    cmbCustomerType.Text,
                    GetId(),
                    txtCustomerName.Text,
                    txtPhoneNumber.Text,
                    GetBillAmount(),
                    GetBillDate(),
                    txtAddress.Text
                );
                MessageBox.Show("Customer added to Memory via Facade!");
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Facade Pattern: Single call handles Iterator + Repository Save + Memory Clear
                _facade.BatchSave(cmbDALType.Text);
                MessageBox.Show("All in-memory items saved to DB via Facade!");
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCloneAndSave_Click(object sender, EventArgs e)
        {
            try
            {
                // First build from current UI to have a source
                var source = _facade.BuildCustomer(cmbCustomerType.Text, GetId(), txtCustomerName.Text, txtPhoneNumber.Text, GetBillAmount(), GetBillDate(), txtAddress.Text);
                
                // Facade Pattern: Handles cloning logic
                var clone = _facade.CloneCustomer(source);
                _facade.AddToMemory(clone);
                
                MessageBox.Show("Cloned and added to list via Facade!");
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // Facade Pattern: Simplifies report generation
            var data = (List<ICustomer>)dataGridView1.DataSource;
            string report = _facade.GenerateCsvReport(data);
            MessageBox.Show(report, "CSV Report via Facade");
        }

        // UI Helpers
        private int GetId() => string.IsNullOrWhiteSpace(txtId.Text) ? 0 : Convert.ToInt32(txtId.Text);
        private decimal? GetBillAmount() => string.IsNullOrWhiteSpace(txtBillingAmount.Text) ? null : Convert.ToDecimal(txtBillingAmount.Text);
        private DateTime? GetBillDate() => string.IsNullOrWhiteSpace(txtBillingDate.Text) ? null : Convert.ToDateTime(txtBillingDate.Text);
    }
}
