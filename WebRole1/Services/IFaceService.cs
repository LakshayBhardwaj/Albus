using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebRole1.Controllers;

namespace WebRole1.Services
{
    public interface IFaceService
    {
        Task<IEnumerable<Face>> DetectFacesAsync(Stream imageStream);
    }
}
