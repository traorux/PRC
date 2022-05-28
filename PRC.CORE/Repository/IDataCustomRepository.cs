using PRC.CORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Repository
{
    public interface IDataCustomRepository
    {
        Task<IEnumerable<DataCustom>> GetAllDataCustom();
        Task<DataCustom> GetDataCustomById(int IdDataCustom);
        Task<bool> AddDataCustom(DataCustom datacustom);
        Task<DataCustom> UpdateDataCustom(DataCustom datacustom);
        Task DeleteDataCustom(DataCustom datacustom);
    }
}
