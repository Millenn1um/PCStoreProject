namespace PCStore.Models
{
    public class GPU
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Memory { get; set; } // in GB
        public string ImageUrl { get; set; } // URL for GPU image
    }
}
