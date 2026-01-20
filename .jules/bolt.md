## 2024-10-24 - Synchronous I/O in Async Actions
**Learning:** Legacy ASP.NET MVC controllers often hide synchronous I/O operations (like `BinaryReader` or `File.ReadAllBytes`) inside `async` actions. This negates the scalability benefits of async/await by blocking thread pool threads.
**Action:** Always scan `async` methods for hidden synchronous blocking calls and replace them with `Async` equivalents (e.g., `Stream.ReadAsync`). Be careful with `BinaryReader` as it disposes the underlying stream by default.
