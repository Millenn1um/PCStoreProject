﻿namespace PCStore.Models
{
    public class CPU
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Cores { get; set; }
        public float ClockSpeed { get; set; } // in GHz
        public string ImageUrl { get; set; } // URL for CPU image
    }
}
