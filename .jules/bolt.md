# Bolt's Journal

## 2025-05-18 - [Initial Setup]
**Learning:** Performance optimizations in legacy ASP.NET MVC apps often involve identifying synchronous I/O in async actions.
**Action:** When auditing `async` controllers, always check for blocking calls like `BinaryReader.ReadBytes` or `.Result` / `.Wait()`.
