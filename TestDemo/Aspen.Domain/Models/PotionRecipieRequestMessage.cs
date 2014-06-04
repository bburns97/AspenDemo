namespace Aspen.Domain.Models
{
    public class PotionRecipieRequestMessage
    {
        public string PotionRecipieJSON { get; set; }
        public string PotionRecipieIngredientList { get; set; }
        public int MoodID { get; set; }
    }
}
