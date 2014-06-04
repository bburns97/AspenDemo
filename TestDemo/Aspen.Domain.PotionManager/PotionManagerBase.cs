using Aspen.Data.Model.Contexts;
using Aspen.Data.Model.UnitofWork;
using Aspen.Domain.PotionManager.Interfaces;

namespace Aspen.Domain.PotionManager
{
    public class PotionManagerBase : IPotionManagerBase
    {
        private AspenModel _aspenModel;
        protected AspenModel aspenModel
        {
            get
            {
                return _aspenModel ?? new AspenModel();
            }
        }

        private PotionUnitofWork _potionUnitofWork;

        protected PotionUnitofWork PotionUOW
        {
            get { return _potionUnitofWork ?? new PotionUnitofWork(aspenModel); }
        }
        
    }
}
