## 2024-05-23 - BinaryReader Stream Closure
**Learning:** `BinaryReader` closes the underlying stream on Dispose by default. In MVC Controllers where the `InputStream` needs to be reused (e.g., reset Position=0), wrapping it in a `using(BinaryReader)` block will break subsequent usage.
**Action:** Use `Stream.ReadAsync` (or `Stream.Read`) directly, or use the `BinaryReader` constructor overload that keeps the stream open (`leaveOpen: true`). For async paths, direct `ReadAsync` is preferred for performance.
