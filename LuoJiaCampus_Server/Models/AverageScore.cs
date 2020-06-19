namespace LuoJiaCampus_Server.Models {
    public class AverageScore {
        public float averageScore { get; set; }
        public int beyond90 { get; set; }
        public int between80and90 { get; set; }
        public int between70and80 { get; set; }
        public int between60and70 { get; set; }
        public int below60 { get; set; }
    }
}