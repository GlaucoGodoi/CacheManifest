Nowadays web apps are becoming more and more common and one of the nicest features we can have in a web app is to allow it run offline.
The easiest way, and the only one I know :), to achieve offline execution is to use the cache manifest.
In this example I will demonstrate how to generate and serve the cache manifest in a Asp.Net MVC5 application. And just to make things more interesting I will bundle my resources and use a CDN for some of them.

From my point of view them most interesting points are:

1) On HomeController.cs in the action Manifest is where the files that will be present in the manifest are grabbed.

2) ManifestResultFile.cs, an ActionResult that inherits from FileResult and is responsible for assembling the "file" that contains the manifest.

3) Bundling.cs, where the bundles are configured. To make things more interesting I brought some files from a CDN and I also added fallback expressions to detect if the files were correctly downloaded (look at the extra html/javascript generated in the page).

4) RouteConfig.cs, where a route is configured to allow the manifest be served by the MVC infrastructure. Here the most interesting point is how to setup the application to allow the usage of dots in the URL (read the comments).

Hope it helps!

Glauco.
