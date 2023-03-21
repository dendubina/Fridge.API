using System.Collections.Generic;
using System.IO;
using System.Text;
using GemBox.Document;
using ReportAzureFunction.Models;
using ReportAzureFunction.Services.Interfaces;

namespace ReportAzureFunction.Services
{
    internal class ReportGenerator : IReportGenerator
    {
        public Report GenerateReport(Owner user, IEnumerable<Fridge> fridges)
        {
            var htmlLoadOptions = new HtmlLoadOptions();

            using var htmlStream = new MemoryStream(htmlLoadOptions.Encoding.GetBytes(CreateHtmlReport(user, fridges)));

            var document = DocumentModel.Load(htmlStream, htmlLoadOptions);

            var content = new MemoryStream();

             document.Save(content, new PdfSaveOptions());
           // document.Save("D://Output.pdf");

            return new Report("application", "pdf", content);
        }

        private static string CreateHtmlReport(Owner user, IEnumerable<Fridge> fridges)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(@"
                    <html>
                        <style>
                            table
                                {
                                    margin: 0 auto;
                                    width: 80%;                                    
                                }
                            td, th
                                {                                    
                                    text-align: center;
                                    vertical-align: middle;
                                }
                            .report-table
                                {                                 
                                  border: 1px solid seagreen;
                                }                            
                            .report-header
                                {
                                  text-align: center;
                                  color: green;
                                  padding-bottom: 10px;
                                }                            
                        </style>");

            stringBuilder.Append($@"
                    <body>
                    <div class='report-header'>Hello, {user.UserName}, here is your weekly report</div>
                        <table class='report-table'>
                        <tr>
                            <th>Fridge Name</th>
                            <th>Fridge Model</th>
                            <th>Products</th>
                        </tr>");

            foreach (var fridge in fridges)
            {
                stringBuilder.Append($@"
                        <tr>
                            <td>{fridge.Name}</td>
                            <td>{fridge.ModelName} {fridge.ModelYear}</td>
                            <td>
                             <table>
                                 <tr>
                                <th>Name</th>
                                <th>Quantity</th>
                                </tr>");

                foreach (var product in fridge.Products)
                {
                    stringBuilder.Append($@"
                            <tr>
                                <td>{product.ProductName}</td>
                                <td>{product.Quantity}</td>
                            </tr>");
                }

                stringBuilder.Append(@"
                    </tr>
                    </table>
                     </td>
                     </tr>
                    </table>
                    </body>");
            }

            return stringBuilder.ToString();
        }
    }
}
