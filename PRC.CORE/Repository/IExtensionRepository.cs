using PRC.CORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Repository
{
    public interface IExtensionRepository
    {
        Task<IEnumerable<Extension>> GetAllExtension();
        Task<Extension> GetExtensionById(string Number);
        Task<Extension> GetExtensionByNumber(string ExtensionNumber);
        Task<bool> AddExtension(Extension extension);
        Task<bool> UpdateExtension(Extension extension);
        Task DeleteExtension(Extension extension);
    }
}
