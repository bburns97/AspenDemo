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
    
    public partial class Color
    {
        public Color()
        {
            this.navPotions = new HashSet<Potions>();
        }
    
        public int ColorID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<Potions> navPotions { get; set; }
    }
}
