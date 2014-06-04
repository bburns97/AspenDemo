using System.Data.Entity;
using Aspen.Data.Model.Interfaces;
using Aspen.Domain;

namespace Aspen.Data.Model.Repositories
{
    public class PotionRepository : Repository<Potions>, IPotionRepository
    {
        public PotionRepository(DbContext dbcontext) : base(dbcontext)
        {
            
        }
    }
}
