using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Aspen.Domain.PotionManager.Interfaces;

namespace Aspen.Domain.PotionManager
{
    public class PotionManager : PotionManagerBase, IPotionManager
    {
        public Potions GetPotion(Expression<Func<Potions, bool>> filter)
        {
            var potionRepo = PotionUOW.Repository<Potions>();
            var query = potionRepo.Query().Filter(filter).Include(n => n.navColor).Include(n => n.navEffect);
            return query.Get().SingleOrDefault();
        }

        public List<Potions> GetAllPotions()
        {
            var potionRepo = PotionUOW.Repository<Potions>();
            var query = potionRepo.Query().Include(n => n.navColor).Include(n => n.navEffect);
            return query.Get().ToList();
        }

        public List<Aspen.Domain.Color> GetAllColors()
        {
            var colorRepo = PotionUOW.Repository<Color>();
            var query = colorRepo.Query();
            return query.Get().ToList();
        }

        public List<Effect> GetAllEffects()
        {
            var colorRepo = PotionUOW.Repository<Effect>();
            var query = colorRepo.Query();
            return query.Get().ToList(); 
        }

        public PotionRecipes GetPotionRecipes(Expression<Func<PotionRecipes, bool>> filter)
        {
            var colorRepo = PotionUOW.Repository<PotionRecipes>();
            var query = colorRepo.Query().Filter(filter).Include(n => n.navEffect);
            return query.Get().SingleOrDefault(); 
        }
    }
}
