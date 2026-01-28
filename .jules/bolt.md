## 2024-05-21 - Legacy ASP.NET Async
**Learning:** Legacy ASP.NET controllers can be async, but verification in a non-Windows environment is tricky. Review tools might misinterpret partial diffs on existing async methods.
**Action:** Always verify the full method signature when optimizing legacy code and explicitly include context in diffs if needed.
