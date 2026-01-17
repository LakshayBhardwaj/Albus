# Bolt's Journal

## 2024-05-23 - [Initial Setup]
**Learning:** Legacy ASP.NET applications often use synchronous I/O in async actions, blocking thread pool threads.
**Action:** Always check for `BinaryReader` or `Stream.Read` in `async` controllers and refactor to `ReadAsync`.
