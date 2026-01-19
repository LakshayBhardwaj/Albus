## 2024-05-22 - .NET Framework 4.7.2 Build Limitations
**Learning:** The current environment lacks `msbuild` and other tools necessary to build or run legacy .NET Framework 4.7.2 applications.
**Action:** Rely on static analysis and code review for verification. Do not attempt to run build commands.

## 2024-05-22 - Async I/O for HttpPostedFileBase
**Learning:** `BinaryReader` on `HttpPostedFileBase.InputStream` is blocking and may close the underlying stream upon disposal.
**Action:** Use `Stream.ReadAsync` with a buffer loop to read file content asynchronously without closing the stream.
