## 2024-05-23 - Async File IO in MVC Controllers
**Learning:** `BinaryReader` is synchronous and can block the request thread, limiting scalability. It also disposes the underlying stream, which can cause issues if the stream is needed later. `Stream.ReadAsync` is preferred but requires careful handling (looping for full read) and manual buffer management.
**Action:** Always prefer `Stream.ReadAsync` for `HttpPostedFileBase.InputStream` reading. Ensure to loop until `ContentLength` is reached or `ReadAsync` returns 0.
