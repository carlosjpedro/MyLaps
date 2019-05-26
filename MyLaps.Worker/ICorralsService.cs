using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyLaps.Worker.Model;

namespace MyLaps.Worker
{
    public interface ICorralService
    {
        Task<IEnumerable<Corral>> GetCorrals();
        void Update(Corral corral);
    }
}
