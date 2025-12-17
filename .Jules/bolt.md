# Bolt's Journal

## 2024-05-22 - Optimization in Legacy .NET Environment
**Learning:** In a legacy ASP.NET MVC environment where build tools (MSBuild) are missing, we cannot run C# code or tests. However, we can still perform safe configuration optimizations.
**Action:** Focused on `BundleConfig.cs` to enable CDN support for jQuery and Bootstrap. This is a configuration change that leverages the ASP.NET Optimization framework at runtime (if deployed to a proper environment) without needing recompilation of the logic itself, although technically `BundleConfig.cs` is C# code. I relied on standard library versions and documentation to ensure correctness.
