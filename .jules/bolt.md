## 2024-10-24 - [Legacy ASP.NET File Upload Optimization]
**Learning:** `HttpPostedFileBase.InputStream` reading via `BinaryReader` is synchronous and double-allocates. Direct `Stream.ReadAsync` into a pre-allocated buffer based on `ContentLength` is the preferred pattern for performance, but requires a manual read loop to guarantee full data retrieval.
**Action:** Use `Stream.ReadAsync` with a `while` loop accumulating bytes for file uploads, replacing `BinaryReader` or `MemoryStream.CopyTo`.
