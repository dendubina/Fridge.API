using System;
using System.IO;

namespace FridgeManager.ReportAzureFunction.Models
{
    internal class Report : IDisposable
    {
        public string MediaType { get; }

        public string SubMediaType { get; }

        public Stream Content { get; }

        public Report(string mediaType, string subMediaType, Stream content)
        {
            MediaType = mediaType;
            SubMediaType = subMediaType;
            Content = content;
        }

        public void Dispose()
            => Content?.Dispose();
    }
}
