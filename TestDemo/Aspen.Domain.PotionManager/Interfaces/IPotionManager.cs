using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Aspen.Domain.PotionManager.Interfaces
{
    public interface IPotionManager
    {
        Potions GetPotion(Expression<Func<Potions, bool>> filter);
        List<Potions> GetAllPotions();
        List<Aspen.Domain.Color> GetAllColors();
        List<Effect> GetAllEffects();
        PotionRecipes GetPotionRecipes(Expression<Func<PotionRecipes, bool>> filter);
    }
}
