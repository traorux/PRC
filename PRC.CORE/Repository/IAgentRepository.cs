using PRC.CORE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRC.CORE.Repository
{
    public interface IAgentRepository
    {
        List<Agent> GetAll();
        Agent GetById(string Id);
        void Insert(Agent agent);
        void Update(Agent agent);
        void Delete(Agent agent);
        void Save();

    }
}
