//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aspen.Domain
{
    using System.Collections.Generic;
    
    public partial class Mood
    {
        public Mood()
        {
            this.navPotionRecipies = new HashSet<PotionRecipes>();
        }
    
        public int MoodID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<PotionRecipes> navPotionRecipies { get; set; }
    }
}