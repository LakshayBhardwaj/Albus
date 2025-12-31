# Bolt's Journal

## 2024-05-22 - [Buffer Management in Async File Reads]
**Learning:** When reading `HttpPostedFileBase.InputStream` with `ReadAsync` in a loop, pre-allocating a buffer of `ContentLength` and reading in chunks is cleaner, but one must be careful to use a loop to ensure all bytes are read. The previous approach of just `ReadAsync` with a large buffer works but a specific loop structure checking `bytesRead > 0` and total bytes is robust.
**Action:** When converting streams to byte arrays manually, ensure the loop handles partial reads correctly even if the buffer is pre-allocated to the full size, or use `CopyToAsync` to a `MemoryStream` if LOH pressure isn't the primary concern (though for large files, the pre-allocated array is better to avoid resizing).

## 2024-05-22 - [LOH Pressure with Large Arrays]
**Learning:** `BinaryReader.ReadBytes(int count)` allocates a new byte array. If `count` is large (>= 85,000 bytes), it goes to the Large Object Heap (LOH). Reading directly into a pre-allocated buffer from the stream (using `Stream.ReadAsync`) avoids the double allocation of `BinaryReader` (internal buffer + returned array) but the target array itself is still on LOH if large.
**Action:** For high-throughput file uploads, prefer streaming processing or pooling buffers if possible. For simple "read all" scenarios, pre-allocating the exact size is better than `MemoryStream` auto-resizing.
