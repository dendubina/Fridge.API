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
        public ReportGenerationResult GenerateReport(User user, IEnumerable<Fridge> fridges)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            var htmlLoadOptions = new HtmlLoadOptions();

            using var htmlStream = new MemoryStream(htmlLoadOptions.Encoding.GetBytes(CreateHtmlReport(user, fridges)));

            var document = DocumentModel.Load(htmlStream, htmlLoadOptions);

            var content = new MemoryStream();

            // document.Save(content, new PdfSaveOptions());
            document.Save("D://Output.pdf");

            return new ReportGenerationResult("application", "pdf", content);
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
                            .report-header
                                {
                                  text-align: center;
                                  color: green;
                                  padding-bottom: 10px;
                                }
                        </style>");

            builder.Append($@"
                    <body>
                    <div class='report-header'>Hello, {user.UserName}, here is your weekly report</div>
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
                            <td>{fridge.ModelName} {fridge.ModelYear}</td>");

                builder.Append(@"
                        <td>
                        <table>
                            <tr>
                                <th>Name</th>
                                <th>Quantity</th>
                            </tr>");

                foreach (var product in fridge.Products)
                {
                    builder.Append($@"
                            <tr>
                                <td>{product.ProductName}</td>
                                <td>{product.Quantity}</td>
                            </tr>");
                }

                builder.Append(@"
                    </table>
                     </td>
                     </tr>
                    </table>");
            }

            return builder.ToString();
        }
    }
}
