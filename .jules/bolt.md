## 2024-05-23 - Async File Reading
**Learning:** `BinaryReader.ReadBytes` is synchronous and blocks the thread, which defeats the purpose of an `async` controller action. Furthermore, `BinaryReader` by default closes the underlying stream on disposal, which can cause issues if the stream needs to be reused (though `HttpPostedFileBase` streams are resilient).
**Action:** Always use `Stream.ReadAsync` (looping as necessary) when reading request streams in async actions to ensure scalability and non-blocking I/O.
