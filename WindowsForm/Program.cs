namespace WindowsForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Typical connection string setup (in a real app, read from config)
            string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DesignPatternDB;Integrated Security=True;";

            // Instantiate both repositories
            InterfaceDAL.IRepository<InterfaceLayer.ICustomer> adoRepository = 
                new Repository.AdoRepository<InterfaceLayer.ICustomer>(connStr);
            
            InterfaceDAL.IRepository<InterfaceLayer.ICustomer> efRepository = 
                new Repository.EfRepository<InterfaceLayer.ICustomer>(connStr);

            // Inject both repositories into the Facade Form
            //Application.Run(new FacadeForm(adoRepository, efRepository));
            Application.Run(new FormCustomer(adoRepository, efRepository));
        }
    }
}