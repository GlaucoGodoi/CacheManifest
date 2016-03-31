using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    using System.Web.Optimization;
    using Manifest;

    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Manifest()
        {
            var bundledResources = new List<string>();

            foreach (var bundle in BundleTable.Bundles)
            {
                bundledResources.Add(Scripts.Url(bundle.Path).ToString());
            }
            var manifestResult = new ManifestResultFile("2.3")
            {
                CacheResources = bundledResources,
                NetworkResources = new string[] { "*" },
                FallbackResources = { { "/scripts/bootstrap.min.js", "/scripts/bootstrap.js" } }
            };
            return manifestResult;
        }
    }
}