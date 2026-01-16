# Bolt's Journal

## 2025-02-06 - [.NET Framework] Synchronous I/O in Async Actions
**Learning:** Legacy ASP.NET MVC controllers often mix async actions with synchronous `BinaryReader` usage, negating some benefits of async I/O.
**Action:** Replace `BinaryReader` with `Stream.ReadAsync` loops when reading full streams in async actions.
