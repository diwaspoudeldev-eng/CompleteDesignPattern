using CustomerFactory;
using MiddleLayer;

namespace WindowsForm
{
    public partial class FormCustomer : Form
    {
        //private Customer cust = null;
        //private Lead lead = null;
        private CustomerBase cust = null;

        public FormCustomer()
        {
            InitializeComponent();
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

            if(cust is Customer customer)
            {
                 customer.BillDate = Convert.ToDateTime(txtBillingDate.Text);
                 customer.BillAmount = Convert.ToDecimal(txtBillingAmount.Text);
                 customer.Address = txtAddress.Text;
            }

            //cust.BillDate = Convert.ToDateTime(txtBillingDate.Text);
            //cust.BillAmount = Convert.ToDecimal(txtBillingAmount.Text);
            //cust.Address = txtAddress.Text;
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
            Factory.Create(cmbCustomerType.Text);
        }
        private void FrmCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
