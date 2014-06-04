namespace Aspen.Domain.Models
{
    public class PotionRecipieResponseMessage
    {
        public int RecipieID { get; set; }
        public string PotionRecipieJSON { get; set; }
        public string PotionRecipieIngredientList { get; set; }
        public int MoodID { get; set; }
        public int EffectID { get; set; }
        public string Effect { get; set; }
        
        
    }
}
