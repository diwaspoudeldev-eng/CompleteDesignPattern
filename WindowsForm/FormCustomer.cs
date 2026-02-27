using CustomerFactory;
using InterfaceLayer;
using InterfaceDAL;
using MiddleLayer;

namespace WindowsForm
{
    public partial class FormCustomer : Form
    {
        //private Customer cust = null;
        //private Lead lead = null;
        //private CustomerBase cust = null;
        private ICustomer cust = null;
        private readonly IRepository<ICustomer> _adoRepository;
        private readonly IRepository<ICustomer> _efRepository;
        private CustomerCollection _customers = new CustomerCollection();

        public FormCustomer(IRepository<ICustomer> adoRepository, IRepository<ICustomer> efRepository)
        {
            InitializeComponent();
            _adoRepository = adoRepository;
            _efRepository = efRepository;
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
            IRepository<ICustomer> repo = cmbDALType.Text == "ADO" ? _adoRepository : _efRepository;
            var dbData = repo.GetAll()?.ToList() ?? new List<ICustomer>();
            // Union of DB and In-memory data
            var totalData = dbData.Concat(_customers).ToList();
            dataGridView1.DataSource = totalData;
        }

        private void LoadGridFromDB()
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
                SetCustomer();
                cust.Validate(); // RIP Pattern, Polymorphism, Liskov Substitution Principle
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void SetCustomer()
        {
            cust.Id = string.IsNullOrWhiteSpace(txtId.Text) ? 0 : Convert.ToInt32(txtId.Text);
            cust.CustomerName = txtCustomerName.Text;
            cust.PhoneNumber = txtPhoneNumber.Text;
            cust.BillDate = string.IsNullOrWhiteSpace(txtBillingDate.Text) ? null : Convert.ToDateTime(txtBillingDate.Text);
            cust.BillAmount = string.IsNullOrWhiteSpace(txtBillingAmount.Text) ? null : Convert.ToDecimal(txtBillingAmount.Text);
            cust.Address = txtAddress.Text;
        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbCustomerType.Text == "Lead")
            //{
            //    lead = new Lead();
            //    cust = null;
            //}
            //else if (cmbCustomerType.Text == "Customer")
            //{
            //    cust = new Customer();
            //    lead = null;
            //}

            //Factory pattern implementation
            cust = Factory.Create(cmbCustomerType.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Normal Add: Save whatever is in field selected directly to DB
            try
            {
                SetCustomer();
                cust.Validate(); 
                
                IRepository<ICustomer> repo = cmbDALType.Text == "ADO" ? _adoRepository : _efRepository;
                repo.Add(cust);
                
                MessageBox.Show("Customer successfully added to database!");
                LoadGrid(); // Refresh grid (shows both DB + memory)
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnAddInmemory_Click(object sender, EventArgs e)
        {
            // Iterator button: adds into existing grid (in-memory part)
            try
            {
                SetCustomer();
                cust.Validate();

                // Add to in-memory collection
                _customers.Add(cust);

                // Re-create customer object for next entry
                cust = Factory.Create(cmbCustomerType.Text);

                LoadGrid(); // Refresh grid (shows both DB + memory)
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnBatchSave_Click(object sender, EventArgs e)
        {
            // Save all in-memory into DB and reload
            try
            {
                IRepository<ICustomer> repo = cmbDALType.Text == "ADO" ? _adoRepository : _efRepository;

                // Iterator Pattern in action: using foreach on our custom collection
                foreach (var customer in _customers)
                {
                    repo.Add(customer);
                }

                MessageBox.Show("All in-memory customers successfully saved to database!");
                _customers.Clear(); // Clear memory after saving
                LoadGrid(); // Reload from DB (and now empty memory)
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}
