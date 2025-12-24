## 2024-05-22 - Async IO in MVC Controllers
**Learning:**  on  is synchronous and can block threads. Replacing it with  is a straightforward scalability win.
**Action:** When seeing  in async methods, check if it can be replaced with direct  async methods.
## 2024-05-22 - Async IO in MVC Controllers
**Learning:** BinaryReader on HttpPostedFileBase.InputStream is synchronous and can block threads. Replacing it with Stream.ReadAsync is a straightforward scalability win.
**Action:** When seeing BinaryReader in async methods, check if it can be replaced with direct Stream async methods.
