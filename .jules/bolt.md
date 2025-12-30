## 2024-05-22 - [Synchronous IO in Controllers]
**Learning:** Using `BinaryReader` or other synchronous IO operations in an async controller action blocks the thread, negating the benefits of `async/await`.
**Action:** Always use `Stream.ReadAsync`, `CopyToAsync`, or similar async methods when handling file uploads or streams in ASP.NET.
