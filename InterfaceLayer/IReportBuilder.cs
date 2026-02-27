namespace InterfaceLayer
{
    public interface IReportBuilder
    {
        void AddHeader(string[] headers);
        void AddRow(string[] columns);
        void AddFooter(string footerText);
        string GetReport();
    }
}
