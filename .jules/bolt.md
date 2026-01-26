## 2024-10-24 - [Synchronous I/O in Async Controller]
**Learning:** Found `BinaryReader.ReadBytes` (synchronous) blocking a thread inside an `async` Controller action. This defeats the purpose of async/await for scalability.
**Action:** Replaced with `Stream.ReadAsync` loop. Crucially, verified that `BinaryReader` disposal was potentially risky (closing stream) and that manual buffer management requires `Convert.ToBase64String(buffer, 0, length)` to handle partial reads or EOF correctly.
