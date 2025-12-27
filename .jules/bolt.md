# Bolt's Journal

## 2024-05-22 - Async I/O in Legacy ASP.NET
**Learning:** Legacy ASP.NET MVC controllers often use synchronous I/O (like `BinaryReader`) even in `async` actions, which blocks the thread pool and reduces scalability under load.
**Action:** Always verify that `HttpPostedFileBase` or other stream operations use `ReadAsync` or `CopyToAsync` in `async` methods.

## 2024-05-22 - Large Object Heap Pressure
**Learning:** Reading entire files into `byte[]` buffers (especially images) can cause LOH fragmentation if > 85KB.
**Action:** In the future, consider streaming directly to the destination (e.g., Azure Blob Storage or `Stream` to `Stream` copy) instead of buffering in memory if possible. For Base64 conversion, this is unavoidable without newer Span/Pipe APIs, but worth noting.
