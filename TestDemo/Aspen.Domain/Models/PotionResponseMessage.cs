namespace Aspen.Domain.Models
{

    public class PotionResponseMessage
    {
        public string page { get; set; }
        public int total { get; set; }
        public string records { get; set; }
        public PotionResponse[] rows { get; set; }
    }
    public class PotionResponse
    {
        public int PotionID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Allergy { get; set; }
        public int ColorID { get; set; }
        public string Color { get; set; }
        public int EffectID { get; set; }
        public string Effect { get; set; }
    }

    public class PotionPutMessage
    {
        public bool Allergy { get; set; }
        public string Color { get; set; }
        public string Effect { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int id { get; set; }
    }
}
