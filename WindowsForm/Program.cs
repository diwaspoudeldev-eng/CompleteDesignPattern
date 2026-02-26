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
            string connStr = "Data Source=localhost;Initial Catalog=DesignPatternDB;Integrated Security=True;";

            // Instantiate the repository (Composition Root)
            InterfaceDAL.IRepository<InterfaceLayer.ICustomer> repository = 
                new Repository.AdoRepository<InterfaceLayer.ICustomer>(connStr);

            // Inject the repository into the Main Form
            Application.Run(new FormCustomer(repository));
        }
    }
}