## 2026-01-30 - Async Stream Reading vs BinaryReader
**Learning:** `BinaryReader.ReadBytes` is synchronous and blocks the thread, which is an anti-pattern in async ASP.NET methods.
**Action:** Use `Stream.ReadAsync` with a manual read loop and pre-allocated buffer (based on `ContentLength`) to ensure non-blocking I/O and efficient memory usage without double allocation (avoiding `MemoryStream.ToArray`).
