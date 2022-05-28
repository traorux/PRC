using PRC.CORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Repository
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetAllState();
        Task<State> GetSateById(int IdState);
        Task<bool> AddState(State state);
        Task<State> UpdateState(State state);
        Task DeleteState(State state);
    }
}
