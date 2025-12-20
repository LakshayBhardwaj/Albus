## 2024-12-18 - CDN Optimization for Legacy ASP.NET
**Learning:** Legacy ASP.NET MVC bundling (`System.Web.Optimization`) supports CDN fallback out of the box but requires explicit configuration of `UseCdn = true` and passing the CDN path to the `ScriptBundle`/`StyleBundle` constructor.
**Action:** Always check `BundleConfig.cs` in legacy apps. Enabling CDN and bundle optimizations (`EnableOptimizations = true`) is a low-risk, high-impact performance win that reduces server load and leverages browser caching.
