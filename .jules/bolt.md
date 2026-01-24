## 2024-05-21 - [Legacy IO Handling]
**Learning:** Legacy `BinaryReader` usage on `HttpPostedFileBase` synchronously blocks threads and closes the underlying stream on disposal, causing potential runtime errors on reuse.
**Action:** Replace with `Stream.ReadAsync` loop and manual buffer management. Verify with ad-hoc console apps (`Verification/`) as the solution cannot be built locally.
