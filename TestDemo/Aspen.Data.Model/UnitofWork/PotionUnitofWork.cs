using System.Data.Entity;
using Aspen.Data.Model.Interfaces;
using Aspen.Data.Model.Repositories;

namespace Aspen.Data.Model.UnitofWork
{
    public class PotionUnitofWork : UnitOfWork, IPotionUnitofWork
    {
        public PotionUnitofWork(DbContext context) : base(context)
        {

        }

        public PotionRepository PotionRepository()
        {
            return new PotionRepository(_context);
        }

    }
}
                                  