using System;
using System.IO;

namespace FridgeManager.ReportAzureFunction.Models
{
    internal class ReportGenerationResult : IDisposable
    {
        public string MediaType { get; }

        public string SubMediaType { get; }

        public Stream Content { get; }

        public ReportGenerationResult(string mediaType, string subMediaType, Stream content)
        {
            MediaType = mediaType;
            SubMediaType = subMediaType;
            Content = content;
        }

        public void Dispose()
            => Content?.Dispose();
    }
}
