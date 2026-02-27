using System.Collections.Generic;
using System.Text;
using InterfaceLayer;

namespace MiddleLayer
{
    public class CsvReportBuilder : IReportBuilder
    {
        private StringBuilder _sb = new StringBuilder();

        public void AddHeader(string[] headers)
        {
            _sb.AppendLine(string.Join(",", headers));
        }

        public void AddRow(string[] columns)
        {
            _sb.AppendLine(string.Join(",", columns));
        }

        public void AddFooter(string footerText)
        {
            _sb.AppendLine(footerText);
        }

        public string GetReport()
        {
            return _sb.ToString();
        }
    }
}
