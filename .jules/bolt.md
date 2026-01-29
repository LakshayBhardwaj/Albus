## 2024-05-22 - BinaryReader Stream Ownership
**Learning:** `BinaryReader` assumes ownership of the underlying stream and closes it on disposal by default. This causes bugs when the stream needs to be reused (e.g., reset `Position = 0`) after reading.
**Action:** Use `Stream.ReadAsync` (or `Stream.Read`) directly for reading raw bytes from streams that must remain open, avoiding `BinaryReader` entirely unless text parsing is strictly required and ownership is managed.
