using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DinkToPdf.Contracts;
using FridgeManager.ReportAzureFunction.Models;
using FridgeManager.ReportAzureFunction.Services.Interfaces;
using GemBox.Document;

namespace FridgeManager.ReportAzureFunction.Services
{
    internal class ReportGenerator : IReportGenerator
    {
        private readonly IConverter _converter;

        public ReportGenerator(IConverter converter)
        {
            _converter = converter;
        }

        public Task GenerateReportAsync(User user, IEnumerable<Fridge> fridges)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            var htmlLoadOptions = new HtmlLoadOptions();

            using (var htmlStream = new MemoryStream(htmlLoadOptions.Encoding.GetBytes(GetReport())))
            {
                var document = DocumentModel.Load(htmlStream, htmlLoadOptions);

                document.Save("D://Output.pdf");
            }

            return Task.CompletedTask;
        }

        private string GetReport()
        {
            var builder = new StringBuilder();

            builder.Append(@"
        <div>
        <h3>Your pdf report</h3>
        </div>
      <table>
        <tr>
          <th>Fridge Name</th>
          <th>Fridge Model</th>
          <th>Products</th>
        </tr>
        <tr>
         <td>
          someName
         </td>
         <td>
          someModel
         </td>
         <td>
          <table>
            <tr>
              <th>Name</th>
              <th>Quantity</th>              
            </tr>
            <tr>
              <td>somename</td>
              <td>1</td>
            </tr>
          </table>
         </td>
        </tr>
        
      </table>
");
            return builder.ToString();
        }
    }
}
