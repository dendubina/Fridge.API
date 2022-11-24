using System.Collections.Generic;
using System.IO;
using System.Text;
using FridgeManager.ReportAzureFunction.Models;
using FridgeManager.ReportAzureFunction.Services.Interfaces;
using GemBox.Document;

namespace FridgeManager.ReportAzureFunction.Services
{
    internal class ReportGenerator : IReportGenerator
    {
        public Stream GenerateReport(User user, IEnumerable<Fridge> fridges)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            var htmlLoadOptions = new HtmlLoadOptions();

            using var htmlStream = new MemoryStream(htmlLoadOptions.Encoding.GetBytes(CreateHtmlReport(user, fridges)));

            var document = DocumentModel.Load(htmlStream, htmlLoadOptions);

            var result = new MemoryStream();

            // document.Save(result, new PdfSaveOptions());
            document.Save("D://Output.pdf");

            return result;
        }

        private static string CreateHtmlReport(User user, IEnumerable<Fridge> fridges)
        {
            var builder = new StringBuilder();

            builder.Append(@"
                    <html>
                        <style>
                            table
                                {
                                    margin: 0 auto;
                                }
                            .report-table
                                {
                                  text-align: center;
                                  border: 1px solid seagreen;
                                }
                            .products-table
                                {
                                  border: 1px solid sandybrown;
                                }
                            .report-header
                                {
                                  text-align: center;
                                  color: green;
                                  padding-bottom: 10px;
                                }
                        </style>");

            builder.Append($@"
                    <body>
                    <div class='report-header'>Hello, {user.UserName}, this is your weekly report</div>
<table class='report-table'>
<tr>
          <th>Fridge Name</th>
          <th>Fridge Model</th>
          <th>Products</th>
</tr>
");

            foreach (var fridge in fridges)
            {
                builder.Append($@"
<tr>
<td>{fridge.Name}</td>
<td>{fridge.ModelName} {fridge.ModelYear}</td>
</tr>
");
                builder.Append(@"<table></table>");
            }

            
            
            builder.Append(@"      
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
</body>
</html>
");
            return builder.ToString();
        }
    }
}
