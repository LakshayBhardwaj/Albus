## 2024-05-22 - BinaryReader closes underlying stream
**Learning:** `BinaryReader` disposes the underlying stream by default. In `HomeController`, using it to read `HttpPostedFileBase.InputStream` causes subsequent access (like resetting position) to throw `ObjectDisposedException`.
**Action:** Use `Stream.ReadAsync` for non-blocking I/O and to keep the stream open. Ensure to read in a loop and use `Convert.ToBase64String` with the actual bytes read.
