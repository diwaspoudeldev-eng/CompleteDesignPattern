using CustomerFactory;
using InterfaceLayer;
using InterfaceDAL;

namespace WindowsForm
{
    public partial class FormCustomer : Form
    {
        //private Customer cust = null;
        //private Lead lead = null;
        //private CustomerBase cust = null;
        private ICustomer cust = null;
        private readonly IRepository<ICustomer> _repository;

        public FormCustomer(IRepository<ICustomer> repository)
        {
            InitializeComponent();
            _repository = repository;
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
            try
            {
                SetCustomer();
                cust.Validate(); // Make sure it's valid first
                
                // Using the injected Generic Repository
                _repository.Add(cust);
                
                MessageBox.Show("Customer successfully added to database!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
