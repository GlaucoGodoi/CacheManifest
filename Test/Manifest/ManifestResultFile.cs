using System.Collections.Generic;
using System.Web;

namespace Test.Manifest
{
    using System.Web.Mvc;

    public class ManifestResultFile : FileResult
    {
        public string ManifestVersion { get; set; }
        public IEnumerable<string> CacheResources { get; set; }
        public IEnumerable<string> NetworkResources { get; set; }
        public Dictionary<string, string> FallbackResources { get; set; }

        public ManifestResultFile(string manifestVersion) : base("text/cache-manifest")
        {
            ManifestVersion = manifestVersion;
            CacheResources = new List<string>();
            NetworkResources = new List<string>();
            FallbackResources = new Dictionary<string, string>();
        }

        protected override void WriteFile(HttpResponseBase response)
        {
            WriteManifestHeader(response);
            WriteCacheResources(response);
            WriteNetwork(response);
            WriteFallback(response);
        }

        private void WriteManifestHeader(HttpResponseBase response)
        {
            response.Output.WriteLine("CACHE MANIFEST");
            response.Output.WriteLine("#V" + ManifestVersion);
        }

        private void WriteCacheResources(HttpResponseBase response)
        {
            response.Output.WriteLine("CACHE:");
            foreach (var cacheResource in CacheResources)
                response.Output.WriteLine(cacheResource);
        }

        private void WriteNetwork(HttpResponseBase response)
        {
            response.Output.WriteLine();
            response.Output.WriteLine("NETWORK:");
            foreach (var networkResource in NetworkResources)
                response.Output.WriteLine(networkResource);
        }

        private void WriteFallback(HttpResponseBase response)
        {
            response.Output.WriteLine();
            response.Output.WriteLine("FALLBACK:");
            foreach (var fallbackResource in FallbackResources)
                response.Output.WriteLine(fallbackResource.Key + " " + fallbackResource.Value);
        }
    }
}